using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
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
        public MealPlanHistory MealPlanHistory { get; set; }

        public long AccountId { get; set; }
        public UserAccount Account { get; set; }
    }
}
