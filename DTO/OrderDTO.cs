namespace FiapStore.DTO
{
    public class CreateOrderDTO
    {
        public string? ProductName { get; set; }
        public int UserId { get; set; }
    }
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
    }
}
