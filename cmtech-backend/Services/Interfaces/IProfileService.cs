using cmtech_backend.Models;

namespace cmtech_backend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<Profile>> FindAll();

        public Task<Profile> Create(Profile profile);

        public Task<Profile> Update(Profile profile);

        public Task<List<Profile>> Delete(int id);
    }
}
