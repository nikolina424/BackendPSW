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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {

            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _adminService.GetAdmins();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            return await _adminService.GetAdmin(id);
        }

    }
}
