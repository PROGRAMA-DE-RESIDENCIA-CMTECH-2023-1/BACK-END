namespace cmtech_backend.Models.Dtos
{
    public class MessageDto
    {
        public string user { get; set; } = string.Empty;

        public int recieverId { get; set; }

        public string message { get; set; } = string.Empty;
    }
}
