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

        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Users)
                .WithOne(u => u.Profile)
                .HasForeignKey(u => u.Profile_id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Departments)
                .WithMany(d => d.Users)
                .UsingEntity<UserDepartment>();

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithMany(u => u.Departments)
                .UsingEntity<UserDepartment>();

            modelBuilder.Entity<Org>()
                .HasMany(o => o.Departments)
                .WithOne(d => d.Org)
                .HasForeignKey(d => d.Org_id);

            modelBuilder.Entity<Org>()
                .HasMany(o => o.Users)
                .WithOne(u => u.Org)
                .HasForeignKey(u => u.Org_id);
        }
    }
}
