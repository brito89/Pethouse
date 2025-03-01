using System.ComponentModel.DataAnnotations.Schema;

namespace PethouseAPI.Data.Models;

public class Owner
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string EmergencyContactName { get; set; }

    public string EmergencyContactPhone { get; set; }

    public string EmergencyContactRelationship { get; set; }

    [InverseProperty("Owner")]
    public List<Pet> Pets { get; set; }
}

