using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Quantity Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}

