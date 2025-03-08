using PethouseAPI.Data.Models;

namespace PethouseAPI.Data.DTO;

public class OwnerDTO
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public string? Address { get; set; }

    public required string EmergencyContactName { get; set; }

    public required string EmergencyContactPhone { get; set; }

    public required string EmergencyContactRelationship { get; set; }

    public ICollection<PetDTO>? Pets { get; set; }
}
