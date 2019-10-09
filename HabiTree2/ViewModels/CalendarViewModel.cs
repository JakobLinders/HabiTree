using HabiTree2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.ViewModels
{

    public class HabitDetails
    {
        public int[] WeekStatuses { get; set; } = new int[7];
        public string HabitName { get; set; }
        public int habitId { get; set; }

        //public HabitDetails(string habitName, int[] weekStatuses)
        //{
        //    HabitName = habitName;
        //    WeekStatuses = weekStatuses;
        //}
    }
    public class CalendarViewModel
    {
        public int WeekNum { get; set; } = 1;
        public int Year { get; set; }
        public DateTime MondayDate { get; set; }
        public List<HabitDetails> habitsAndDetails { get; set; } = new List<HabitDetails>();

        //Inner object class-isch


        //public class HabitStats
        //{
        //    public string HabitName { get; set; }
        //    public int Mon { get; set; }
        //    public int Tue { get; set; }
        //    public int Wed { get; set; }
        //    public int Thu { get; set; }
        //    public int Fri { get; set; }
        //    public int Sat { get; set; }
        //    public int Sun { get; set; }
        //}
    }
    public static class DayCodes
    {
        public const int isNotPlanned = 0;
        public const int isVacant = 5;  
        public const int isDone = 6;
        public const int isMissed = 7;
    }

    //public enum DayStatus { Vacant, Done, Missed } hard to work with in db.
}
