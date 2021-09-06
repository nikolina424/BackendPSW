using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using PSWHospital.Services;

namespace PSWHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _doctorService;


        public DoctorController(IDoctorService doctorService)
        {

            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        [HttpGet]
        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _doctorService.GetDoctorsAsync();
        }

        [HttpGet("dermatologists")]
        public List<Doctor> GetDermatologists()
        {
            return _doctorService.GetDermatologists();
        }

        [HttpGet("general-practitioners")]
        public List<Doctor> GetGeneralPractitioners()
        {
            return _doctorService.GetGeneralPractitioners();
        }


        [HttpGet("neurologists")]
        public List<Doctor> GetNeurologists()
        {
            return _doctorService.GetNeurologists();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            return await _doctorService.GetDoctor(id);
        }

    }
}
