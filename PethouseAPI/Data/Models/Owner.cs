using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class Owner
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public string? Address { get; set; }

    public required string EmergencyContactName { get; set; }

    public required string EmergencyContactPhone { get; set; }

    public required string EmergencyContactRelationship { get; set; }
    [JsonIgnore]
    public ICollection<Pet>? Pets { get; set; }
}

