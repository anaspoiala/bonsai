using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Recipes;

namespace Bonsai.Persistence.Model.MealPlans
{
    public class MealPlan
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<PlannedRecipe> PlannedRecipes { get; set; }
    }
}
