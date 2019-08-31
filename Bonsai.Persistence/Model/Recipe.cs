using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class Recipe
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        //public List<Item> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public List<RecipeItem> ItemsInThisRecipe { get; set; }
        //public long RecipeCatalogId { get; set; }
        //public RecipeCatalog RecipeCatalog { get; set; }
    }
}
