using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ExerciseTypeGroup
    {
        [Key]
        public int ExerciseTypeGroupId { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public List<Exercise> Exercises { get; set; }

        public ExerciseTypeGroup()
        {
            Exercises = new List<Exercise>();
        }
    }
}
