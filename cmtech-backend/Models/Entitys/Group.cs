using cmtech_backend.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Entitys
{
    [Table("grupo")]
    public class Group : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        public Group(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Group(string name)
        {
            this.Name = name;
        }
    }
}
