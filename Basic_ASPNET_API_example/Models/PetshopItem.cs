namespace PetshopApi.Models;

public class PetshopItem
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public required string Pedigree { get; set; }
    public required string Colour { get; set; }
    public required int Age { get; set; }
    public required float Price { get; set; }
    public required bool IsAdopted { get; set; }
}