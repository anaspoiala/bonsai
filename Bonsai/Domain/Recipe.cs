using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class Recipe : ITaggable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<RecipeItem> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
