using System.Text.Json.Serialization;

namespace PethouseAPI.Data.Models;

public class AppointmentType
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public Appointment Appointment { get; set; }
}
