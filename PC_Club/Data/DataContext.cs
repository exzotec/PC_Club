using Microsoft.EntityFrameworkCore;
using PC_Club.Models;

namespace PC_Club.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Api");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
