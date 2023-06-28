using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Department { get; set; }

        public int? DepartmentId { get; set; }


        public string Profile { get; set; }

        public int ProfileId { get; set; }

        public List<UserOrganizationDto> UserOrganizations { get; set; }
    }

    public class UserRegisterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Department { get; set; }

        public int? DepartmentId { get; set; }


        public string Profile { get; set; }

        public int ProfileId { get; set; }

    }
}
