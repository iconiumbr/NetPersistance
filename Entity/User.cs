using FiapStore.DTO;
using FiapStore.Enums;
using System.Security.Cryptography.X509Certificates;

namespace FiapStore.Entity
{
    public class User : Base
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public PermissionType Permission { get; set; }


        public ICollection<Order>? Orders { get; set; }

        public User() { }

        public User(CreateUserDTO user) { 
            this.Name = user.Name;
            this.Email = user.Email;
            this.UserName = user.Username;
            this.Password = user.Password;
            this.Permission = user.PermissionType;
        }
        public User(UpdateUserDTO user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
        }

    }
}
