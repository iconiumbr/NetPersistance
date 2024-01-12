using FiapStore.Entity;
using FiapStore.Interface;

namespace FiapStore.Repository
{
    public abstract class DapperRepository<T> : IRepository<T> where T : Base
    {
        private string _connectionString=string.Empty;
        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration) {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }

        public abstract void Update(T entity);

        public abstract void Create(T entity);

        public abstract void Delete(int id);

        public abstract IList<T> GetAll();

        public abstract T GetById(int id);
    }
}
