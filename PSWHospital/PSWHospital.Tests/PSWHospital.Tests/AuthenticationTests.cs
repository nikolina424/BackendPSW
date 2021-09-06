using FluentAssertions;
using NUnit.Framework;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using PSWHospital.Repositories.impl;

namespace PSWHospital.Tests
{
    [TestFixture]
    public class AuthenticationTests
    {
        private AuthenticationRepository _authenticationRepository;

        public AuthenticationTests(AuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [Test]  
        public void PatientShouldLoginSuccessfully()
        {
            //Arange
            var loginRequest = new LoginRequest()
            {
                UserName = "test",
                Password = "password"
            };
            var expected = new Patient
            {
                UserName = "patient1@gmail.com",
                UserType = User.UserTypes.PATIENT,
                IdGeneralPractitioner = 5,
                Id = 1
            };

            //Act
            var result = _authenticationRepository.Login(loginRequest);

            //Assert
            result.Should().Be(expected);
        }
    }
}
