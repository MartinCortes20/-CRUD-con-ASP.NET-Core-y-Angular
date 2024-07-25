namespace PruebaTecnica.Models
{
        public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
        public required string Phone { get; set; }

        public int RoleId { get; set; } // Clave foránea
          public Role? Role { get; set; } // Navegación (puede ser nulo)
    }

}

