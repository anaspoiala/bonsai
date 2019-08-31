using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class MealPlan
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<PlannedRecipe> PlannedRecipes { get; set; }
        //public long MealPlanHistoryId { get; set; }
        //public MealPlanHistory MealPlanHistory { get; set; }
    }
}
