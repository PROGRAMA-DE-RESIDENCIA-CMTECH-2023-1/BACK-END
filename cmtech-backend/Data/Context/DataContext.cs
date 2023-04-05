using cmtech_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cmtech_backend.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Profile> Perfil { get; set; }
    }
}
