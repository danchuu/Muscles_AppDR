using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Muscles_app.Models
{
    public class UserHistory
    {

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Workout")]
        public int HistoryId { get; set; }

    }
}
