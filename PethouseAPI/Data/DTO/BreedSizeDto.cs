namespace PethouseAPI.Data.DTO;

public class BreedSizeDto
{
    public required string Name { get; set; }
    public string? Label { get; set; }
    public decimal PricePeakSeason { get; set; }
    public decimal PriceLowSeason { get; set; }
}
