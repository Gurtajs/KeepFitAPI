using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class Users
	{
		[Key]
		public int UserId { get; set; }
		public string Email {get; set;} = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public int Age { get; set; }
		public string? ProfilePicture { get; set; } = null;
		public int? Weight { get; set; }
		public string? WeightUnit { get; set; }
		public string? Height { get; set; }
		public string? HeightUnit { get; set; }
		public List<Workouts> Workout { get; set; } = new List<Workouts>();
        public List<NutriGoals> NutriGoals { get; set; } = new List<NutriGoals>();
		public List<Meals> Meals { get; set; } = new List<Meals>();
    }
}