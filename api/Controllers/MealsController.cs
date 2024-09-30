using System;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/meals")]

    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MealsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var meals = _context.Meals.ToList();

            return Ok(meals);
        }

        [HttpPost]
        public IActionResult PostMeals([FromBody] Meals meals)
        {
            if (meals == null)
            {
                return BadRequest();
            }

            _context.Meals.Add(meals);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = meals.MealId }, meals);
        }
    }
}

