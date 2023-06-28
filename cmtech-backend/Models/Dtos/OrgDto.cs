using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Dtos
{
    public class OrgDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Segment { get; set; }

        public int SegmentId { get; set; }

        public string Group { get; set; }

        public int GroupId { get; set; }

        public List<UserOrganizationDto> UserOrganizations { get; set; }
    }
}
