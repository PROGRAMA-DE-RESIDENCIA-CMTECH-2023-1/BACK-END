using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class GroupServiceImpl : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;

        private readonly GroupConverter _converter;

        public GroupServiceImpl(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
            _converter = new GroupConverter();
        }

        public async Task<Group> Create(GroupDto createGroup)
        {
            Group group = _converter.Parse(createGroup);
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

        public async Task<Group> Update(GroupDto updateGroup)
        {
            Group group = _converter.Parse(updateGroup);
            return await _groupRepository.Update(group);
        }
    }
}
