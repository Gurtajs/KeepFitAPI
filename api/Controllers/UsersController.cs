using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.DTOs.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using api.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace api.Controllers
{
	[Microsoft.AspNetCore.Mvc.Route("api/users")]
	[ApiController]

	public class UsersController : ControllerBase
	{
		private readonly ApplicationDBContext _context;

		public UsersController(ApplicationDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllUsers()
		{
			var Users = _context.Users.ToList();

			return Ok(Users);
		}

		[HttpGet("{id}")]
		public IActionResult GetUserById([FromRoute] int id)
		{
			var User = _context.Users.Find(id);

			if (User == null)
			{
				return NotFound();
			}
			return Ok(User.ToUsersDto());
		}

		[HttpPost]
		[Microsoft.AspNetCore.Mvc.Route("details")]
		public async Task<IActionResult> GetUserDetails([FromBody] JObject data)
		{
			try
			{
				// Extract email from JSON request body
				var email = data["email"]?.ToString();
				
				if (string.IsNullOrEmpty(email))
				{
					return BadRequest("Email is required");
				}

				// Fetch user details from MySQL database
				var userDetails = await GetUserDetailsByEmail(email);

				if (userDetails == null)
				{
					return NotFound("User not found");
				}

				return Ok(userDetails);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		 private async Task<Users> GetUserDetailsByEmail(string email)
		 {
        // Use parameterized query to prevent SQL injection
        var user = await _context.Users
            .FromSqlInterpolated($"SELECT * FROM Users WHERE Email = {email}")
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return null; // User not found
        }
        return new Users
        {
			UserId = user.UserId,
			Email= user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
			ProfilePicture = user.ProfilePicture,
			Weight = user.Weight,
			WeightUnit = user.WeightUnit,
			Height = user.Height,
			HeightUnit = user.HeightUnit,
        };
		}

		[HttpPost]
		public IActionResult PostUser([FromBody] CreateUsersRequestDto usersDto)
		{
			var usersModel = usersDto.ToUsersFromCreateDto();
			_context.Users.Add(usersModel);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetUserById), new { id = usersModel.UserId }, usersModel.ToUsersDto());
		}
		
		[HttpPatch("{id}")]
		public IActionResult PatchUser([FromRoute] int id, [FromBody] JsonPatchDocument<Users> patchUser)
		{
			if (patchUser != null)
			{
				var user = _context.Users.Find(id);

                patchUser.ApplyTo(user, ModelState);

				_context.SaveChanges();

				if (user == null)
				{
					return NotFound();
				}

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				return new ObjectResult(user);
			}
			else
			{
				return BadRequest(ModelState);
			}

		}

        [HttpGet("{id}/workouts")]

        public IActionResult GetWorkoutByUser([FromRoute] int id)
        {
            var workouts = _context.Workouts.FromSqlInterpolated($"SELECT * FROM Workouts WHERE userId = {id} ORDER BY workoutDate DESC").ToList();

            if (workouts == null)
            {
                return NotFound();
            }
            return Ok(workouts);
        }

        [HttpGet("{id}/workouts/{date:datetime}")]

        public IActionResult GetWorkoutByUserDate([FromRoute] int id, DateTime date)
        {
            var workouts = _context.Workouts.FromSqlInterpolated($"SELECT * FROM Workouts WHERE userId = {id} AND WorkoutDate = {date} ORDER BY workoutDate DESC").ToList();

            if (workouts == null)
            {
                return NotFound();
            }
            return Ok(workouts);
        }

        [HttpGet("{id}/workouts/{workoutId:int}")]

        public IActionResult GetWorkoutByWorkoutId(int id, int workoutId)
        {
            var workoutsById = _context.Workouts.FromSqlInterpolated($"SELECT * FROM Workouts WHERE userId = {id} AND WorkoutId = {workoutId}").ToList();

            if (workoutsById == null)
            {
                return NotFound();
            }
            return Ok(workoutsById);
        }

        [HttpDelete("{id}/workouts/{workoutId}")]

        public IActionResult DeleteWorkout(int id, int workoutId)
        {
            var workoutToDelete = _context.Workouts.FirstOrDefault(w => w.UserId == id && w.WorkoutId == workoutId);

            if (workoutToDelete == null)
            {
                return NotFound("workout not found");
            }
            _context.Remove(workoutToDelete);
            _context.SaveChanges();

            return Ok("Workout deleted successfully");
        }
    }
}
