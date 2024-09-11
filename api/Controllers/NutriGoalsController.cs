using System;
using api.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/nutrigoals")]
    [ApiController]
    public class NutriGoalsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public NutriGoalsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetNutriGoals()
        {
            var goals = _context.NutriGoals.ToList();
            return Ok(goals);
        }
    }
}

