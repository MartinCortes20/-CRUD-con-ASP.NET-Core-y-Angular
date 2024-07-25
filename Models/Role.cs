namespace PruebaTecnica.Models
{
    public class Role
    {
        public int RoleId { get; set; } // Cambiado de Id a RoleId
        public required string Name { get; set; }
        
        public ICollection<User> Users { get; set; } = new List<User>(); // Inicialización
    }
}
