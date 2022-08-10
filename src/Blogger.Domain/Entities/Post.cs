﻿using Blogger.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogger.Domain.Entities
{
    [Table("Posts")]
    public class Post : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? Content { get; set; }

        public Post() { }

        public Post(int id, string title, string content)
        {
            (Id, Title, Content) = (id, title, content);
        }
    }
}
