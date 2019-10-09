using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HabiTree2.Data;
using HabiTree2.Models;
using HabiTree2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabiTree2.Controllers
{
    public class CalendarsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public CalendarsController(ApplicationDbContext context, SignInManager<AppUser> SignInManager, UserManager<AppUser> UserManager)
        {
            _context = context;
            _signInManager = SignInManager;
            _userManager = UserManager;
        }
        public IActionResult SaveStats(CalendarViewModel input)
        {
            var userId = FindSpecificUserByUserID();
            input.MondayDate = new DateTime(input.MondayDate.Year, input.MondayDate.Month, input.MondayDate.Day);


            foreach(var habit in input.habitsAndDetails)
            {
                var y = _context.WeekResults.FirstOrDefault(x => x.MondayDate == input.MondayDate &&
                                            x.userHabit.AppUserId == userId &&
                                            x.userHabit.HabitId == habit.habitId);
                if(y != null)
                {
                    y.Monday_StatusCode = habit.WeekStatuses[0];
                    y.Tuesday_StatusCode = habit.WeekStatuses[1];
                    y.Wednesday_StatusCode= habit.WeekStatuses[2];
                    y.Thursday_StatusCode= habit.WeekStatuses[3];
                    y.Friday_StatusCode = habit.WeekStatuses[4];
                    y.Saturday_StatusCode = habit.WeekStatuses[5];
                    y.Sunday_StatusCode= habit.WeekStatuses[6];

                }
                else
                {
                    //Single hprdare än first , som är hårdare än firstordefault.
                    var userHabit = _context.UserHabit.Single(x => x.AppUserId == userId && x.HabitId == habit.habitId);
                    _context.WeekResults.Add(new WeekResult()
                    {
                        Monday_StatusCode = habit.WeekStatuses[0],
                        Tuesday_StatusCode = habit.WeekStatuses[1],
                        Wednesday_StatusCode = habit.WeekStatuses[2],
                        Thursday_StatusCode = habit.WeekStatuses[3],
                        Friday_StatusCode = habit.WeekStatuses[4],
                        Saturday_StatusCode = habit.WeekStatuses[5],
                        Sunday_StatusCode = habit.WeekStatuses[6],
                        MondayDate = input.MondayDate,
                        userHabit = userHabit
                    }) ;
                }

            }

            //for (int i = 0; i < input.habitsAndDetails.Count; i++)
            //{
            //    let userHabits = _context.
            //        _context.    input.habitsAndDetails[i].HabitName
            //}

            _context.SaveChanges();
            //originalHabit.Tuesday_doHabit = modelFromView.Tuesday_doHabit;
            //originalHabit.Wednesday_doHabit = modelFromView.Wednesday_doHabit;
            //originalHabit.Thursday_doHabit = modelFromView.Thursday_doHabit;
            //originalHabit.Friday_doHabit = modelFromView.Friday_doHabit;
            //originalHabit.Saturday_doHabit = modelFromView.Saturday_doHabit;
            //originalHabit.Sunday_doHabit = modelFromView.Sunday_doHabit;

            //originalHabit.Habit.Name = modelFromView.Habit.Name;
            //originalHabit.Habit.Description = modelFromView.Habit.Description;

            //var originalHabit = _context.UserHabit.First(x => x.HabitId == id);
            //originalHabit.Habit.Name = userHabit.Habit.Name;
            //originalHabit.Habit.Description = userHabit.Habit.Description;
            //originalHabit.Monday_doHabit = userHabit.AllHabits.



            //await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Index(DateTime? mondaydate)
        {
            CalendarViewModel calendarVMToReturn = new CalendarViewModel();

            if (mondaydate == null)
            {
                SetMondayDate();
            }

            calendarVMToReturn.MondayDate = (DateTime)mondaydate;
            calendarVMToReturn.Year = ((DateTime)mondaydate).Year;
            calendarVMToReturn.WeekNum = GetWeekNumber((DateTime)mondaydate);

            //Get all user-habits for a particular userID.
            var userId = FindSpecificUserByUserID();


            List<UserHabit> DbUserHabits = _context.UserHabit
                                                .Include(x => x.Habit)
                                                .Where(x => x.AppUserId == userId)
                                                .ToList();

            calendarVMToReturn.habitsAndDetails = new List<HabitDetails>();
            DateTime temp = (DateTime)mondaydate;

            foreach(UserHabit uh in DbUserHabits)
            {

                var res = _context.WeekResults.Where(x =>   x.MondayDate.Date == temp.Date &&
                                                            x.userHabit.AppUserId == userId &&
                                                            uh.HabitId == x.userHabit.HabitId)
                                               .FirstOrDefault();

                
                int[] weekStatusCodes = new int[7];

                if(res == null)
                {
                    if (uh.Monday_doHabit)
                        weekStatusCodes[0] = DayCodes.isVacant;
                    else
                        weekStatusCodes[0] = DayCodes.isNotPlanned;

                    if (uh.Tuesday_doHabit)
                        weekStatusCodes[1] = DayCodes.isVacant;
                    else
                        weekStatusCodes[1] = DayCodes.isNotPlanned;

                    if (uh.Wednesday_doHabit)
                        weekStatusCodes[2] = DayCodes.isVacant;
                    else
                        weekStatusCodes[2] = DayCodes.isNotPlanned;

                    if (uh.Thursday_doHabit)
                        weekStatusCodes[3] = DayCodes.isVacant;
                    else
                        weekStatusCodes[3] = DayCodes.isNotPlanned;

                    if (uh.Friday_doHabit)
                        weekStatusCodes[4] = DayCodes.isVacant;
                    else
                        weekStatusCodes[4] = DayCodes.isNotPlanned;

                    if (uh.Saturday_doHabit)
                        weekStatusCodes[5] = DayCodes.isVacant;
                    else
                        weekStatusCodes[5] = DayCodes.isNotPlanned;

                    if (uh.Sunday_doHabit)
                        weekStatusCodes[6] = DayCodes.isVacant;
                    else
                        weekStatusCodes[6] = DayCodes.isNotPlanned;
                }
                else
                {
                    if (uh.Monday_doHabit)
                        weekStatusCodes[0] = res.Monday_StatusCode;
                    else
                        weekStatusCodes[0] = DayCodes.isNotPlanned;

                    if (uh.Tuesday_doHabit)
                        weekStatusCodes[1] = res.Tuesday_StatusCode;
                    else
                        weekStatusCodes[1] = DayCodes.isNotPlanned;

                    if (uh.Wednesday_doHabit)
                        weekStatusCodes[2] = res.Wednesday_StatusCode;
                    else
                        weekStatusCodes[2] = DayCodes.isNotPlanned;

                    if (uh.Thursday_doHabit)
                        weekStatusCodes[3] = res.Thursday_StatusCode;
                    else
                        weekStatusCodes[3] = DayCodes.isNotPlanned;

                    if (uh.Friday_doHabit)
                        weekStatusCodes[4] = res.Friday_StatusCode;
                    else
                        weekStatusCodes[4] = DayCodes.isNotPlanned;

                    if (uh.Saturday_doHabit)
                        weekStatusCodes[5] = res.Saturday_StatusCode;
                    else
                        weekStatusCodes[5] = DayCodes.isNotPlanned;

                    if (uh.Sunday_doHabit)
                        weekStatusCodes[6] = res.Sunday_StatusCode;
                    else
                        weekStatusCodes[6] = DayCodes.isNotPlanned;
                }

                calendarVMToReturn.habitsAndDetails.Add(
                    new HabitDetails
                    {
                        HabitName = uh.Habit.Name,
                        WeekStatuses = weekStatusCodes,
                        habitId = uh.HabitId
                    }
                );
                
            }
            
             
            return View(calendarVMToReturn);

            //Local Methods
            void SetMondayDate()
            {
                DateTime now = DateTime.UtcNow;

                if (now.DayOfWeek != DayOfWeek.Monday)
                {
                    mondaydate = now.AddDays(-(int)now.DayOfWeek + 1);
                }
                else
                {
                    mondaydate = now;
                }
            }

        }




        public int GetWeekNumber(DateTime m)
        {
            CultureInfo ciCurr = new CultureInfo("sv-SE"); // CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(m, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

            //CalendarVM x = new CalendarVM();
            //HabitWeek y = new HabitWeek();
            //HabitWeek z = new HabitWeek();
            //if (weeknum == 0)
            //    x.WeekNum = 52;
            //else if (weeknum == 53)
            //    x.WeekNum = 1;
            //else
            //    x.WeekNum = weeknum;

            //x.HabitsWeeks = new List<Models.HabitWeek>();

        //private List<Habit> _createMockupHabits()
        //{
        //    //create 5 mockup-habits
        //    //give them names
        //    //Generate schedule (random)
        //    //Give them schedules
        //    //return the mockup habits.

        //    List<Habit> mockHabitsList = new List<Habit>();
        //    string[] habitNamesList = { "Make bed", "chop lumber", "take the stairs", "eat spaghetti", "plant potatoes" };

        //    return mockHabitsList;

        //    //Local function


        //}



        public string FindSpecificUserByUserID()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            return userId;
        }

    }
}
