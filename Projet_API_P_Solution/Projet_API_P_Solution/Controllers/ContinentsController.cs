using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_API_P_Solution.Data;
using Projet_API_P_Solution.Models;

namespace Projet_API_P_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly Projet_API_P_SolutionContext _context;

        public ContinentsController(Projet_API_P_SolutionContext context)
        {
            _context = context;
        }

        // GET: api/Continents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continent>>> GetContinent_1()
        {
            return await _context.Continent_1.Include("Pays").ToListAsync();
        }

        // GET: api/Continents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Continent>> GetContinent(int id)
        {
            var continent = await _context.Continent_1.FindAsync(id);

            if (continent == null)
            {
                return NotFound();
            }

            return continent;
        }
        // Get nombre de population par continent
        [HttpGet("{continent}/{year}")]
        public async Task<ActionResult<ulong>> GetPopContinent(Continent continent, int year)
        {
            ulong sum_pop = 0;
            

            if (continent == null)
            {
                return NotFound();
            }
             foreach (Pays pa in continent.Pays )
            {
                foreach (Population po in pa.Populations)
                {
                    if (po.annee == year)
                    {
                        sum_pop = sum_pop + po.nbrPopulation;
                    }
                }
            }

            return sum_pop;
        }
        // PUT: api/Continents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinent(int id, Continent continent)
        {
            if (id != continent.Id)
            {
                return BadRequest();
            }

            _context.Entry(continent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentExists(id))
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

        // POST: api/Continents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Continent>> PostContinent(Continent continent)
        {
            _context.Continent_1.Add(continent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContinent", new { id = continent.Id }, continent);
        }

        // DELETE: api/Continents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Continent>> DeleteContinent(int id)
        {
            var continent = await _context.Continent_1.FindAsync(id);
            if (continent == null)
            {
                return NotFound();
            }

            _context.Continent_1.Remove(continent);
            await _context.SaveChangesAsync();

            return continent;
        }

        private bool ContinentExists(int id)
        {
            return _context.Continent_1.Any(e => e.Id == id);
        }
    }
}
