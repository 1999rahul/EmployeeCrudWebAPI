using AutoMapper;
using EmployeeCrud.Data.UnitOfWorks;
using EmployeeCrud.Domain.IConnection;
using EmployeeCrud.Domain.Models;
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
        IMapper _mapper;
        string connString;
        public static UserVM user=new UserVM();
        public AuthService(IMapper mapper, IConnection conn)
        {
            _mapper = mapper;
            connString = conn.GetConnectionString();
        }
        public UserVM CreateUser(UserDtoVM request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var userVM = new UserVM()
            {
                FirstName= request.FirstName,
                LastName= request.LastName,
                UserName = request.UserName,
                PasswordSalt = passwordHash,
                PasswordHash = passwordSalt
            };
            using(DapUnitOfWork unitOfWorks=new DapUnitOfWork(connString))
            {
                var user = unitOfWorks.AuthRepository.CreateUser(_mapper.Map<User>(userVM));
                var res=_mapper.Map<UserVM>(userVM);
                return res;
            }
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
