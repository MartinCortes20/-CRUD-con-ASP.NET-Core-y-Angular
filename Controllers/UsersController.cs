using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // GET: api/Users/admin
    [Authorize(Roles = "admin")]
    [HttpGet("admin/users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.Include(u => u.Role).ToListAsync();
    }



    // GET: api/Users/admin/{id}
    [Authorize(Roles = "admin")]
    [HttpGet("admin/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        _context.Entry(user).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
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

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    //arriba si sirve todo jajaj
    [HttpPost("login")]
public async Task<IActionResult> Login(LoginModel loginModel)
{
    var user = await _context.Users
        .SingleOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

    if (user == null)
    {
        return Unauthorized();
    }

    var token = GenerateJwtToken(user);
    return Ok(new { Token = token });
}

private string GenerateJwtToken(User user)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("ThisIsASecretKeyForJwtTokenEncryptionThatIsLongEnough"); // Cambia esto por una clave secreta más segura.
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.RoleId == 1 ? "admin" : "user") // Ajusta según el RoleId
        }),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}





    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}
