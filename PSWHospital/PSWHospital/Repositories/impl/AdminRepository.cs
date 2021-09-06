using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSWHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWHospital.Repositories.impl
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MyDbContext dbContext;

        public AdminRepository(MyDbContext context)
        {

            dbContext = context;
        }
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            return await dbContext.Admins.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await dbContext.Admins.ToListAsync();
        }
    }
}
