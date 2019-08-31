using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class Pantry
    {
        public long Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
