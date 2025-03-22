﻿namespace PethouseAPI.Data.DTO;

public class OwnerDTO
{
    public string Name { get; set; }

    public string Email { get; set; }

    public  string PhoneNumber { get; set; }

    public string? Address { get; set; }

    public  string EmergencyContactName { get; set; }

    public  string EmergencyContactPhone { get; set; }

    public  string EmergencyContactRelationship { get; set; }

    public ICollection<PetDTO>? Pets { get; set; }
}
