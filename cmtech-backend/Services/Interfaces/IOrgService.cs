using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IOrgService
    {
        public Task<List<Org>> FindAll();

        public Task<Org> Create(OrgDto org);

        public Task<Org> Update(OrgDto org);

        public Task<List<Org>> Delete(int orgId);
    }
}
