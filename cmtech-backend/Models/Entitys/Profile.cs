﻿using System.ComponentModel.DataAnnotations.Schema;
using cmtech_backend.Models.Dtos;

namespace cmtech_backend.Models.Entitys
{
    [Table("perfil")]
    public class Profile : BaseEntity
    {
        [Column("nome")]
        public string? Name { get; set; }

        public Profile(int id, string name)
        {
            this.Name = name; 
            this.Id = id;
        }

        public Profile(string name)
        {
            this.Name = name;
        }
    }
}
