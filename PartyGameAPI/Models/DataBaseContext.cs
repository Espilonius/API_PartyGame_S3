using Microsoft.EntityFrameworkCore;
using PartyGameAPI.Models;
namespace PartyGameAPI.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }

        public DbSet<Session>? Sessions { get; set; }
        public DbSet<Command>? Commands { get; set; }
        public DbSet<Question>? Questions { get; set; }
    }
}
