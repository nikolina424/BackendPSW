using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories.impl
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly MyDbContext dbContext;

        public DoctorRepository(MyDbContext context)
        {

            dbContext = context;
        }
        public List<Doctor> GetDermatologists()
        {
            List<Doctor> DermatologistsList = new List<Doctor>();

            foreach (Doctor d in dbContext.Doctors)
            {
                if (d.DoctorType.ToString() == "DERMATOLOGIST")
                {
                    DermatologistsList.Add(d);
                }
            }
            return DermatologistsList;
        }

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            return await dbContext.Doctors.FindAsync(id);
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await dbContext.Doctors.ToListAsync();
        }

        public List<Doctor> GetGeneralPractitioners()
        {
            List<Doctor> GeneralPractitionersList = new List<Doctor>();

            foreach (Doctor d in dbContext.Doctors)
            {
                if (d.DoctorType.ToString() == "GENERAL_PRACTITIONER")
                {
                    GeneralPractitionersList.Add(d);
                }
            }
            return GeneralPractitionersList;
        }

        public List<Doctor> GetNeurologists()
        {
            List<Doctor> NeurologistsList = new List<Doctor>();

            foreach (Doctor d in dbContext.Doctors)
            {
                if (d.DoctorType.ToString() == "NEUROLOGIST")
                {
                    NeurologistsList.Add(d);
                }
            }
            return NeurologistsList;
        }
    }
}
