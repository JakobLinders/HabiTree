using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabiTree2.Data;
using HabiTree2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HabiTree2.ViewModels;

namespace HabiTree2.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel userInput)
        {
            if (ModelState.IsValid)
             {
                var userId = FindSpecificUserByUserID();

                //skapar en userhabit
                var newUserHabit = new UserHabit();
                newUserHabit.AppUserId = userId;
                newUserHabit.Habit = userInput.CreateHabit;

                newUserHabit.Monday_doHabit     = userInput.MondayChecked;
                newUserHabit.Tuesday_doHabit    = userInput.TuesdayChecked;
                newUserHabit.Wednesday_doHabit  = userInput.WednesdayChecked;
                newUserHabit.Thursday_doHabit   = userInput.ThursdayChecked;
                newUserHabit.Friday_doHabit     = userInput.FridayChecked;
                newUserHabit.Saturday_doHabit   = userInput.SaturdayChecked;
                newUserHabit.Sunday_doHabit     = userInput.SundayChecked;

                //if(userInput.MondayChecked)
                //    newUserHabit.MondayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.MondayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.TuesdayChecked)
                //    newUserHabit.TuesdayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.TuesdayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.WednesdayChecked)
                //    newUserHabit.WednesdayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.WednesdayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.ThursdayChecked)
                //    newUserHabit.ThursdayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.ThursdayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.FridayChecked)
                //    newUserHabit.FridayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.FridayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.SaturdayChecked)
                //    newUserHabit.SaturdayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.SaturdayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;

                //if (userInput.SundayChecked)
                //    newUserHabit.SundayStatus = CalendarViewModel.HabitDetails.Day.isVacant;
                //else
                //    newUserHabit.SundayStatus = CalendarViewModel.HabitDetails.Day.isNotPlanned;


                _context.Add(newUserHabit);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                
            }
            return View("Index");
        }


        public IActionResult Seed()
        {
            _context.Habit.RemoveRange(_context.Habit);

            _context.Habit.Add(new Habit
            {
                Name = "Make the bed",
                Description = "I should make my bed in the morning",
                //Frequency = Frequency.Friday
            });

            _context.Habit.Add(new Habit
            {
                Name = "Excercise",
                Description = "I should go to the gym and excercise",
                //Frequency = Frequency.Monday
            });

            _context.Habit.Add(new Habit
            {
                Name = "Candy free",
                Description = "I should not eat candy",
                //Frequency = Frequency.Saturday
            });

            _context.SaveChanges();
            ViewData["Message"] = "Seeding done";
            return View("Index");
        }

        public string FindSpecificUserByUserID()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            return userId;
        }
    }
}