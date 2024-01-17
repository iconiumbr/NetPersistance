using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetWithOrders(int id);
    }
}
