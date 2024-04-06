using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Muscles_app.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        public List<Exercise> Exercises { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public Status Status { get; set; }

        public Workout()
        {
            Exercises = new List<Exercise>();
        }
        public Workout(User user)
        {
            Status = Status.Waiting;
            Creator = user;
            Exercises = new List<Exercise>();
        }

    }
}
