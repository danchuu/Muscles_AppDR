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
            public int? Weight { get; set; }
            public int? Reps { get; set; }
            public int Sets { get; set; }
            public Status Status { get; set; }
            public ExerciseType ExerciseType { get; set; }
            public List<Workout> Workouts { get; set; }

        // Use ExerciseType name as the name of the exercise
        public string Name
        {
            get => ExerciseType?.Name;
            set { /* If you need to set the Name property, provide a setter */ }
        }

        // Identifier for the exercise list

            public Exercise()
            {
                Status = Status.Waiting;
                Workouts = new List<Workout>();
            }

            public Exercise(int weight, int reps, int sets, ExerciseType exerciseType)
            {
                Status = Status.Waiting;
                Weight = weight;
                Reps = reps;
                Sets = sets;
                ExerciseType = exerciseType;
              //  ExerciseListId = exerciseListId;
                Workouts = new List<Workout>();
            }
        }
    }

