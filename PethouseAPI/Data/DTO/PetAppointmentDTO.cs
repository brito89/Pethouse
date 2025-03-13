namespace PethouseAPI.Data.DTO;

public class PetAppointmentDTO
{
    public PetDTO? Pet { get; set; }
    public AppointmentDTO? Appointment { get; set; }
    public bool Monday { get; set; } = false;
    public bool Tuesday { get; set; } = false;
    public bool Wednesday { get; set; } = false;
    public bool Thursday { get; set; } = false;
    public bool Friday { get; set; } = false;
    public bool IsActive { get; set; }
}
