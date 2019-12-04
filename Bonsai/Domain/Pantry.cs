using System.Collections.Generic;

namespace Bonsai.Domain
{
    public class Pantry
    {
        public long Id { get; set; }
        public List<PantryItem> Items { get; set; } = new List<PantryItem>();
    }
}
