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
        public string DateRegister { get; set; }

        [Column("departamento_id")]
        public int Department_id { get; set; }

        public virtual Department Department { get; set; }

        [Column("perfil_id")]
        public int Profile_id { get; set; }

        public virtual Profile Profile { get; set; }

        [Column("organizacao_id")]
        public int Org_id { get; set; }

        public virtual Org Org { get; set; }

    }
}
