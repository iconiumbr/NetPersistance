using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace FiapStore.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entity.Base
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbset;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
