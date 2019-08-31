using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Model
{
    public class Pantry
    {
        [Key]
        public long Id { get; set; }
        public List<Item> Items { get; set; }

        public long UserDataId { get; set; }
        public UserData UserData { get; set; }
    }
}
