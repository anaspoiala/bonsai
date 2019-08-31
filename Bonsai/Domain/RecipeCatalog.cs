using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Domain
{
    public class RecipeCatalog
    {
        public long Id { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}
