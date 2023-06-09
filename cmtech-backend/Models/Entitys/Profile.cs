﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using cmtech_backend.Models.Dtos;

namespace cmtech_backend.Models.Entitys
{
    [Table("perfil")]
    public class Profile : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}
