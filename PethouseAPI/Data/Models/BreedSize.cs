using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class BreedSize
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Label { get; set; }
    public decimal PricePeakSeason { get; set; }
    public decimal PriceLowSeason { get; set; }
    public ICollection<Pet>? Pets { get; set; }

}
