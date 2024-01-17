using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User GetWithOrders(int id) {

            return _context.DbUser.Include(x => x.Orders).Where(u => u.Id == id)
                .ToList()
                .Select(u => { 
                    u.Orders = u.Orders.Select(p=> new Order(p)).ToList();
                    return u;
                }).FirstOrDefault();
        }
   
    }

    
}
