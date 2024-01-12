using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IRepository<T> where T : Base
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
