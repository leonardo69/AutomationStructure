using System.Collections.Generic;
using System.Linq;

namespace Automation.Module.KitchenUpOneFacade.Calculation
{
    public class ShelfItem
    {

        public int Count { get; set; }

        public List<double> Sizes { get; set; }

        public ShelfItem()
        {
            Sizes = new List<double>();
        }

        public object[] ConvertToDataRow()
        {
            var result = Sizes.Select(x => (object) x).ToArray();
            return result;
        }
    }
}
