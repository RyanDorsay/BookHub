using System;
using System.ComponentModel.DataAnnotations;

namespace BookHub.Models;

public class Books
{
        public int Id { get; set; }  // Primary key

        [Required]
        [StringLength(150)]
        public required string Title { get; set; }  // Book title

        [Required]
        [StringLength(100)]
        public required string  Author { get; set; }  // Author's name

        [StringLength(50)]
        public string? Genre { get; set; }  // Book genre

        [StringLength(2000)]
        public string? Description { get; set; }  
}
