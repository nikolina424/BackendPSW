using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories
{
    public interface IDoctorRepository
    {
        List<Doctor> GetNeurologists();
        List<Doctor> GetGeneralPractitioners();
        Task<List<Doctor>> GetDoctorsAsync();
        Task<ActionResult<Doctor>> GetDoctor(int id);
        List<Doctor> GetDermatologists();
    }
}
