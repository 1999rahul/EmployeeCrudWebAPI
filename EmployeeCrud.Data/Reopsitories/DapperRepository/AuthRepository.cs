using EmployeeCrud.Domain.IRepositories;
using EmployeeCrud.Domain.Models;
using System.Data;
using Dapper;


namespace EmployeeCrud.Data.Reopsitories.DapperRepository
{
    public class AuthRepository : IAuthRepository
    {
        IDbConnection connection;
        public AuthRepository(IDbConnection Connection)
        {
            connection = Connection;
        }
        public User CreateUser(User request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", request.FirstName, DbType.String);
            parameters.Add("LastName", request.LastName, DbType.String);
            parameters.Add("UserName", request.UserName, DbType.String);
            parameters.Add("PasswordHash",request.PasswordHash, DbType.Binary);
            parameters.Add("PasswordSalt", request.PasswordSalt, DbType.Binary);
            var res = connection.Query<User>("spCreateUser", parameters, commandType: CommandType.StoredProcedure).ToList()[0];
            return res;
        }
    }
}
