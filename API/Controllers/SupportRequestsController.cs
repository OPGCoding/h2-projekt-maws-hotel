using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SupportRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SupportRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportRequest>>> GetSupportRequests()
        {
            return await _context.SupportRequests.ToListAsync();
        }

        // GET: api/SupportRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportRequest>> GetSupportRequest(int id)
        {
            var supportRequest = await _context.SupportRequests.FindAsync(id);

            if (supportRequest == null)
            {
                return NotFound();
            }

            return supportRequest;
        }

        // PUT: api/SupportRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupportRequest(int id, SupportRequest supportRequest)
        {
            if (id != supportRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportRequestExists(id))
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

        // POST: api/SupportRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupportRequest>> CreateSupportRequest(SupportRequest supportRequest)
        {
            _context.SupportRequests.Add(supportRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportRequest", new { id = supportRequest.Id }, supportRequest);
        }

        // DELETE: api/SupportRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportRequest(int id)
        {
            var supportRequest = await _context.SupportRequests.FindAsync(id);
            if (supportRequest == null)
            {
                return NotFound();
            }

            _context.SupportRequests.Remove(supportRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportRequestExists(int id)
        {
            return _context.SupportRequests.Any(e => e.Id == id);
        }
    }
}
