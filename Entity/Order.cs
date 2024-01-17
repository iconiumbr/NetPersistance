using FiapStore.DTO;

namespace FiapStore.Entity
{
    public class Order : Base
    {
        public string? ProductName { get; set; }
        public int UserId { get; set; }
        public User? User { get; internal set; }

        public Order() { }
        public Order(Order order) { 
            this.ProductName = order.ProductName;
            this.Id = order.Id;
            this.UserId = order.UserId;
        }

        public Order(CreateOrderDTO order) { 
            this.ProductName =order.ProductName;
            this.UserId = order.UserId;
        }
        public Order(UpdateOrderDTO order)
        {
            this.ProductName = order.ProductName;
            this.Id=order.Id;
        }

    }

    


}
