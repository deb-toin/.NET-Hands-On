using System.ComponentModel.DataAnnotations;
namespace PetshopApi.Models;

public class PetshopItem
{
    public long Id { get; set; }
    [StringLength(64)]
    public required string Name { get; set; }
    [StringLength(64)]
    public required string Species { get; set; }
    [StringLength(64)]
    public required string Pedigree { get; set; }
    [StringLength(64)]
    public required string Colour { get; set; }
    [Range(0, 30)] 
    public required int Age { get; set; }
    [Range(0, 5000)] 
    public required float Price { get; set; }
    public required bool IsAdopted { get; set; }
}