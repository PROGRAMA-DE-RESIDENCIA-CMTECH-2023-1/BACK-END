using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class OrgServiceImpl : IOrgService
    {
        private readonly IRepository<Org> _orgRepository;

        private readonly IRepository<Segment> _segmentRepository;

        private readonly IRepository<Group> _groupRepository;

        private readonly OrgConverter _orgConverter;

        public OrgServiceImpl(IRepository<Org> orgRepository, IRepository<Segment> segmentRepository, IRepository<Group> groupRepository)
        {
            _orgRepository = orgRepository;
            _segmentRepository = segmentRepository;
            _groupRepository = groupRepository;
            _orgConverter = new OrgConverter();
        }

        public async Task<Org> Create(OrgDto org)
        {
            Org newOrg = await NewOrg(org);
            return await _orgRepository.Create(newOrg);
        }

        public async Task<List<Org>> Delete(int orgId)
        {
            return await _orgRepository.Delete(orgId);
        }

        public async Task<List<Org>> FindAll()
        {
            return await _orgRepository.FindAll();
        }

        public async Task<Org> Update(OrgDto org)
        {
            Org newOrg = await NewOrg(org);
            return await _orgRepository.Update(newOrg);
        }

        private async Task<Org> NewOrg(OrgDto org)
        {

            Segment? segment = await _segmentRepository.FindByName(org.Segment);
            if (segment != null)
            {
                org.SegmentId = segment.Id;
            }
            else
            {
                segment = new() { Id = 0, Name = org.Segment };
            }

            Group? group = await _groupRepository.FindByName(org.Group);
            if (group != null)
            {
                org.GroupId = group.Id;
            }
            else
            {
                group = new() { Id = 0, Name = org.Group };
            }
            Org newOrg = _orgConverter.Parse(org);
            newOrg.Segment = segment;
            newOrg.Group = group;
            return newOrg;
        }
    }
}
