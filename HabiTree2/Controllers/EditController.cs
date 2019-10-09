using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabiTree2.Data;
using HabiTree2.Models;
using HabiTree2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HabiTree2.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EditController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = FindSpecificUserByUserID();
            var pageInput = new EditViewModel();
            pageInput.AllHabits = _context.UserHabit.Include(x=>x.Habit).Where(x => x.AppUserId == userId).ToList();

            return View(pageInput);
        }

        public IActionResult Edit(int? id)
        {
            var userId = FindSpecificUserByUserID();
            var pageInput = new UserHabit();
            pageInput = _context.UserHabit.Include(x => x.Habit).First(x => x.AppUserId == userId && x.HabitId == id);
            //pageInput = _context.UserHabit.First(x => x.AppUserId == userId && x.HabitId == id);

            return View(pageInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, UserHabit userHabit)
        //public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Frequency")] Habit habit)

        //public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Frequency")] UserHabit userHabit)
        public async Task<IActionResult> Edit(int id, UserHabit modelFromView)

        {
            if (ModelState.IsValid)
            {
                var userId = FindSpecificUserByUserID();

                var originalHabit = _context.UserHabit.Include(x => x.Habit).First(x => x.AppUserId == userId && x.HabitId == id);

                originalHabit.Monday_doHabit = modelFromView.Monday_doHabit;
                originalHabit.Tuesday_doHabit = modelFromView.Tuesday_doHabit;
                originalHabit.Wednesday_doHabit= modelFromView.Wednesday_doHabit;
                originalHabit.Thursday_doHabit= modelFromView.Thursday_doHabit;
                originalHabit.Friday_doHabit= modelFromView.Friday_doHabit;
                originalHabit.Saturday_doHabit = modelFromView.Saturday_doHabit;
                originalHabit.Sunday_doHabit= modelFromView.Sunday_doHabit;

                originalHabit.Habit.Name = modelFromView.Habit.Name;
                originalHabit.Habit.Description = modelFromView.Habit.Description;

                //var originalHabit = _context.UserHabit.First(x => x.HabitId == id);
                //originalHabit.Habit.Name = userHabit.Habit.Name;
                //originalHabit.Habit.Description = userHabit.Habit.Description;
                //originalHabit.Monday_doHabit = userHabit.AllHabits.



                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelFromView);

        }

        public IActionResult Delete(int? id)
        {
            var userId = FindSpecificUserByUserID();

            var habit = _context.UserHabit.Include(x => x.Habit).First(x => x.AppUserId == userId && x.HabitId == id);
            return View(habit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = FindSpecificUserByUserID();

            var habit = _context.UserHabit.Include(x => x.Habit).First(x => x.AppUserId == userId && x.HabitId == id);

            _context.Remove(habit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
