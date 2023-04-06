using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
