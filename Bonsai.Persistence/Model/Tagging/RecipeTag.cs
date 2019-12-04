using Bonsai.Persistence.Model.Recipes;

namespace Bonsai.Persistence.Model.Tagging
{
    public class RecipeTag
    {
        public long TagId { get; set; }
        public Tag Tag { get; set; }
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
