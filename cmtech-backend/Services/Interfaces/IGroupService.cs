using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IGroupService
    {
        public Task<List<Group>> FindAll();

        public Task<Group> Create(GroupDto createGroup);

        public Task<Group> Update(GroupDto updateGroup);

        public Task<List<Group>> Delete(int id);
    }
}
