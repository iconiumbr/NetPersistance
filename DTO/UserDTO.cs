namespace FiapStore.DTO
{
    public class CreateUserDTO
    {
        public string? Name { get; set; }
    }
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
