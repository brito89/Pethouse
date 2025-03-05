
using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class PetAppointment
{
    public int Id { get; set; }
    public int PetId { get; set; }
    [JsonIgnore]
    public Pet? Pet { get; set; }
    public int AppointmentId { get; set; }    
    public Appointment? Appointment { get; set; }
    public bool Monday { get; set; } = false;
    public bool Tuesday { get; set; } = false;
    public bool Wednesday { get; set; } = false;
    public bool Thursday { get; set; } = false;
    public bool Friday { get; set; } = false;

}
