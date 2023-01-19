using EmployeeCrud.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Services.Iservices
{
    public interface IAuthService
    {
        UserVM CreateUser(UserDtoVM user);
    }
}
