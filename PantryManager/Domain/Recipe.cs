using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Item> Ingredients { get; set; }
        public List<string> Steps { get; set; }
    }
}
