using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Segment> Segments { get; set; }

        public DbSet<Org> Orgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Orgs)
                .WithOne(o => o.Group)
                .HasForeignKey(o => o.Group_id);

            modelBuilder.Entity<Segment>()
                .HasMany(s => s.Orgs)
                .WithOne(o => o.Segment)
                .HasForeignKey(o => o.Segment_id);
        }
    }
}
