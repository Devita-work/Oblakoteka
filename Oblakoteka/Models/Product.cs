using System.ComponentModel.DataAnnotations;

namespace Oblakoteka.Models;

public class Product
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public string Description { get; set; }
}