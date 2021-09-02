
namespace PSWHospital.Models
{
    public class Doctor : User
    {
        public enum DoctorTypes
        {
            GENERAL_PRACTITIONER,
            DERMATOLOGIST,
            NEUROLOGIST
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public DoctorTypes DoctorType { get; set; }
    }
}
