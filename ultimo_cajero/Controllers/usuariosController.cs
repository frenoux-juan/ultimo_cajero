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
    public class usuariosController : ControllerBase
    {
        private readonly ultimo_cajeroContext _context;

        public usuariosController(ultimo_cajeroContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuarios>>> Getusuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> Getusuarios(int id)
        {
            var usuarios = await _context.usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios; 
        }

        // PUT: api/usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusuarios(int id, usuarios usuarios)
        {
            if (id != usuarios.id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuariosExists(id))
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

        // POST: api/usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<usuarios>> Postusuarios(usuarios usuarios)
        {
            _context.usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getusuarios", new { id = usuarios.id }, usuarios);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusuarios(int id)
        {
            var usuarios = await _context.usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool usuariosExists(int id)
        {
            return _context.usuarios.Any(e => e.id == id);
        }
    }
}
