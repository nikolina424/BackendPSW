using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using PSWHospital.Exceptions;
using PSWHospital.Models;
using PSWHospital.Services;

namespace PSWHospital.Repositories.impl
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly MyDbContext dbContext;
        private readonly ITokenService _tokenService;

        public AuthenticationRepository(MyDbContext context, ITokenService tokenService)
        {
            dbContext = context;
            _tokenService = tokenService;
        }
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == loginRequest.UserName);

            if (user == null)
                throw new NotFoundException($"Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    throw new NotFoundException($"Invalid password");
            }
            if (user.UserType.ToString() == "PATIENT")
            {
                var patient = await dbContext.Patients.SingleOrDefaultAsync(x => x.UserName == loginRequest.UserName);
                if (patient.IsDeleted == false)
                {
                    return new UserResponse
                    {
                        Username = user.UserName,
                        Token = _tokenService.CreateTokenUser(user),
                        Id = user.Id,
                        UserType = (UserResponse.UserTypes)user.UserType,
                        IdGeneralPractitioner = patient.IdGeneralPractitioner
                    };
                }
                else
                {
                    throw new NotFoundException($"The user is blocked");
                }
            }
            else
            {
                return new UserResponse
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateTokenUser(user),
                    Id = user.Id,
                    UserType = (UserResponse.UserTypes)user.UserType
                };
            }

        }

        public async Task<ActionResult<UserResponse>> Register(RegistrationRequest registrationRequest)
        {
            if (await UserExists(registrationRequest.Username)) throw new Exception("Username is taken");

            using var hmac = new HMACSHA512();
            var patient = new Patient
            {

                PasswordSalt = hmac.Key,
                UserName = registrationRequest.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationRequest.Password)),
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Town = registrationRequest.Town,
                Address = registrationRequest.Address,
                IdGeneralPractitioner = registrationRequest.IdGeneralPractitioner,
                UserType = Models.User.UserTypes.PATIENT
            };
            dbContext.Patients.Add(patient);
            await dbContext.SaveChangesAsync();
            return new UserResponse
            {
                Username = patient.UserName,
                Token = _tokenService.CreateToken(patient)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await dbContext.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
