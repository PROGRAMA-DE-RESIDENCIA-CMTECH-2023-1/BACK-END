using System.ComponentModel.DataAnnotations.Schema;

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
        public int Segment_id { get; set; }

        public virtual Segment Segment { get; set; }

        [Column("grupo_id")]
        public int Group_id { get; set; }

        public virtual Group Group { get; set; }
    }
}
