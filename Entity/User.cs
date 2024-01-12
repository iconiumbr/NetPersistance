using FiapStore.DTO;
using System.Security.Cryptography.X509Certificates;

namespace FiapStore.Entity
{
    public class User : Base
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }

        public User() { }

        public User(CreateUserDTO user) { 
            this.Name = user.Name;
        }

    }
}
