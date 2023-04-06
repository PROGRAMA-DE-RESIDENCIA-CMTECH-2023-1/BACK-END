using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models
{
    [Table("perfil")]
    public class Profile : BaseEntity
    {
        [Column("nome")]
        public string? Name { get; set; }
    }
}
