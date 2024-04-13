using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Exercise
    {

        [Key]

        public int ExerciseId { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public Status Status { get; set; }
        public ExerciseTypeGroup ExerciseTypeGroup { get; set; }

        // Use ExerciseType name as the name of the exercise
        public string Name
        {
            get => ExerciseTypeGroup?.ExerciseType.Name;
            set { /* If you need to set the Name property, provide a setter */ }
        }

        // Identifier for the exercise list

        public Exercise()
        {
            Status = Status.Waiting;
        }

        public Exercise(int weight, int reps, int sets, ExerciseTypeGroup exerciseTypeGroup)
        {
            Status = Status.Waiting;
            Weight = weight;
            Reps = reps;
            Sets = sets;
            ExerciseTypeGroup = exerciseTypeGroup;

        }
    }
}
