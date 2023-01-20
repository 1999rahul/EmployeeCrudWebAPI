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
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PasswordSalt = passwordHash,
                PasswordHash = passwordSalt
            };
            using (DapUnitOfWork unitOfWorks = new DapUnitOfWork(connString))
            {
                var user = unitOfWorks.AuthRepository.CreateUser(_mapper.Map<User>(userVM));
                var res = _mapper.Map<UserVM>(userVM);
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

        public string Login(UserLoginVM user)
        {


            using (DapUnitOfWork unitOfWorks = new DapUnitOfWork(connString))
            {
                var IsValidUser = unitOfWorks.AuthRepository.ValidateUser(user.UserName);

                if (!IsValidUser)
                {
                    return "Invalid Credintails";
                }
                var userDetails = _mapper.Map<UserVM>(unitOfWorks.AuthRepository.GetUserDetails(user.UserName));
                var IsPasswordCorrect = VerifyPasswordHash(user.Password, userDetails.PasswordHash, userDetails.PasswordSalt);//something is wrong, PasswordHash is swapped with PasswordSalt thatswhy passing PasswordHash at the place of passwordSalt and vice versa.
                if (!IsPasswordCorrect)
                {
                    return "Invalid Credintails";
                }
                return "MY TOKEN";

            }

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac =new HMACSHA512(passwordHash))
            {
                var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordSalt);
            }
        }
    }
}
