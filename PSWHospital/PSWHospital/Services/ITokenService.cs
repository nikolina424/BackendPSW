using PSWHospital.Models;

namespace PSWHospital.Services
{
    public interface ITokenService
    {
        string CreateToken(Patient patient);
        string CreateTokenUser(User user);
    }
}
