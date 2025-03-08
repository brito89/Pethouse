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
    public class OwnersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetOwners()
        {

            var result = await _context.Owners.Include(o => o.Pets).ThenInclude(b => b.BreedSize).Select(o => new OwnerDTO
            {
                Name = o.Name,
                Email = o.Email,
                PhoneNumber = o.PhoneNumber,
                Address = o.Address,
                EmergencyContactName = o.EmergencyContactName,
                EmergencyContactPhone = o.EmergencyContactPhone,
                EmergencyContactRelationship = o.EmergencyContactRelationship,
                Pets = o.Pets.Select(p => new PetDTO
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

                }).ToList()
            }).ToListAsync();

            return result;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDTO>> GetOwner(int id)
        {
            var o = await _context.Owners.Include(o => o.Pets).ThenInclude(b => b.BreedSize).FirstOrDefaultAsync(o => o.Id == id);

            if (o == null)
            {
                return NotFound();
            }

            var result = new OwnerDTO
            {
                Name = o.Name,
                Email = o.Email,
                PhoneNumber = o.PhoneNumber,
                Address = o.Address,
                EmergencyContactName = o.EmergencyContactName,
                EmergencyContactPhone = o.EmergencyContactPhone,
                EmergencyContactRelationship = o.EmergencyContactRelationship,
                Pets = o.Pets.Select(p => new PetDTO
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

                }).ToList()
            };

            return result;
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
