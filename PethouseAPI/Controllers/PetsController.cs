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
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetPets()
        {
            var pets = await _context.Pets.Include(b => b.BreedSize)
                                      .ToListAsync();

            if (pets == null)
            {
                return NotFound();
            }


            var result = pets.Select(p => new PetDTO
            {
                Name = p.Name,
                DateOfBirth = p.DateOfBirth,
                BreedName = p.BreedName,
                IsMedicated = p.IsMedicated,
                Notes = p.Notes,
                BreedSize = new BreedSizeDTO
                {
                    Name = p.BreedSize.Name,
                    Label = p.BreedSize.Label,
                    PriceLowSeason = p.BreedSize.PriceLowSeason,
                    PricePeakSeason = p.BreedSize.PricePeakSeason
                }
            }).ToList();

            return result;


        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetPet(int id)
        {
            var pet = await _context.Pets.Include(b => b.BreedSize)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null || pet.BreedSize == null)
            {
                return NotFound();
            }

            var result = new PetDTO
            {
                Name = pet.Name,
                DateOfBirth = pet.DateOfBirth,
                BreedName = pet.BreedName,
                IsMedicated = pet.IsMedicated,
                Notes = pet.Notes,
                BreedSize = new BreedSizeDTO
                {
                    Name = pet.BreedSize.Name,
                    Label = pet.BreedSize.Label,
                    PriceLowSeason = pet.BreedSize.PriceLowSeason,
                    PricePeakSeason = pet.BreedSize.PricePeakSeason
                }
            };

            return result;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
