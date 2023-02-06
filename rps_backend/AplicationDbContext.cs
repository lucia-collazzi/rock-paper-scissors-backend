using Microsoft.EntityFrameworkCore;
using rps_backend.Models;

namespace rps_backend
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
    }
}
