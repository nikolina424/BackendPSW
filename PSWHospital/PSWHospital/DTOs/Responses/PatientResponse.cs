using PSWHospital.Models;
using System.Collections.Generic;

namespace PSWHospital.DTOs.Responses
{
    public class PatientResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public bool IsDeleted { get; set; }
        public int CanceledExamination { get; set; }
    }
}
