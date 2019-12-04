using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Persistence.Model.Items;

namespace Bonsai.Persistence.Model.Tagging
{
    public class ItemTag
    {
        public long TagId { get; set; }
        public Tag Tag { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
