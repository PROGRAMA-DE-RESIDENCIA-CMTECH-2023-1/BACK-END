using cmtech_backend.Models.Entitys;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Dtos
{
    public class UserOrganizationDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public UserDto User { get; set; }

        public OrgDto Org { get; set; }
        
    }
}
