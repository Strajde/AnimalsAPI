using Microsoft.EntityFrameworkCore;

namespace AnimalsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Animals> Animals { get; set; }
    }
}
