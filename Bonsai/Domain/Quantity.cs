using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Domain.Enums;

namespace Bonsai.Domain
{
    public class Quantity
    {
        public float Amount { get; set; }
        public MeasurementUnit Unit { get; set; }

        public override string ToString()
        {
            return $"{Amount}{Unit}";
        }
    }
}
