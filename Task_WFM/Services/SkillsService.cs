using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WFM.Abstractions;
using Task_WFM.Models;

namespace Task_WFM.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly WFMdbContext _wfmDbContext;
        public SkillsService(WFMdbContext wfmDbContext)
        {
            _wfmDbContext = wfmDbContext;
        }
        public async Task<IEnumerable<Skillswithemployees>> GetAllSkills()
        {
            var result = await _wfmDbContext.Skills.Include(x => x.skillmaps).ThenInclude(x => x.skills).Select(x => new Skillswithemployees
            {
                skillid = x.skillid,
                skillname = x.skillname,
                Employees = x.skillmaps.Select(y => y.employees.employee_name).ToList()
            }).ToListAsync();
            return result;
        }
    }
}
