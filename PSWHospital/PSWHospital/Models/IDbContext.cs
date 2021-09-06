using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Models
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Admin> Admins { get; set; }
    }
}
