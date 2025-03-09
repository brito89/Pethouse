using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class BreedSizesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BreedSizesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BreedSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreedSizeDTO>>> GetBreedSizes()
        {
            var breedSizes = await _context.BreedSizes.ToListAsync();

            return _mapper.Map<List<BreedSizeDTO>>(breedSizes);
        }

        // GET: api/BreedSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BreedSizeDTO>> GetBreedSize(int id)
        {
            var breedSize = await _context.BreedSizes.FindAsync(id);

            if (breedSize == null)
            {
                return NotFound();
            }

            return _mapper.Map<BreedSizeDTO>(breedSize);
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
