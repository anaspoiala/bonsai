using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bonsai.Persistence.Model.Accounts;

namespace Bonsai.Persistence.Model.Items
{
    public class Pantry
    {
        [Key]
        public long Id { get; set; }
        public List<PantryItem> Items { get; set; }

        public long UserDataId { get; set; }
        public UserData UserData { get; set; }
    }
}
