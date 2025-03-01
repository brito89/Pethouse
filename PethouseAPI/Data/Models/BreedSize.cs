using System.ComponentModel.DataAnnotations.Schema;

namespace PethouseAPI.Data.Models;

public class BreedSize
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Label { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePeakSeason { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PriceLowSeason { get; set; }

    [InverseProperty("BreedSize")]
    public List<Pet> Pets { get; set; }

}
