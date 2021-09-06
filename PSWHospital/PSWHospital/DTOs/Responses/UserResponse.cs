
namespace PSWHospital.DTOs.Responses
{
    public class UserResponse
    {
        public enum UserTypes
        {
            ADMIN,
            PATIENT,
            DOCTOR
        }

        public string Username { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
        public UserTypes UserType { get; set; }
        public int IdGeneralPractitioner { get; set; }
    }
}
