namespace cmtech_backend.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateRegister { get; set; }

        public string? Department { get; set; }

        public int? DepartamentId { get; set; }

        public string? Org { get; set; }

        public int? OrgId { get; set; }

        public string Profile { get; set; } = string.Empty;

        public int ProfileId { get; set; }
    }
}
