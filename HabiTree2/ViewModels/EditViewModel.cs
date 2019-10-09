using HabiTree2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.ViewModels
{
    public class EditViewModel
    {
        public Habit Habit { get; set; }
        public List <UserHabit> AllHabits { get; set; }
    }
}
