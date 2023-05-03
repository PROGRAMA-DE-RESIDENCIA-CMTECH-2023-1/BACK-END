using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IOrgService
    {
        public Task<List<OrgDto>> FindAll();

        public Task<Org> FindById(int id);

        public Task<OrgDto> Create(OrgDto org);

        public Task<OrgDto> Update(OrgDto org);

        public Task<List<OrgDto>> Delete(int orgId);
    }
}
