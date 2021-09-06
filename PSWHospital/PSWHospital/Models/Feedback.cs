using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string FeedbackContent { get; set; }
        public bool ShowOnFront { get; set; }
        public int PatientId { get; set; }
        public string UsersFirstName { get; set; }
        public string UsersLastName { get; set; }
        public Patient Patient { get; set; }
    }
}
