using Microsoft.EntityFrameworkCore;
using PethouseAPI.Data.Models;

namespace PethouseAPI.Data
{
    public class ApplicationDbContext : DbContext
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

    }
}
