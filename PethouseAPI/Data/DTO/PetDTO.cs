namespace PethouseAPI.Data.DTO;

public class PetDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? BreedName { get; set; }
    public bool IsMedicated { get; set; }
    public string? Notes { get; set; }
    public BreedSizeDTO? BreedSize { get; set; }
}
