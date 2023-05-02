namespace cmtech_backend.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DateRegister { get; set; }

        public string Org { get; set; }

        public int OrgId { get; set; }

        public string Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
