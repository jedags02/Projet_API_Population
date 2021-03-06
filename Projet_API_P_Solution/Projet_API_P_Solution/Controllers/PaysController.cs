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
    public class PaysController : ControllerBase
    {
        private readonly Projet_API_P_SolutionContext _context;

        public PaysController(Projet_API_P_SolutionContext context)
        {
            _context = context;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pays>>> GetPays()
        {
            return await _context.Pays.Include("Populations").ToListAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pays>> GetPays(int id)
        {
            var pays = await _context.Pays.FindAsync(id);

            if (pays == null)
            {
                return NotFound();
            }

            return pays;
        }
        // Get nombre de population d'un pays pour une année donnée
        [HttpGet("{pays}/{year}")]
        public async Task<ActionResult<ulong>> GetPopPaysAnnée(string pays, int year)
        {
            Pays py = null;
            foreach (Pays pa in await _context.Pays.Include(o => o.Populations).ToListAsync())
            {
                if (pa.nomPays == pays)
                {
                    py = pa;
                }
                
            }
            foreach (Population po in py.Populations)
            {
                if (po.annee == year)
                {
                    return po.nbrPopulation;
                }
                

            }
            return BadRequest("Not Found");
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPays(int id, Pays pays)
        {
            if (id != pays.Id)
            {
                return BadRequest();
            }

            _context.Entry(pays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaysExists(id))
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

        // POST: api/Pays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pays>> PostPays(Pays pays)
        {
            _context.Pays.Add(pays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPays", new { id = pays.Id }, pays);
        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pays>> DeletePays(int id)
        {
            var pays = await _context.Pays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }

            _context.Pays.Remove(pays);
            await _context.SaveChangesAsync();

            return pays;
        }

        private bool PaysExists(int id)
        {
            return _context.Pays.Any(e => e.Id == id);
        }
    }
}
