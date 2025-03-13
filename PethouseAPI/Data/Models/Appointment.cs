using PethouseAPI.Data.Models.Enums;

namespace PethouseAPI.Data.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsTOSAppointmentDocumentSigned { get; set; }
    public bool MedicalChecked { get; set; }
    public bool CarnetCheked { get; set; }
    public AppointmentType AppointmentType { get; set; }
    public ICollection<PetAppointment>? PetsAppointments { get; set; }

}
