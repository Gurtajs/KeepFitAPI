using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }
        public DbSet<Workouts> Workouts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<MuscleGroups> MuscleGroups { get; set; }
        public DbSet<NutriGoals> NutriGoals { get; set; }
        public DbSet<Meals> Meals { get; set; }
    }
}