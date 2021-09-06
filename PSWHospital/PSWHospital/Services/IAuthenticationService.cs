using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services
{
    public interface IAuthenticationService
    {
        Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest);
        Task<ActionResult<UserResponse>> Register(RegistrationRequest registrationRequest);
    }
}
