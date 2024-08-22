using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class MuscleGroups
	{
		[Key]
		public int MuscleGroupId { get; set; }

        public string? MuscleGroup { get; set; }
        public List<Workouts> Workout { get; set; } = new List<Workouts>();
    }
}

