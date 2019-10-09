using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.Models
{

    //Requried for many-to-many relation between habits and users.
    public class UserHabit
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int HabitId { get; set; }
        public Habit Habit { get; set; }    

        public bool Monday_doHabit { get; set; } 
        public bool Tuesday_doHabit { get; set; }
        public bool Wednesday_doHabit { get; set; }
        public bool Thursday_doHabit { get; set; }
        public bool Friday_doHabit { get; set; }
        public bool Saturday_doHabit { get; set; }
        public bool Sunday_doHabit { get; set; }
    }
}
