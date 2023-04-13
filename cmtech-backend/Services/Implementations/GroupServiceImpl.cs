using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class GroupServiceImpl : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;

        public GroupServiceImpl(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Group> Create(CreateGroup createGroup)
        {
            Group group = new Group(createGroup.Name);
            return await _groupRepository.Create(group);
        }

        public async Task<List<Group>> Delete(int id)
        {
            return await _groupRepository.Delete(id);
        }

        public async Task<List<Group>> FindAll()
        {
            return await _groupRepository.FindAll();
        }

        public async Task<Group> Update(int id, CreateGroup updateGroup)
        {
            Group group = new Group(id, updateGroup.Name);
            return await _groupRepository.Update(id, group);
        }
    }
}
