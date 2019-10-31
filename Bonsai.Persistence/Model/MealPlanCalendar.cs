using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class MealPlanCalendar
    {
        [Key]
        public long Id { get; set; }
        public List<MealPlan> MealPlans { get; set; }

        public long UserDataId { get; set; }
        public UserData UserData { get; set; }
    }
}
