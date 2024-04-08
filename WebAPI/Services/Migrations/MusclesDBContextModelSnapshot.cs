﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services;

#nullable disable

namespace Services.Migrations
{
    [DbContext(typeof(MusclesDBContext))]
    partial class MusclesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<int?>("ExerciseTypeGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId");

                    b.HasIndex("ExerciseTypeGroupId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("Exercises", (string)null);
                });

            modelBuilder.Entity("Models.ExerciseType", b =>
                {
                    b.Property<int>("ExerciseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseTypeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetedMuscle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseTypeId");

                    b.ToTable("ExerciseTypes", (string)null);
                });

            modelBuilder.Entity("Models.ExerciseTypeGroup", b =>
                {
                    b.Property<int>("ExerciseTypeGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseTypeGroupId"));

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutHistoryId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseTypeGroupId");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("WorkoutHistoryId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseTypeGroups", (string)null);
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("WorkoutId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Workouts", (string)null);
                });

            modelBuilder.Entity("Models.WorkoutHistory", b =>
                {
                    b.Property<int>("WorkoutHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutHistoryId"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("WorkoutHistoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("Models.Exercise", b =>
                {
                    b.HasOne("Models.ExerciseTypeGroup", null)
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseTypeGroupId");

                    b.HasOne("Models.ExerciseType", "ExerciseType")
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("Models.ExerciseTypeGroup", b =>
                {
                    b.HasOne("Models.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.WorkoutHistory", null)
                        .WithMany("ExerciseTypeGroups")
                        .HasForeignKey("WorkoutHistoryId");

                    b.HasOne("Models.Workout", null)
                        .WithMany("ExerciseTypeGroups")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("Models.Workout", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany("Workouts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Exercise", null)
                        .WithMany("Workouts")
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.WorkoutHistory", b =>
                {
                    b.HasOne("Models.User", "Creator")
                        .WithMany("History")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Models.Exercise", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Models.ExerciseType", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Models.ExerciseTypeGroup", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("History");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Models.Workout", b =>
                {
                    b.Navigation("ExerciseTypeGroups");
                });

            modelBuilder.Entity("Models.WorkoutHistory", b =>
                {
                    b.Navigation("ExerciseTypeGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
