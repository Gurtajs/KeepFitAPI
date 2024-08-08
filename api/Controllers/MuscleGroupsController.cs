using System;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
	[Route("api/musclegroups")]
	[ApiController]

	public class MuscleGroupsController : ControllerBase
	{
		private readonly ApplicationDBContext _context;


		public MuscleGroupsController(ApplicationDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllMuscleGroups()
		{
			var muscleGroups = _context.MuscleGroups.ToList();

			return Ok(muscleGroups);
		}
	}
}

