using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWHospital.Models;
using PSWHospital.Repositories;

namespace PSWHospital.Services.impl
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        }
        public Task<ActionResult<Admin>> GetAdmin(int id)
        {
            return _adminRepository.GetAdmin(id);
        }

        public Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return _adminRepository.GetAdmins();
        }
    }
}
