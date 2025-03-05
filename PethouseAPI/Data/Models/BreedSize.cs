using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class BreedSize
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Label { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePeakSeason { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceLowSeason { get; set; }
    [JsonIgnore]
    public ICollection<Pet>? Pets { get; set; }

}
