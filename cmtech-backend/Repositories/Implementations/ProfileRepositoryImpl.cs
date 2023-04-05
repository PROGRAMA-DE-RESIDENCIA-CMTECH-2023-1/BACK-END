using cmtech_backend.Models;
using cmtech_backend.Repositories.Interfaces;

namespace cmtech_backend.Repositories.Implementations
{
    public class ProfileRepositoryImpl : IProfileRepository
    {
        private readonly DataContext _context;
        public ProfileRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Profile>> GetProfiles()
        {
            return await _context.Perfil.ToListAsync();
        }
    }
}
