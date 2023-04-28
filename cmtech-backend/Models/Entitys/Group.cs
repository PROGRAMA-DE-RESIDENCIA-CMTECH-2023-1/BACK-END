using cmtech_backend.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cmtech_backend.Models.Entitys
{
    [Table("grupo")]
    public class Group : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Org> Orgs { get; set; }
    }
}
