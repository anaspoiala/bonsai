using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Tagging;

namespace Bonsai.Persistence.Model.Items
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public List<RecipeItem> RecipeItems { get; set; }
        public List<PantryItem> PantryItems { get; set; }

        public List<ItemTag> Tags { get; set; }
    }
}
