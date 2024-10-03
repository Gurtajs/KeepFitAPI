﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Meals", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealId"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<decimal>("Carbs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fats")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("MealDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MealTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("MealId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("api.Models.MuscleGroups", b =>
                {
                    b.Property<int>("MuscleGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MuscleGroupId"));

                    b.Property<string>("MuscleGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MuscleGroupId");

                    b.ToTable("MuscleGroups");
                });

            modelBuilder.Entity("api.Models.NutriGoals", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayId"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbs")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("DayId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("NutriGoals");
                });

            modelBuilder.Entity("api.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeightUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("WeightUnit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.Workouts", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"));

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MuscleGroupsMuscleGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<DateTime>("WorkoutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkoutId");

                    b.HasIndex("MuscleGroupsMuscleGroupId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("api.Models.Meals", b =>
                {
                    b.HasOne("api.Models.Users", "Users")
                        .WithMany("Meals")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Models.NutriGoals", b =>
                {
                    b.HasOne("api.Models.Users", "Users")
                        .WithMany("NutriGoals")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Models.Workouts", b =>
                {
                    b.HasOne("api.Models.MuscleGroups", "MuscleGroups")
                        .WithMany("Workout")
                        .HasForeignKey("MuscleGroupsMuscleGroupId");

                    b.HasOne("api.Models.Users", "Users")
                        .WithMany("Workout")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("MuscleGroups");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Models.MuscleGroups", b =>
                {
                    b.Navigation("Workout");
                });

            modelBuilder.Entity("api.Models.Users", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("NutriGoals");

                    b.Navigation("Workout");
                });
#pragma warning restore 612, 618
        }
    }
}
