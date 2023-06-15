namespace cmtech_backend.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<string> Departments { get; set; } = new List<string>();

        public List<int> DepartmentsId { get; set; } = new List<int>();

        public string? Org { get; set; }

        public int? OrgId { get; set; }

        public string Profile { get; set; } = string.Empty;

        public int ProfileId { get; set; }
    }
}
