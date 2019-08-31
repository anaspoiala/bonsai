using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.Persistence.Model
{
    public class RecipeItem
    {
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
