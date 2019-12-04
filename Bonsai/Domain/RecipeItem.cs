using System.Collections.Generic;

namespace Bonsai.Domain
{
    /// <summary>
    /// Represents an item used in a recipe.
    /// </summary>
    public class RecipeItem
    {
        public long Id { get; set; }
        public Item Item { get; set; }
        public Quantity RequiredQuantity { get; set; } = new Quantity();

        /// <summary>
        /// A list of words describing the state of the item. 
        ///     E.g. "1 cup of rice, steamed", "1 onion, chopped"
        /// </summary>
        public List<string> Adjectives { get; set; } = new List<string>();
    }
}
