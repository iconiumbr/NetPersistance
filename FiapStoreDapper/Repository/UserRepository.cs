using Dapper;
using FiapStore.Entity;
using FiapStore.Interface;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace FiapStore.Repository
{
    public class UserRepository : DapperRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Create(User entity)
        {
            using var dbConn = new SqlConnection(ConnectionString);
            var query = "Insert into SystemUser (Name) values (@Name)";
            dbConn.Execute(query, entity);
        }

        public override void Delete(int id)
        {
            using var dbConn = new SqlConnection(ConnectionString);
            var query = "Delete from SystemUser where id=@id";
            dbConn.Execute(query,new {id=id});
        }

        public override IList<User> GetAll()
        {
            using var dbConn = new SqlConnection(ConnectionString);
            var query = "Select * from SystemUser";
            return dbConn.Query<User>(query).ToList();
        }

        public override User GetById(int id)
        {
            using var dbConn = new SqlConnection(ConnectionString);
            var query = "Select * from SystemUser where Id=@id";
            return dbConn.Query<User>(query, new { id = id }).FirstOrDefault();
        }

        public override void Update(User entity)
        {
            using var dbConn = new SqlConnection(ConnectionString);
            var query = "Update SystemUser set Name=@name where id=@id";
            dbConn.Execute(query, entity);

        }
    }
}
