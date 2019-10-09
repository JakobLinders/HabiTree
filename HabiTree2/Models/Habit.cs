using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabiTree2.Models
{
    public class Habit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public List<UserHabit> UserHabits { get; set; }
    }
}