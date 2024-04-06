using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Muscles_app.Models
{
    public class Exercise
    {
        [Key]
      
        public int ExerciseId { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }
        public Status Status { get; set; }

        public ExerciseType exerciseType { get; set; }

        public List<Workout> Workouts { get; set; }

        public Exercise()
        {
            Status = Status.Waiting;
            Workouts = new List<Workout>();
        }

        public Exercise(int weight, int reps, int sets)
        {
            Status = Status.Waiting;
            Weight = weight;
            Reps = reps;
            Workouts = new List<Workout>();
            Sets = sets;
        }

    }
}
