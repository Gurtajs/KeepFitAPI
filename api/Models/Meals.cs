using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class Meals
	{
		[Key]
		public int MealId { get; set; }
		public string MealName { get; set; } = string.Empty;
		public string MealTime { get; set; } = string.Empty;
        public int Quantity { get; set; }
		public int Calories { get; set; }
		public int Carbs { get; set; }
        public int Fats { get; set; }
        public int Protein { get; set; }
        public int UserId { get; set; }  // Foreign key to User
        public Users? Users { get; set; }  // Required navigation property
    }
}

