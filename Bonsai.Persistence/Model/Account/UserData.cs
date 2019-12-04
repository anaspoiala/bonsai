using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Items;
using Bonsai.Persistence.Model.MealPlans;
using Bonsai.Persistence.Model.Recipes;
using Bonsai.Persistence.Model.Tagging;

namespace Bonsai.Persistence.Model.Accounts
{
    public class UserData
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public Pantry Pantry { get; set; }
        public RecipeCatalog RecipeCatalog { get; set; }
        public MealPlanCalendar MealPlanCalendar { get; set; }

        public long AccountId { get; set; }
        public UserAccount Account { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
