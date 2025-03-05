using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PethouseAPI.Data;
using PethouseAPI.Data.Models;

namespace PethouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedSizesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BreedSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BreedSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreedSize>>> GetBreedSizes()
        {
            return await _context.BreedSizes.ToListAsync();
        }

        // GET: api/BreedSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BreedSize>> GetBreedSize(int id)
        {
            var breedSize = await _context.BreedSizes.FindAsync(id);

            if (breedSize == null)
            {
                return NotFound();
            }

            return breedSize;
        }

        // PUT: api/BreedSizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreedSize(int id, BreedSize breedSize)
        {
            if (id != breedSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(breedSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedSizeExists(id))
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

        // POST: api/BreedSizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BreedSize>> PostBreedSize(BreedSize breedSize)
        {
            _context.BreedSizes.Add(breedSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreedSize", new { id = breedSize.Id }, breedSize);
        }

        // DELETE: api/BreedSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreedSize(int id)
        {
            var breedSize = await _context.BreedSizes.FindAsync(id);
            if (breedSize == null)
            {
                return NotFound();
            }

            _context.BreedSizes.Remove(breedSize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedSizeExists(int id)
        {
            return _context.BreedSizes.Any(e => e.Id == id);
        }
    }
}
