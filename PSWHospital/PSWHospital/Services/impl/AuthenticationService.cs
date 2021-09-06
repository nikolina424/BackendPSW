using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using PSWHospital.Repositories;
using System;
using System.Threading.Tasks;

namespace PSWHospital.Services.impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));
        }
        public Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            return _authenticationRepository.Login(loginRequest);
        }

        public Task<ActionResult<UserResponse>> Register(RegistrationRequest registrationRequest)
        {
            return _authenticationRepository.Register(registrationRequest);
        }
    }
}
