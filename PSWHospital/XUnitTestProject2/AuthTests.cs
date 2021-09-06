using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using PSWHospital.Models;
using PSWHospital.Repositories;
using PSWHospital.Repositories.impl;
using PSWHospital.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject2
{
    public class AuthTests
    {
      
        [Fact]
        public async Task ShouldLoginSuccessfully()
        {
            var _authRepository = new Mock<IAuthenticationRepository>();
            using var hmac = new HMACSHA512();
            var loginRequest = new LoginRequest
            {
                UserName = "patient1@gmail.com",
                Password = "password"
            };
            var userResponse = new UserResponse() { Username = "patient1@gmail.com" };

            _authRepository.Setup(r => r.Login(loginRequest)).ReturnsAsync(userResponse);

            PSWHospital.Services.impl.AuthenticationService authenticationService = new PSWHospital.Services.impl.AuthenticationService(_authRepository.Object);
            ActionResult<UserResponse> p = await authenticationService.Login(loginRequest);
            Assert.NotNull(p);
        }

        [Fact]
        public async Task ShouldRegisterSuccessfully()
        {
            var _authRepository = new Mock<IAuthenticationRepository>();
            using var hmac = new HMACSHA512();
            var registrationRequest = new RegistrationRequest
            {
                Username = "patient1@gmail.com",
                Password = "password"
            };
            var userResponse = new UserResponse() { Username = "patient1@gmail.com" };

            _authRepository.Setup(r => r.Register(registrationRequest)).ReturnsAsync(userResponse);

            PSWHospital.Services.impl.AuthenticationService authenticationService = new PSWHospital.Services.impl.AuthenticationService(_authRepository.Object);
            ActionResult<UserResponse> p = await authenticationService.Register(registrationRequest);
            Assert.NotNull(p);
        }



    }
}
