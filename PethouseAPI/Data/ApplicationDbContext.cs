using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PethouseAPI.Data.Models;
using PethouseAPI.Data.Models.Enums;

namespace PethouseAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<Owner>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<PeakSeason> PeakSeasons { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BreedSize> BreedSizes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PetAppointment> PetAppointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define a default role
            var roleId = "23fa8dce-e71a-4b38-b87b-6d3a563117f9";
            var userId = "82d6dd18-6ef9-44a1-9d42-8062050c8acd";
            var userId2 = "0bee3397-ce64-4984-b580-10e879543d53";
            
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            
            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = userId,
                    Name = "Juan Brito",
                    Email = "coco@gmail.com",
                    PhoneNumber = "9992923563",
                    Address = "calle falsa 123",
                    EmergencyContactName = "Dai",
                    EmergencyContactPhone = "9992923923",
                    EmergencyContactRelationship = "Sister",        
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEPaVTBk9lpYQqLrFL+03K2dW9iYLOyTWqUz05g3/nsv+mers/cQ28tSdIt94ifosOA==",
                    SecurityStamp = "22f8c254-7918-4706-810d-2ed8209d32fa",
                    ConcurrencyStamp = "14b79b06-0bec-4129-99bb-5d126ebf48e8"
                },
                new Owner
                {
                    Id = userId2,
                    Name = "Dai",
                    Email = "dai@gmail.com",
                    PhoneNumber = "99999999",
                    Address = "calle falsa 123",
                    EmergencyContactName = "coco",
                    EmergencyContactPhone = "111111111",
                    EmergencyContactRelationship = "brother",
                    UserName = "DAI",
                    NormalizedUserName = "DAI",
                    NormalizedEmail = "DAI@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEPaVTBk9lpYQqLrFL+03K2dW9iYLOyTWqUz05g3/nsv+mers/cQ28tSdIt94ifosOA==",
                    SecurityStamp = "599644fa-d678-4e4c-bc47-3f19e25067db",
                    ConcurrencyStamp = "5a7a81b1-6663-42f4-9f71-fdd5a265f037"
            
                }
                );            
            modelBuilder.Entity<BreedSize>().HasData(
                new BreedSize 
                {
                    Id = 1,
                    Name = "Small",
                    Label = "0-10kg",
                    PricePeakSeason = 100.00m,
                    PriceLowSeason = 120.00m
            
                },
                new BreedSize
                {
                    Id = 2,
                    Name = "Medium",
                    Label = "11-25kg",
                    PricePeakSeason = 150.00m,
                    PriceLowSeason = 170.00m
                },
                new BreedSize
                {
                    Id = 3,
                    Name = "Large",
                    Label = "26-40kg",
                    PricePeakSeason = 200.00m,
                    PriceLowSeason = 220.00m
                },
                new BreedSize
                {
                    Id = 4,
                    Name = "Extra Large",
                    Label = "41-60kg",
                    PricePeakSeason = 250.00m,
                    PriceLowSeason = 270.00m
                }
                );
            modelBuilder.Entity<Pet>().HasData(
                new Pet
                {
                    Id = 1,
                    Name = "Pocha",
                    DateOfBirth = new DateOnly(2022, 10, 10),
                    BreedName = "Chihuahua",
                    IsMedicated = false,
                    Notes = "None",
                    BreedSizeId = 1,
                    OwnerId = userId
                },
                new Pet
                {
                    Id = 2,
                    Name = "Luna",
                    DateOfBirth = new DateOnly(2020, 10, 10),
                    BreedName = "Border",
                    IsMedicated = false,
                    Notes = "None",
                    BreedSizeId = 2,
                    OwnerId = userId
                },
                new Pet
                {
                    Id = 3,
                    Name = "Coco",
                    DateOfBirth = new DateOnly(2018, 10, 10),
                    BreedName = "Labrador",
                    IsMedicated = false,
                    Notes = "None",
                    BreedSizeId = 3,
                    OwnerId = userId2
                }
                );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    AppointmentType = AppointmentType.Hospedaje,
                    StartDate = new DateOnly(2022, 10, 10),
                    EndDate = new DateOnly(2022, 12, 10),
                    IsTOSAppointmentDocumentSigned = true,
                    MedicalChecked = true,
                    CarnetCheked = true
            
                }
                );
            

            //BreedSize
            modelBuilder.Entity<Owner>().HasKey(o => o.Id);
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => new { login.LoginProvider, login.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(role => new { role.UserId, role.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            modelBuilder.Entity<BreedSize>().Property(o => o.PriceLowSeason).HasPrecision(18,2);
            modelBuilder.Entity<BreedSize>().Property(o => o.PricePeakSeason).HasPrecision(18,2);
        }

    }
}
