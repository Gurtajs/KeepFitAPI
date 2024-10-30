using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class NutriGoals
	{
		[Key]
		public int DayId { get; set; }
		public int Calories { get; set; }  
        public int Protein { get; set; } 
        public int Carbs { get; set; } 
        public int Fat { get; set; }
        private DateTime _goalDate;

        public DateTime GoalDate
        {
            get { return _goalDate.Date; }
            set { _goalDate = value.Date; }
        }
        public int UserId { get; set; }  // Foreign key to User
        public Users? Users { get; set; }  // Required navigation property
    }
}

