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
        public float Amount { get; set; }
        public string MeasurementUnit { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

    public class ItemUpdateModel
    {
        public string Name { get; set; } 
        public float Amount { get; set; }
        public string MeasurementUnit { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
