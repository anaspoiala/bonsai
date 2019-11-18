using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Domain;

namespace Bonsai.WebAPI.ApiModel
{
    public class ItemAddModel
    {
        public string Name { get; set; }
        public Quantity Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

    public class ItemUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public Quantity Quantity { get; set; } 
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
