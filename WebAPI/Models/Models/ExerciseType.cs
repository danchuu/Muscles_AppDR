using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
        public class ExerciseType
        {
            [Key]
            public int ExerciseTypeId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public BodyParts TargetedMuscle { get; set; }

            public Equipment Equipment { get; set; }

            public List<Exercise> Exercises { get; set; }

            public ExerciseType()
            {
                Exercises = new List<Exercise>();
            }
            public ExerciseType(string name, string description, BodyParts targetedmuscle, Equipment equipment)
            {
                Exercises = new List<Exercise>();
                Name = name;
                Description = description;
                TargetedMuscle = targetedmuscle;
                Equipment = equipment;
            }
        }
}
