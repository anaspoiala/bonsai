using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public Domain.Quantity Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public List<RecipeItem> RecipesUsingThisItem { get; set; }
        //public long PantryId { get; set; }
        //public Pantry Pantry { get; set; }
    }
}
