using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Muscles_app.Models
{
    public class ExerciseTypeGroup
    {
        [Key]
        public int ExerciseTypeGroupID { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public ObservableCollection<Exercise> ExercisesInGroup { get; set; }
    
        public ExerciseTypeGroup()
        {
            ExercisesInGroup = new ObservableCollection<Exercise>();
        }
    }
}
