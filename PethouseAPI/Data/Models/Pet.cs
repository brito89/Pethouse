using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string BreedName { get; set; }
    public bool IsMedicated { get; set; }
    public string Notes { get; set; }

    [ForeignKey("BreedSize")]
    public int BreedSizeId { get; set; }
    public BreedSize BreedSize { get; set; }

    [ForeignKey("Owner")]
    public int OwnerId { get; set; }

    [InverseProperty("Pets")]
    [JsonIgnore]
    public Owner Owner { get; set; }

    public List<PetAppointment> PetsAppointments { get; set; }

}
