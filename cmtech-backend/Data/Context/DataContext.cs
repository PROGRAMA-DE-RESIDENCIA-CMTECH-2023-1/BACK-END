using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Segment> Segment { get; set; }
    }
}
