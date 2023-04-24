﻿using cmtech_backend.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmtech_backend.Models.Entitys
{
    [Table("segmento")]
    public class Segment : BaseEntity
    {
        [Column("nome")]
        public string Name { get; set; }
    }
}