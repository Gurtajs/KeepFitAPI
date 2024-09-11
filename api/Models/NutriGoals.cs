using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class NutriGoals
	{
		[Key]
		public int DayId { get; set; }
		public string Calories { get; set; } = string.Empty;
        public string Protein { get; set; } = string.Empty;
        public string Carbs { get; set; } = string.Empty;
        public string Fat { get; set; } = string.Empty;

        public int UserId { get; set; }  // Foreign key to User
        public Users? Users { get; set; }  // Required navigation property
    }
}

