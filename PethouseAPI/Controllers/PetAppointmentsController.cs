using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PethouseAPI.Data;
using PethouseAPI.Data.DTO;
using PethouseAPI.Data.Models;

namespace PethouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetAppointmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PetAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetAppointmentDTO>>> GetPetAppointments()
        {
            var appt = await _context.PetAppointments.Include(a => a.Appointment)
                                                     .Include(p => p.Pet)
                                                     .ThenInclude(b => b.BreedSize)
                                                     .ToListAsync();

            var apptDTO = appt.Select(a => new PetAppointmentDTO
            {
                Pet = new PetDTO
                {
                    Name = a.Pet.Name,
                    DateOfBirth = a.Pet.DateOfBirth,
                    BreedName = a.Pet.BreedName,
                    IsMedicated = a.Pet.IsMedicated,
                    Notes = a.Pet.Notes,
                    BreedSize = new BreedSizeDTO
                    {
                        Name = a.Pet.BreedSize.Name,
                        Label = a.Pet.BreedSize.Label,
                        PricePeakSeason = a.Pet.BreedSize.PricePeakSeason,
                        PriceLowSeason = a.Pet.BreedSize.PriceLowSeason
                    },
                },
                Appointment = new AppointmentDTO
                {
                    StartDate = a.Appointment.StartDate,
                    EndDate = a.Appointment.EndDate,
                    IsTOSAppointmentDocumentSigned = a.Appointment.IsTOSAppointmentDocumentSigned,
                    MedicalChecked = a.Appointment.MedicalChecked,
                    CarnetCheked = a.Appointment.CarnetCheked,
                    AppointmentType = a.Appointment.AppointmentType.ToString()
                },
                Monday = a.Monday,
                Tuesday = a.Tuesday,
                Wednesday = a.Wednesday,
                Thursday = a.Thursday,
                Friday = a.Friday,
                IsActive = a.IsActive
            }).ToList();

            return apptDTO;
        }

        // GET: api/PetAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetAppointmentDTO>> GetPetAppointment(int id)
        {
            var petAppointment = await _context.PetAppointments.Include(a => a.Appointment)
                                                                 .Include(p => p.Pet)
                                                                 .ThenInclude(b => b.BreedSize)
                                                                 .FirstOrDefaultAsync(pa => pa.Id == id);

            if (petAppointment == null)
            {
                return NotFound();
            }

            var apptDTO = new PetAppointmentDTO
            {
                Pet = new PetDTO
                {
                    Name = petAppointment.Pet.Name,
                    DateOfBirth = petAppointment.Pet.DateOfBirth,
                    BreedName = petAppointment.Pet.BreedName,
                    IsMedicated = petAppointment.Pet.IsMedicated,
                    Notes = petAppointment.Pet.Notes,
                    BreedSize = new BreedSizeDTO
                    {
                        Name = petAppointment.Pet.BreedSize.Name,
                        Label = petAppointment.Pet.BreedSize.Label,
                        PricePeakSeason = petAppointment.Pet.BreedSize.PricePeakSeason,
                        PriceLowSeason = petAppointment.Pet.BreedSize.PriceLowSeason
                    },
                },
                Appointment = new AppointmentDTO
                {
                    StartDate = petAppointment.Appointment.StartDate,
                    EndDate = petAppointment.Appointment.EndDate,
                    IsTOSAppointmentDocumentSigned = petAppointment.Appointment.IsTOSAppointmentDocumentSigned,
                    MedicalChecked = petAppointment.Appointment.MedicalChecked,
                    CarnetCheked = petAppointment.Appointment.CarnetCheked,
                    AppointmentType = petAppointment.Appointment.AppointmentType.ToString()
                },
                Monday = petAppointment.Monday,
                Tuesday = petAppointment.Tuesday,
                Wednesday = petAppointment.Wednesday,
                Thursday = petAppointment.Thursday,
                Friday = petAppointment.Friday,
                IsActive = petAppointment.IsActive
            };


            return apptDTO;
        }

        // PUT: api/PetAppointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetAppointment(int id, PetAppointment petAppointment)
        {
            if (id != petAppointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(petAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetAppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PetAppointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetAppointment>> PostPetAppointment(PetAppointment petAppointment)
        {
            _context.PetAppointments.Add(petAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetAppointment", new { id = petAppointment.Id }, petAppointment);
        }

        // DELETE: api/PetAppointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetAppointment(int id)
        {
            var petAppointment = await _context.PetAppointments.FindAsync(id);
            if (petAppointment == null)
            {
                return NotFound();
            }

            _context.PetAppointments.Remove(petAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetAppointmentExists(int id)
        {
            return _context.PetAppointments.Any(e => e.Id == id);
        }
    }
}
