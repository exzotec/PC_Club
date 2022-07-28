using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Club.Data;
using PC_Club.Data.Interface;
using PC_Club.Data.Repository;
using PC_Club.Models;

namespace PC_Club.Controllers
{
    [Authorize(Roles = "SuperAdmin, Manager")]
    [ApiController]
    [Route("api/Club")]
    public class ClubController : ControllerBase
    {
        #region datacontext
        IBaseRepository<Club> dbClub;

        DataContext context;

        public ClubController(DataContext _context)
        {
            context = _context;

            dbClub = new ClubRepository(context);
        }
        #endregion

        #region CRUD on Club
        [Route("GetAllClubs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetAll()
        {
            return await context.clubs.ToListAsync();
        }

        [Route("createClub")]
        [HttpPost]
        public ActionResult CreateClub(Club club)
        {
            if (club == null)
                return BadRequest();

            if (context.clubs.Any(x => x.Id == club.Id))
                return BadRequest(new { errorText = "Этот клуб уже зарегестрирован" });

            dbClub.Create(new Club
            {
                Address = club.Address,
                Description = club.Description,
                Provider = club.Provider,
                Timetable = club.Timetable,
            });
            dbClub.Save();
            return Ok(club);
        }

        [Route("editClub")]
        [HttpPut]
        public async Task<ActionResult<Club>> EditClub(Club club)
        {
            if (club == null)
            {
                return BadRequest();
            }
            if (!context.clubs.Any(x => x.Id == club.Id))
            {
                return NotFound();
            }

            dbClub.Update(club);
            await context.SaveChangesAsync();

            return Ok(club);
        }

        [HttpDelete("deleteClub/{id}")]
        public async Task<IActionResult> DeleteClub(Guid id)
        {
            dbClub.Delete(id);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
