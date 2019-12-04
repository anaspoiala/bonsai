using Bonsai.Persistence.Model.Items;

namespace Bonsai.Persistence.Model.Tagging
{
    public class PantryItemTag
    {
        public long TagId { get; set; }
        public Tag Tag { get; set; }
        public long PantryItemId { get; set; }
        public PantryItem PantryItem { get; set; }
    }
}
