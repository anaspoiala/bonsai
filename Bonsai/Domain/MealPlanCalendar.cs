using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class MealPlanCalendar
    {
        public long Id { get; set; }
        public List<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
    }
}
