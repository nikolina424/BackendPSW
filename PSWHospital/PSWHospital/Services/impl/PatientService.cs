using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using PSWHospital.Repositories;

namespace PSWHospital.Services.impl
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        }

        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }
    }
}
