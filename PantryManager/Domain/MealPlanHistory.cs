using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class MealPlanHistory
    {
        public long Id { get; set; }
        public List<MealPlan> MealPlans { get; set; }

    }
}
