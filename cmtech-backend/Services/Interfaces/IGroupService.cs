using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IGroupService
    {
        public Task<List<Group>> FindAll();

        public Task<Group> Create(CreateGroup createGroup);

        public Task<Group> Update(int id, CreateGroup updateGroup);

        public Task<List<Group>> Delete(int id);
    }
}
