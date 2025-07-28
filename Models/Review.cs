using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCSBackend.Models;

public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(1, 5)]  
    public int Rating { get; set; }

    [MaxLength(1000)]
    public string? Comment { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
}
