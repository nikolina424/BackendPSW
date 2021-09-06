using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using PSWHospital.Repositories;

namespace PSWHospital.Services.impl
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }
        public List<Doctor> GetDermatologists()
        {
            return _doctorRepository.GetDermatologists();
        }

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            return await _doctorRepository.GetDoctor(id);
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }

        public List<Doctor> GetGeneralPractitioners()
        {
            return _doctorRepository.GetGeneralPractitioners();
        }

        public List<Doctor> GetNeurologists()
        {
            return _doctorRepository.GetNeurologists();
        }
    }
}
