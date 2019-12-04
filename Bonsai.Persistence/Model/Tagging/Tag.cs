using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Accounts;

namespace Bonsai.Persistence.Model.Tagging
{
    public class Tag
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long UserDataId { get; set; }
        public UserData UserData { get; set; }

        public List<ItemTag> ItemTags { get; set; }
        public List<PantryItemTag> PantryItemTags { get; set; }
        public List<RecipeTag> RecipeTags { get; set; }
    }
}
