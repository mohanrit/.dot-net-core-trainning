using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WFM.Models;

namespace Task_WFM.Abstractions
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employeeswithskills>> GetAllEmployees();
    }
}
