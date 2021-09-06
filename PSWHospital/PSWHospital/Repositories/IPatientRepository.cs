using Microsoft.AspNetCore.Mvc;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories
{
    public interface IPatientRepository
    {
        Task<ActionResult<Patient>> GetPatient(int id);
        Task<ActionResult<IEnumerable<Patient>>> GetPatients();
        bool Block(BlockedUserRequest blockedUserRequest);
        List<Patient> GetMaliciousPatients();
    }
}
