using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class UserData
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Pantry Pantry { get; set; }
        public RecipeCatalog RecipeCatalog { get; set; }
        public MealPlanHistory MealPlanHistory { get; set; }
    }
}
