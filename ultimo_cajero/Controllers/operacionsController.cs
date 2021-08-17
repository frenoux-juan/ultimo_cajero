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
    public class operacionsController : ControllerBase
    {
        private readonly ultimo_cajeroContext _context;

        public operacionsController(ultimo_cajeroContext context)
        {
            _context = context;
        }

        // GET: api/operacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<operacion>>> Getoperacion()
        {
            return await _context.operacion.ToListAsync();
        }

        // GET: api/operacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<operacion>> Getoperacion(int id)
        {
            var operacion = await _context.operacion.FindAsync(id);

            if (operacion == null)
            {
                return NotFound();
            }

            return operacion;
        }

        // PUT: api/operacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putoperacion(int id, operacion operacion)
        {
            if (id != operacion.id)
            {
                return BadRequest();
            }

            _context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!operacionExists(id))
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

        // POST: api/operacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<operacion>> Postoperacion(operacion operacion)
        {
            _context.operacion.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getoperacion", new { id = operacion.id }, operacion);
        }

        // DELETE: api/operacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteoperacion(int id)
        {
            var operacion = await _context.operacion.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }

            _context.operacion.Remove(operacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool operacionExists(int id)
        {
            return _context.operacion.Any(e => e.id == id);
        }
    }
}
