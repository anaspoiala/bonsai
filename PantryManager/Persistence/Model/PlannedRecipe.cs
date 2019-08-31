using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class PlannedRecipe
    {
        [Key]
        public long Id { get; set; }
        public DateTime PlannedDate { get; set; }
        public Domain.Enums.TimeOfDay PlannedTime { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }
    }
}
