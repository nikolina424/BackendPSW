using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using PSWHospital.Services;

namespace PSWHospital.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginDto)
        {
            return await _authenticationService.Login(loginDto);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegistrationRequest registrationRequest)
        {
            return await _authenticationService.Register(registrationRequest);
        }

    }
}
