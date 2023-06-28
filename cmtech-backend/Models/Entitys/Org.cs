using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cmtech_backend.Models.Entitys
{
    [Table("organizacao")]
    public class Org : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        [Column("telefone")]
        public string Phone { get; set; }

        [Column("segmento_id")]
        [ForeignKey("segmento")]
        public int Segment_id { get; set; }

        public virtual Segment Segment { get; set; }

        [Column("grupo_id")]
        [ForeignKey("grupo")]
        public int Group_id { get; set; }

        public virtual Group Group { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; }

        [JsonIgnore]
        public List<Department> Departments { get; set; }

        public List<UserOrganization> UserOrganizations { get; set; }
    }
}
