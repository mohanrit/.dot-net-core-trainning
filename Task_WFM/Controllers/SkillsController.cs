using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_WFM.Abstractions;
using Task_WFM.Models;

namespace Task_WFM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillService;
        public SkillsController(ISkillsService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/Skills
        [HttpGet]
        [Route("GetSkillsData")]
        public async Task<IActionResult> GetSkillsData()
        {
            try
            {
                var result = await _skillService.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
