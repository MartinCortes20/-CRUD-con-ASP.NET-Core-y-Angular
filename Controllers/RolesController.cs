using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Data;  // Asegúrate de incluir esta línea
using PruebaTecnica.Models; // También este si estás usando modelos definidos en otro archivo

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role); // Cambiado de Id a RoleId
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role role)
        {
            if (id != role.RoleId) // Cambiado de Id a RoleId
            {
                return BadRequest();
            }
            _context.Entry(role).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id)) // Cambiado de Id a RoleId
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

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RoleExists(int id) // Cambiado de Id a RoleId
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
    }
}
