using System;
using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class UserData
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Pantry Pantry { get; set; } = new Pantry();
        public RecipeCatalog RecipeCatalog { get; set; } = new RecipeCatalog();
        public MealPlanCalendar MealPlanCalendar { get; set; } = new MealPlanCalendar();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
