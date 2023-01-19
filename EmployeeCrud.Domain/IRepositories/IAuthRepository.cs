using EmployeeCrud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Domain.IRepositories
{
    public interface IAuthRepository
    {
        public User CreateUser(UserDto request);
    }
}
