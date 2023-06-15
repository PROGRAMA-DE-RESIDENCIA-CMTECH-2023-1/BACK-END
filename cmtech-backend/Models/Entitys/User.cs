using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Entitys
{
    [Table("usuario")]
    public class User : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Password { get; set; }

        [Column("data_cadastro")]
        public DateTime DateRegister { get; set; }

        public virtual List<Department> Departments { get; set; } = new();

        [Column("organizacao_id")]
        public int? Org_id { get; set; }

        public virtual Org? Org { get; set; }

        [Column("perfil_id")]
        public int Profile_id { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
