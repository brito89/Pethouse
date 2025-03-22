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
            // modelBuilder.Entity<Owner>().HasData(
            //     new Owner
            //     {
            //         Id = "1",
            //         Name = "Juan Brito",
            //         Email = "coco@gmail.com",
            //         PhoneNumber = "9992923563",
            //         Address = "calle falsa 123",
            //         EmergencyContactName = "Dai",
            //         EmergencyContactPhone = "9992923923",
            //         EmergencyContactRelationship = "Sister",
            //         LockoutEnd = null
            //         
            //
            //     },
            //     new Owner
            //     {
            //         Id = "2",
            //         Name = "Dai",
            //         Email = "dai@gmail.com",
            //         PhoneNumber = "99999999",
            //         Address = "calle falsa 123",
            //         EmergencyContactName = "coco",
            //         EmergencyContactPhone = "111111111",
            //         EmergencyContactRelationship = "brother",
            //         LockoutEnd = null
            //
            //     }
            //     );            
            // modelBuilder.Entity<BreedSize>().HasData(
            //     new BreedSize 
            //     {
            //         Id = 1,
            //         Name = "Small",
            //         Label = "0-10kg",
            //         PricePeakSeason = 100.00m,
            //         PriceLowSeason = 120.00m
            //
            //     },
            //     new BreedSize
            //     {
            //         Id = 2,
            //         Name = "Medium",
            //         Label = "11-25kg",
            //         PricePeakSeason = 150.00m,
            //         PriceLowSeason = 170.00m
            //     },
            //     new BreedSize
            //     {
            //         Id = 3,
            //         Name = "Large",
            //         Label = "26-40kg",
            //         PricePeakSeason = 200.00m,
            //         PriceLowSeason = 220.00m
            //     },
            //     new BreedSize
            //     {
            //         Id = 4,
            //         Name = "Extra Large",
            //         Label = "41-60kg",
            //         PricePeakSeason = 250.00m,
            //         PriceLowSeason = 270.00m
            //     }
            //     );
            // modelBuilder.Entity<Pet>().HasData(
            //     new Pet
            //     {
            //         Id = 1,
            //         Name = "Pocha",
            //         DateOfBirth = new DateOnly(2022, 10, 10),
            //         BreedName = "Chihuahua",
            //         IsMedicated = false,
            //         Notes = "None",
            //         BreedSizeId = 1,
            //         OwnerId = "1"
            //     },
            //     new Pet
            //     {
            //         Id = 2,
            //         Name = "Luna",
            //         DateOfBirth = new DateOnly(2020, 10, 10),
            //         BreedName = "Border",
            //         IsMedicated = false,
            //         Notes = "None",
            //         BreedSizeId = 2,
            //         OwnerId = "1"
            //     },
            //     new Pet
            //     {
            //         Id = 3,
            //         Name = "Coco",
            //         DateOfBirth = new DateOnly(2018, 10, 10),
            //         BreedName = "Labrador",
            //         IsMedicated = false,
            //         Notes = "None",
            //         BreedSizeId = 3,
            //         OwnerId = "2"
            //     }
            //     );
            // modelBuilder.Entity<Appointment>().HasData(
            //     new Appointment
            //     {
            //         Id = 1,
            //         AppointmentType = AppointmentType.Hospedaje,
            //         StartDate = new DateOnly(2022, 10, 10),
            //         EndDate = new DateOnly(2022, 12, 10),
            //         IsTOSAppointmentDocumentSigned = true,
            //         MedicalChecked = true,
            //         CarnetCheked = true
            //
            //     }
            //     );

            //BreedSize
            modelBuilder.Entity<Owner>().HasKey(o => o.Id);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<BreedSize>().Property(o => o.PriceLowSeason).HasPrecision(18,2);
            modelBuilder.Entity<BreedSize>().Property(o => o.PricePeakSeason).HasPrecision(18,2);
        }

    }
}
