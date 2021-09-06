using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Services
{
    public interface IAdminService
    {
        Task<ActionResult<Admin>> GetAdmin(int id);
        Task<ActionResult<IEnumerable<Admin>>> GetAdmins();
    }
}
