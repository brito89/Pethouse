using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? BreedName { get; set; }
    public bool IsMedicated { get; set; }
    public string? Notes { get; set; }

    public int BreedSizeId { get; set; }
    public BreedSize? BreedSize { get; set; }

    public int OwnerId { get; set; }

    public Owner? Owner { get; set; }
    
    public ICollection<PetAppointment>? PetsAppointments { get; set; }

}
