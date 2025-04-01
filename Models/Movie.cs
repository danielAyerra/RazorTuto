using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorTuto.Models;

public class Movie
{
    public int Id { get; set; }
    
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }
    
    
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }
    
    [Range(0.01, 9999.99)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
    
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(10, MinimumLength = 1)]
    [Required]
    [Column(TypeName = "char(10)")]
    public string Rating { get; set; } = string.Empty;
}
