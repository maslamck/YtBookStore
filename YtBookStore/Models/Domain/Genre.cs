﻿using System.ComponentModel.DataAnnotations;

namespace YtBookStore.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength (8)]
        public string Name { get; set; }

    }
}
