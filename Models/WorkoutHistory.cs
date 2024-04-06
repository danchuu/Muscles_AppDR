using Muscles_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WorkoutHistory
    {

        [Key]
        public int WorkoutHistoryId { get; set; }

        public List<ExerciseTypeGroup> ExerciseTypeGroups { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public Status Status { get; set; }

        public WorkoutHistory()
        {
            ExerciseTypeGroups = new List<ExerciseTypeGroup>();
        }
        public WorkoutHistory(User user)
        {
            Status = Status.Waiting;
            Creator = user;
            ExerciseTypeGroups = new List<ExerciseTypeGroup>();
        }


    }
}
