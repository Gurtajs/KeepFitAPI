using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
	[Route("api/workouts")]

	[ApiController]
	public class WorkoutController : ControllerBase
	{
		private readonly ApplicationDBContext _context;
		public WorkoutController(ApplicationDBContext context)
		{
			_context = context;
		}

		[HttpGet]

		public IActionResult GetAll()
		{
			var Workouts = _context.Workouts.ToList();

			return Ok(Workouts);
		}

		[HttpGet("{id}")]
		public IActionResult GetWorkoutById([FromRoute] int id)
		{
			var Workout = _context.Workouts.Find(id);

			if (Workout == null)
			{
				return NotFound();
			}
			return Ok(Workout);
		}

		[HttpPost]
		public IActionResult PostWorkout([FromBody] Workouts workouts)
		{
			if (workouts == null)
			{
				return BadRequest();
			}

			_context.Workouts.Add(workouts);

			_context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetWorkoutById), new { id = workouts.WorkoutId }, workouts);
		}
}
}