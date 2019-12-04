using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Recipes;

namespace Bonsai.Persistence.Model.Items
{
    public class RecipeItem
    {
        public long Id { get; set; }
        public Domain.Quantity RequiredQuantity { get; set; }
        public List<string> Adjectives { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
