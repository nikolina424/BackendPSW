using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services
{
    public interface IDoctorService
    {
        Task<ActionResult<Doctor>> GetDoctor(int id);
        List<Doctor> GetNeurologists();
        List<Doctor> GetGeneralPractitioners();
        List<Doctor> GetDermatologists();
        Task<List<Doctor>> GetDoctorsAsync();
    }
}
