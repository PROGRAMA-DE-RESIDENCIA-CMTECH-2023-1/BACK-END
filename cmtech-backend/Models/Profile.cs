using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models
{
    [Table("perfil")]
    public class Profile
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Name { get; set; }
    }
}
