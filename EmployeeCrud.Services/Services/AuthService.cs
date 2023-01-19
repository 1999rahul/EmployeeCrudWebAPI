using EmployeeCrud.Services.Iservices;
using EmployeeCrud.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Services.Services
{
    public class AuthService : IAuthService
    {
        public static UserVM user=new UserVM();
        public AuthService() { }
        public UserVM CreateUser(UserDtoVM request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;   
            user.UserName=request.UserName;
            return user;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
