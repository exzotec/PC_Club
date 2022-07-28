using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Club.Data;
using PC_Club.Data.Interface;
using PC_Club.Models;

namespace PC_Club.Data.Repository
{
    public class ClubRepository : IBaseRepository<Club>
    {
        #region datacontext
        private DataContext dbClub;

        public ClubRepository(DataContext _dbClub)
        {
            dbClub = _dbClub;
        }
        #endregion

        #region CRUD
        public void Create(Club item)
        {
            dbClub.clubs.Add(item);
        }

        public void Delete(Guid id)
        {
            Club club = dbClub.clubs.Find(id);
            if (club != null)
                dbClub.clubs.Remove(club);
        }

        public Club Get(string id)
        {
            return dbClub.clubs.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Club>>> GetAll()
        {
            return await dbClub.clubs.ToListAsync();
        }

        public void Save()
        {
            dbClub.SaveChanges();
        }

        public void Update(Club item)
        {
            dbClub.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        #endregion

        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbClub.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

