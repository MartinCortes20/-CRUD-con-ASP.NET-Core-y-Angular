using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "admin")] // Asegura que solo los administradores puedan acceder
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Admin/users
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
