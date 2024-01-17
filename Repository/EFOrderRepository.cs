using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class EFOrderRepository : EFRepository<Order>, IOrderRepository
    {
        public EFOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(Order order)
        {
            var existingOrder = GetById(order.Id);
            if (existingOrder == null) return;

            order.UserId = existingOrder.UserId;
            base.Update(order);
        }

    }

    
}
