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
		public async Task<IActionResult> GetUserDetails([FromBody] JsonElement data)
		{
			try
			{
				// Extract email from JSON request body
				var email = data.GetProperty("email").GetString();
				
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
			Email= user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
			Weight = user.Weight,
			Height = user.Height
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
	}
}