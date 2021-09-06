using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories
{
    public interface IAdminRepository
    {
        Task<ActionResult<Admin>> GetAdmin(int id);
        Task<ActionResult<IEnumerable<Admin>>> GetAdmins();
    }
}
