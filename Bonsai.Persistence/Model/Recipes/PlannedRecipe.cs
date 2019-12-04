using System;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.MealPlans;

namespace Bonsai.Persistence.Model.Recipes
{
    public class PlannedRecipe
    {
        public long Id { get; set; }
        public DateTime PlannedDate { get; set; }
        public Domain.Enums.TimeOfDay PlannedTime { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }
    }
}
