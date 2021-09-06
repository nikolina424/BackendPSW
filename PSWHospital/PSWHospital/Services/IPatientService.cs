using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services
{
    public interface IPatientService
    {
        Task<ActionResult<Patient>> GetPatient(int id);
        Task<ActionResult<IEnumerable<Patient>>> GetPatients();
    }
}
