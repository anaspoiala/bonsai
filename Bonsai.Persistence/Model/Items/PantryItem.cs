using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Recipes;
using Bonsai.Persistence.Model.Tagging;

namespace Bonsai.Persistence.Model.Items
{
    public class PantryItem
    {
        [Key]
        public long Id { get; set; }
        public Domain.Quantity Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; }

        public List<PantryItemTag> Tags { get; set; }
    }
}
