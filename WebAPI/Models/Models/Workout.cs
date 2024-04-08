using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        public List<ExerciseTypeGroup> ExerciseTypeGroups { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public Status Status { get; set; }

        public Workout()
        {
            ExerciseTypeGroups = new List<ExerciseTypeGroup>();
        }
        public Workout(User user)
        {
            Status = Status.Waiting;
            Creator = user;
            ExerciseTypeGroups = new List<ExerciseTypeGroup>();
        }

    }
}
