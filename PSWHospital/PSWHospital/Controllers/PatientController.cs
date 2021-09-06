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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;


        public PatientController(IPatientService patientService)
        {

            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _patientService.GetPatients();
        }

       
        [HttpGet("{id}")] 
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            return await _patientService.GetPatient(id);
        }

    }
}
