using System.Collections.Generic;

namespace Bonsai.Domain
{
    /// <summary>
    /// Interface describing an object that can be searched by tag.
    /// </summary>
    public interface ITaggable
    {
        List<Tag> Tags { get; set; }
    }
}
