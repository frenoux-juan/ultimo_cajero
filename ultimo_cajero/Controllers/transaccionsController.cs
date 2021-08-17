using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ultimo_cajero.Data;
using ultimo_cajero.Models;

namespace ultimo_cajero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transaccionsController : ControllerBase
    {
        private readonly ultimo_cajeroContext _context;

        public transaccionsController(ultimo_cajeroContext context)
        {
            _context = context;
        }

        // GET: api/transaccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<transaccion>>> Gettransaccion()
        {
            return await _context.transaccion.ToListAsync();
        }

        // GET: api/transaccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<transaccion>> Gettransaccion(int id)
        {
            var transaccion = await _context.transaccion.FindAsync(id);

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/transaccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttransaccion(int id, transaccion transaccion)
        {
            if (id != transaccion.id)
            {
                return BadRequest();
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transaccionExists(id))
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

        // POST: api/transaccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<transaccion>> Posttransaccion(transaccion transaccion)
        {
            _context.transaccion.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettransaccion", new { id = transaccion.id }, transaccion);
        }

        // DELETE: api/transaccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetransaccion(int id)
        {
            var transaccion = await _context.transaccion.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            _context.transaccion.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool transaccionExists(int id)
        {
            return _context.transaccion.Any(e => e.id == id);
        }
    }
}
