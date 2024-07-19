using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Users
{
    public class UsersDto
    {
		public int UserId { get; set; }
		public string Email {get; set;} = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public int Age { get; set; }
		public string? ProfilePicture { get; set; } = null;
		public int? Weight { get; set; }
		public int? Height { get; set; }

    }
}