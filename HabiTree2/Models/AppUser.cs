using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.Models
{

    public class AppUser : IdentityUser
    {
        public List<UserHabit> UserHabits { get; set; }

        public int UserPoints { get; set; }
    }
}
