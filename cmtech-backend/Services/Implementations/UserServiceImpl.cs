using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class UserServiceImpl : IUserService
    {
        private readonly IRepository<Org> _orgRepository;

        private readonly IRepository<Segment> _segmentRepository;

        private readonly IRepository<Group> _groupRepository;

        private readonly OrgConverter _orgConverter;
    }
}