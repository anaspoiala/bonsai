using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Accounts;

namespace Bonsai.Persistence.Model.MealPlans
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
