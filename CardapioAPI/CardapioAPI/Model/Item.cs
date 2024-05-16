using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CardapioAPI.Model;

public class Item
{
    public Item()
    {
        
    }
    public Item(string name, string? description, string? ImagePath)
    {
        this.Name = name;
        this.Description = description;
        this.ImagePath = ImagePath;
    }

    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
}
