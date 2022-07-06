using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Club.Data;
using PC_Club.Data.Interface;
using PC_Club.Models;
using PC_Club.Repositories.Repositories;

namespace PC_Club.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    [ApiController]
    [Route("api/SA")]
    public class SuperAdminController : ControllerBase
    {
        #region datacontext
        IBaseRepository<User> dbUser;

        DataContext context;

        public SuperAdminController(DataContext _context)
        {
            context = _context;

            dbUser = new UserRepository(context);
        }
        #endregion

        #region CRUD on User

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await context.users.ToListAsync();
        }

        [Route("createUser")]
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (user == null)
                return BadRequest();

            if (context.users.Any(x => x.login == user.login))
                return BadRequest(new { errorText = "Пользователь с таким логином уже существует" });

            dbUser.Create(new User
            {
                login = user.login,
                password = user.password,
                roleId = user.roleId,
                first_name = user.first_name,
                middle_name = user.middle_name,
                last_name = user.last_name
            });
            dbUser.Save();
            return Ok(user);
        }

        [Route("editUser")]
        [HttpPut]
        public async Task<ActionResult<User>> EditUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!context.users.Any(x => x.userId == user.userId))
            {
                return NotFound();
            }

            dbUser.Update(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            dbUser.Delete(id);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
