using FiapStore.Enums;

namespace FiapStore.DTO
{
    public class CreateUserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public PermissionType PermissionType { get; set; }
    }
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class LoginDTO { 
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }

}
