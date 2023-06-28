using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Repositories.Interfaces
{
    public interface IUserOrganizationRepository : IRepository<UserOrganization>
    {
        Task<List<UserOrganization>> GetAllByUserId(int userId);
    }
}
