using PethouseAPI.Data.Models.Enums;

namespace PethouseAPI.Data.DTO;

public class AppointmentDTO
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool isTOSAppointmentDocumentSigned { get; set; }
    public bool MedicalChecked { get; set; }
    public bool CarnetCheked { get; set; }
    public String AppointmentType { get; set; }
}
