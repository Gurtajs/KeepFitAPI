using System;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{UserId}")]
        public IActionResult GetNutriGoals([FromRoute] int UserId)
        {
            var goals = _context.NutriGoals.FromSqlInterpolated($"SELECT * FROM NutriGoals WHERE UserId = {UserId}").ToList();
            return Ok(goals);
        }

        [HttpPost]
        public IActionResult PostNutriGoals([FromBody] NutriGoals nutriGoals)
        {
            if (nutriGoals == null)
            {
                return BadRequest();
            }

            _context.NutriGoals.Add(nutriGoals);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNutriGoals), new { id = nutriGoals.DayId }, nutriGoals);
        }
    }
}

