using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Users
{
    public class CreateUsersRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public int age { get; set; }
		public string? ProfilePicture { get; set; } = null;
		public int? Weight { get; set; }
        public string? WeightUnit { get; set; }
        public string? Height { get; set; }
        public string? HeightUnit { get; set; }
    }
}