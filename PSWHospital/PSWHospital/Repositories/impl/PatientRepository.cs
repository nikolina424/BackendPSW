using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
