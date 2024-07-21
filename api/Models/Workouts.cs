using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class Workouts
	{
		[Key]
        public int WorkoutId { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime WorkoutDate { get; set; }
		public int UserId { get; set; }  // Foreign key to User
		public Users? Users { get; set; }  // Required navigation property
    }
}