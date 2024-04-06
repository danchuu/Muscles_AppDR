using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Muscles_app.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserRole Role { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Workout> Workouts { get; set; }

        public List<Workout> History { get; set; }


        public User()
        {
            Role = UserRole.Customer;
            History = new List<Workout>();
            Workouts = new List<Workout>();
        }

        public User(string name , string password)
        {
            Password = password;
            Name = name;
            Role = UserRole.Customer;
            History = new List<Workout>();
            Workouts = new List<Workout>();

        }
    }
}
