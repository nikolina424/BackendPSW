﻿
using System.Collections.Generic;

namespace PSWHospital.Models
{
    public class Patient : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public int IdGeneralPractitioner { get; set; }
        public bool IsDeleted { get; set; }
        public int CanceledExamination { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
