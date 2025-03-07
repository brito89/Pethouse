using PethouseAPI.Data.Models;

namespace PethouseAPI.Data.DTO;

public class PetDTO
{
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? BreedName { get; set; }
    public bool IsMedicated { get; set; }
    public string? Notes { get; set; }

    public int BreedSizeId { get; set; }

    public int OwnerId { get; set; }
}
