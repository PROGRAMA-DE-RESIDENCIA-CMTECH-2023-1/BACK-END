using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Entitys
{
    [Table("usuario_organizacao")]
    public class UserOrganization : BaseEntity
    {

        [Column("usuario_id")]
        public int UserId { get; set; }

        [Column("organizacao_id")]
        public int OrganizationId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual Org Org { get; set; }
    }

    [Table("organizacao")]
    public class Organization : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Name { get; set; }

    }
}