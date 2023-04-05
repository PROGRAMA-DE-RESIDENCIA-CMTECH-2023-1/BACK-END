using cmtech_backend.Models;

namespace cmtech_backend.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        public Task<List<Profile>> GetProfiles();
    }
}
