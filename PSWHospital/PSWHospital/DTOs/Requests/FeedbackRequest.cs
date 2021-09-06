using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.DTOs.Requests
{
    public class FeedbackRequest
    {
        public string FeedbackContent { get; set; }
        public bool ShowOnFront { get; set; }
        public int PatientId { get; set; }
        public string UsersFirstName { get; set; }
        public string UsersLastName { get; set; }
    }
}
