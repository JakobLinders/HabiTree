using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.Models
{
    public class WeekResult
    {
        public int Id { get; set; }
        public DateTime MondayDate { get; set; }
        public UserHabit userHabit { get; set; }

        public int Monday_StatusCode { get; set; }
        public int Tuesday_StatusCode { get; set; }
        public int Wednesday_StatusCode { get; set; }
        public int Thursday_StatusCode { get; set; }
        public int Friday_StatusCode { get; set; }
        public int Saturday_StatusCode { get; set; }
        public int Sunday_StatusCode { get; set; }
    }
}
