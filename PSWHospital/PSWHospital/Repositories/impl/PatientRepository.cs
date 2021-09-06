using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSWHospital.Adapters;
using PSWHospital.DTOs.Requests;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories.impl
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MyDbContext dbContext;

        public PatientRepository(MyDbContext context)
        {
            dbContext = context;
        }


        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            return await dbContext.Patients.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await dbContext.Patients.ToListAsync();
        }
        public bool Block(BlockedUserRequest blockedUserRequest)
        {
            if (blockedUserRequest.Id <= 0)
            {
                return false;
            }
            Patient patient = dbContext.Patients.SingleOrDefault(patient => patient.Id == blockedUserRequest.Id);
            if (patient == null)
            {
                return false;
            }
            else
            {
                patient.IsDeleted = true;
                dbContext.SaveChanges();
                PatientAdapter.PatientToPatientDto(patient);
                return true;
            }
        }

   
        public List<Patient> GetMaliciousPatients()
        {
            List<Patient> PatientsList = new List<Patient>();

            foreach (Patient p in dbContext.Patients)
            {
                if (p.IsDeleted == false)
                {
                    if (p.CanceledExamination >= 3)
                    {
                        PatientsList.Add(p);
                    }
                }

            }
            return PatientsList;
        }
    }
}
