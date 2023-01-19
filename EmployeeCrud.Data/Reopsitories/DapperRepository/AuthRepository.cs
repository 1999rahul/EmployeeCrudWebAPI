using EmployeeCrud.Domain.IRepositories;
using EmployeeCrud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Data.Reopsitories.DapperRepository
{
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository() { }
        public User CreateUser(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
