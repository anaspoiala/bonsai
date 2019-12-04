using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class Recipe : ITaggable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<RecipeItem> Ingredients { get; set; } = new List<RecipeItem>();
        public List<string> Steps { get; set; } = new List<string>();

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
