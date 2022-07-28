using Microsoft.EntityFrameworkCore;
using PC_Club.Models;

namespace PC_Club.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Club> clubs { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Api");
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                   new Role { roleId = 1, roleName = "SuperAdmin" },
                   new Role { roleId = 2, roleName = "ClubAdmin"},
                   new Role { roleId = 3, roleName = "SiteAdmin"},
                   new Role { roleId = 4, roleName = "Auditor"},
                   new Role { roleId = 5, roleName = "Client"},
                   new Role { roleId = 6, roleName = "Manager"},
                   new Role { roleId = 7, roleName = "Support"},
                   new Role { roleId = 8, roleName = "Analyst"});

            modelBuilder.Entity<User>().HasData(
                  new User
                  {
                      full_name = "Ivanov Ivan Ivanovich",
                      login = "ivan",
                      password = "ivan",
                      e_mail = "ivan@bk.ru",
                      //role = "SuperAdmin"
                  });
        }
    }
}
