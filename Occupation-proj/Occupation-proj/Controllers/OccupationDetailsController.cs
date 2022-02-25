using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Occupation_proj.Context;
using Occupation_proj.Models;

namespace Occupation_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationDetailsController : ControllerBase
    {
        private readonly OccupationDetailContext _context;

        public OccupationDetailsController(OccupationDetailContext context)
        {
            _context = context;
        }

        // GET: api/OccupationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccupationDetail>>> GetOccupationDetails()
        {
            return await _context.OccupationDetails.ToListAsync();
        }

        // GET: api/OccupationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccupationDetail>> GetOccupationDetail(int id)
        {
            var occupationDetail = await _context.OccupationDetails.FindAsync(id);

            if (occupationDetail == null)
            {
                return NotFound();
            }

            return occupationDetail;
        }

        // PUT: api/OccupationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupationDetail(int id, OccupationDetail occupationDetail)
        {
            if (id != occupationDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(occupationDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationDetailExists(id))
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

        // POST: api/OccupationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OccupationDetail>> PostOccupationDetail(OccupationDetail occupationDetail)
        {
            _context.OccupationDetails.Add(occupationDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOccupationDetail", new { id = occupationDetail.Id }, occupationDetail);
        }

        // DELETE: api/OccupationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupationDetail(int id)
        {
            var occupationDetail = await _context.OccupationDetails.FindAsync(id);
            if (occupationDetail == null)
            {
                return NotFound();
            }

            _context.OccupationDetails.Remove(occupationDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OccupationDetailExists(int id)
        {
            return _context.OccupationDetails.Any(e => e.Id == id);
        }
    }
}
