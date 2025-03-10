using AutoMapper;
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
        private readonly IMapper _mapper;

        public PetAppointmentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PetAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetAppointmentDTO>>> GetPetAppointments()
        {
            var appt = await _context.PetAppointments.Include(a => a.Appointment)
                                                     .Include(p => p.Pet)
                                                        .ThenInclude(b => b.BreedSize)
                                                     .ToListAsync();            

            return _mapper.Map<List<PetAppointmentDTO>>(appt);
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

            return _mapper.Map<PetAppointmentDTO>(petAppointment);
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
