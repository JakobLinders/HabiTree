using HabiTree2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabiTree2.ViewModels
{
    public class CreateViewModel
    {
        public Habit CreateHabit { get; set; }
        public bool MondayChecked { get; set; }
        public bool TuesdayChecked { get; set; }
        public bool WednesdayChecked { get; set; }
        public bool ThursdayChecked { get; set; }
        public bool FridayChecked { get; set; }
        public bool SaturdayChecked { get; set; }
        public bool SundayChecked { get; set; }

    }
}
