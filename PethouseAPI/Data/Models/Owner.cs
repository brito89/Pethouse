using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PethouseAPI.Data.Models;

public class Owner : IdentityUser
{
    public  string? Name { get; set; }

    public string? Address { get; set; }

    public  string? EmergencyContactName { get; set; }

    public  string? EmergencyContactPhone { get; set; }

    public  string? EmergencyContactRelationship { get; set; }

    public ICollection<Pet>? Pets { get; set; }
}

