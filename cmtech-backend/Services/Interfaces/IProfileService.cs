using cmtech_backend.Models;

namespace cmtech_backend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<Profile>> GetProfiles();
    }
}
