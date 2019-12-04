using System;
using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class MealPlan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<PlannedRecipe> PlannedRecipes { get; set; } = new List<PlannedRecipe>();

    }
}
