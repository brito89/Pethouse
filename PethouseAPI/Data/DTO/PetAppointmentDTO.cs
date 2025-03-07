using PethouseAPI.Data.Models;

namespace PethouseAPI.Data.DTO;

public class PetAppointmentDTO
{
    public int PetId { get; set; }
    public int AppointmentId { get; set; }
    public bool Monday { get; set; } = false;
    public bool Tuesday { get; set; } = false;
    public bool Wednesday { get; set; } = false;
    public bool Thursday { get; set; } = false;
    public bool Friday { get; set; } = false;
    public bool isActive { get; set; }
}
