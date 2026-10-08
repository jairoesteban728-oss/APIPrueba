using APIPrueba.Data;
using APIPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<proyectos>> Get()
        {
            return await _context.Proyectos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<proyectos?>> GetById(int id)
        {
            var item = await _context.Proyectos.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-name/{nombreProyecto}")]
        public async Task<ActionResult<proyectos?>> GetByNombre(string nombreProyecto)
        {
            var item = await _context.Proyectos.AsNoTracking().FirstOrDefaultAsync(p => p.NombreProyecto.Contains(nombreProyecto));
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] proyectos proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proyecto.idProyectos }, proyecto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] proyectos proyecto)
        {
            var exists = await _context.Proyectos.AnyAsync(p => p.idProyectos == id);
            if (!exists) return NotFound();

            proyecto.idProyectos = id;
            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Proyectos.FindAsync(id);
            if (item == null) return NotFound();
            _context.Proyectos.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
