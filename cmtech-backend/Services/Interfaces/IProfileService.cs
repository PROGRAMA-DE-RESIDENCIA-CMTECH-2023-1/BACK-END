using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<Profile>> FindAll();

        public Task<Profile> Create(Profile profile);

        public Task<Profile> Update(int id, CreateProfile profile);

        public Task<List<Profile>> Delete(int id);
    }
}
