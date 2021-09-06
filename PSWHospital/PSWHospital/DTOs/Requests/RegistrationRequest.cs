using System.ComponentModel.DataAnnotations;
using static PSWHospital.DTOs.Responses.UserResponse;

namespace PSWHospital.DTOs.Requests
{
    public class RegistrationRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }

        public UserTypes UserType { get; set; }
        public int IdGeneralPractitioner { get; set; }
    }
}
