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
		public decimal Carbs { get; set; }
        public decimal Fats { get; set; }
        public decimal Protein { get; set; }
        private DateTime _mealDate;

        public DateTime MealDate
        {
            get { return _mealDate.Date; }  
            set { _mealDate = value.Date; }  
        }

        public int UserId { get; set; }  // Foreign key to User
        public Users? Users { get; set; }  // Required navigation property
    }
}

