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
    public class PeakSeasonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PeakSeasonsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PeakSeasons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeakSeasonDTO>>> GetPeakSeasons()
        {
            var peakSeasons = await _context.PeakSeasons.ToListAsync();
            
            return _mapper.Map<List<PeakSeasonDTO>>(peakSeasons);

        }

        // GET: api/PeakSeasons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeakSeasonDTO>> GetPeakSeason(int id)
        {
            var peakSeason = await _context.PeakSeasons.FirstOrDefaultAsync(ps => ps.Id == id);

            if (peakSeason == null)
            {
                return NotFound();
            }

            return _mapper.Map<PeakSeasonDTO>(peakSeason);
        }

        // PUT: api/PeakSeasons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeakSeason(int id, PeakSeason peakSeason)
        {
            if (id != peakSeason.Id)
            {
                return BadRequest();
            }

            _context.Entry(peakSeason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeakSeasonExists(id))
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

        // POST: api/PeakSeasons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeakSeason>> PostPeakSeason(PeakSeason peakSeason)
        {
            _context.PeakSeasons.Add(peakSeason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeakSeason", new { id = peakSeason.Id }, peakSeason);
        }

        // DELETE: api/PeakSeasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeakSeason(int id)
        {
            var peakSeason = await _context.PeakSeasons.FindAsync(id);
            if (peakSeason == null)
            {
                return NotFound();
            }

            _context.PeakSeasons.Remove(peakSeason);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeakSeasonExists(int id)
        {
            return _context.PeakSeasons.Any(e => e.Id == id);
        }
    }
}
