using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.DTOs.Responses;
using System.Threading.Tasks;

namespace PSWHospital.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<ActionResult<UserResponse>> Login(LoginRequest loginDto);
    }
}
