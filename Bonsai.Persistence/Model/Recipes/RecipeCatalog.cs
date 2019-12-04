using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Accounts;

namespace Bonsai.Persistence.Model.Recipes
{
    public class RecipeCatalog
    {
        [Key]
        public long Id { get; set; }
        public List<Recipe> Recipes { get; set; }

        public long UserDataId { get; set; }
        public UserData UserData { get; set; }
    }
}
