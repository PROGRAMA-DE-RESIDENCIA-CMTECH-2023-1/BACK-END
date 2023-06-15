using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cmtech_backend.Models.Entitys
{
    [Table("usuario_departamento")]
    public class UserDepartment : BaseEntity
    {
        [Column("usuario_id")]
        public int UserId { get; set; }

        [Column("departamento_id")]
        public int DepartmentId { get; set; }
    }
}
