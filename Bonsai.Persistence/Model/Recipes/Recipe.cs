using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Items;
using Bonsai.Persistence.Model.Tagging;

namespace Bonsai.Persistence.Model.Recipes
{
    public class Recipe
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public List<string> Steps { get; set; }

        public List<RecipeItem> RecipeItems { get; set; }
        public List<PlannedRecipe> PlannedRecipes { get; set; }

        public List<RecipeTag> Tags { get; set; }
    }
}
