using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Muscles_app.Models
{
    public class UserWorkouts
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public UserWorkouts()
        {
            
        }
            
    }
}
