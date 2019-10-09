using HabiTree2.Data;
using HabiTree2.Models;
using HabiTree2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.Controllers
{
    public class AvatarController : Controller
    {
        private ApplicationDbContext _context;

        public AvatarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = FindSpecificUserByUserID();

            var toGetPoints = _context.UserHabit.Include(x => x.AppUser)
                                        .Where(x => x.AppUserId == userId)
                                        .First();
            var weekResults = _context.WeekResults.Include(x => x.userHabit)
                                                    .Where(x => x.userHabit.AppUserId == userId)
                                                    .ToList();

            int totalPoints = 0;
            foreach(WeekResult wr in weekResults)
            {
                int[] temp = new int[7];
                temp[0] = wr.Monday_StatusCode;
                temp[1] = wr.Tuesday_StatusCode;
                temp[2] = wr.Wednesday_StatusCode;
                temp[3] = wr.Thursday_StatusCode;
                temp[4] = wr.Friday_StatusCode;
                temp[5] = wr.Saturday_StatusCode;
                temp[6] = wr.Sunday_StatusCode;

                foreach(int i in temp)
                {
                    if(i == DayCodes.isDone)
                    {
                        totalPoints++;
                    } else if(i == DayCodes.isMissed)
                    {
                        totalPoints--;
                    }
                }
            }
            

            return View(totalPoints);
        }


        private int CalculateUserPoints()
        {
            return 0;
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
