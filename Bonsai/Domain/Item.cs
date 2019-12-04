using System.Collections.Generic;

namespace Bonsai.Domain
{
    /// <summary>
    /// Represents a generic item.
    /// </summary>
    public class Item : ITaggable
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
