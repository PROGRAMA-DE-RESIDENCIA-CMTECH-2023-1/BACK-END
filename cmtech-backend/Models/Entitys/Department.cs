using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Entitys
{
    [Table("departamento")]
    public class Department : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        [Column("organizacao_id")]
        public int Org_id { get; set; }

        public virtual Org Org { get; set; }
    }
}
