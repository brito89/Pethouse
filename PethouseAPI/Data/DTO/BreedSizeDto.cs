namespace PethouseAPI.Data.DTO;

public class BreedSizeDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Label { get; set; }
    public decimal PricePeakSeason { get; set; }
    public decimal PriceLowSeason { get; set; }
}
