using System;
using Bonsai.Domain.Enums;

namespace Bonsai.Domain
{
    public class PlannedRecipe
    {
        public long Id { get; set; }
        public Recipe Recipe { get; set; }
        public DateTime PlannedDate { get; set; }
        public TimeOfDay PlannedTime { get; set; }
    }
}
