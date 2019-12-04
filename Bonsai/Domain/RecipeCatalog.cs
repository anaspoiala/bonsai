using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class RecipeCatalog
    {
        public long Id { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

    }
}
