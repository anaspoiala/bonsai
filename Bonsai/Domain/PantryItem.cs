using System;
using System.Collections.Generic;

namespace Bonsai.Domain
{
    /// <summary>
    /// Represents an item owned by an user.
    /// </summary>
    public class PantryItem : ITaggable
    {
        public long Id { get; set; }
        public Item Item { get; set; }
        public Quantity Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public List<Tag> Tags { get; set; }
    }
}

