using Microsoft.EntityFrameworkCore;

namespace CRUDHP.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Aspirante> Aspirantes { get; set; }
    }
}
