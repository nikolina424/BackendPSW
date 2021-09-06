using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.DTOs.Requests
{
    public class ShowRequest
    {
        public long Id { get; set; }
        public bool ShowOnFront { get; set; }
    }
}
