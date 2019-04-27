using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp
{
    [Serializable]
    class KitchenUpFacadeCalculator
    {
        public void CalculateFacadeDimensions(Facade facade, Dimensions dimensions, string formula, int index)
        {
            if (formula == "F1-01-0001")
            {
                facade._records[index].HorisontalDimension = dimensions.Width - 4;
                facade._records[index].VerticalDimension = dimensions.Height - 4;
            }
        }
        public void CalculateModuleDimensions(Facade facade, Dimensions dimensions, string formula)
        {
            if (formula == "F1-01-0001")
            {
                dimensions.Width = facade._records[0].HorisontalDimension + 4;
                dimensions.Height = facade._records[0].VerticalDimension + 4;
            }
        }
    }
}
