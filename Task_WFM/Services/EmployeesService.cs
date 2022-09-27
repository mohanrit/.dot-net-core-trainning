using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WFM.Abstractions;
using Task_WFM.Models;

namespace Task_WFM.Services
{
    public class EmployeesService:IEmployeesService
    {
        private readonly WFMdbContext _wfmDbContext;
        public EmployeesService(WFMdbContext wfmDbContext)
        {
            _wfmDbContext = wfmDbContext;
        }
        
         public async Task<IEnumerable<Employeeswithskills>> GetAllEmployees()
        {
            var result = await _wfmDbContext.Employees.Include(x => x.skillmaps).ThenInclude(x => x.skills).Select(x => new Employeeswithskills
            {
                employee_id = x.employee_id,
                employee_name = x.employee_name,
                status = x.status,
                manager = x.manager,
                wfm_manager = x.wfm_manager,
                email = x.email,
                experience = x.experience,
                lockstatus = x.lockstatus,
                Skills = x.skillmaps.Select(y => y.skills.skillname).ToList()
            }).ToListAsync();

            return result;
        }
    }
}

