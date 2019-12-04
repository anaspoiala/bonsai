using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonsai.WebAPI.ApiModel
{
    public class RecipeAddModel
    {
        public string Name { get; set; }
        public List<RecipeItemAddModel> Ingredients { get; set; }
        public List<string> Steps { get; set; }
    }

    public class RecipeItemAddModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string MeasurementUnit { get; set; }
    }

    public class RecipeUpdateModel
    {

    }
}
