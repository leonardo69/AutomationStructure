using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp.Calculation
{
    [Serializable]
    class KitchenUpFacadeCalculator
    {
        public void CalculateFacadeDimensions(Facades facades, Dimensions dimensions, string formula, int index)
        {
            if (formula == "F1-01-0001")
            {
                facades.Records[index].HorizontalDimension = dimensions.Width - 4;
                facades.Records[index].VerticalDimension = dimensions.Height - 4;
            }
        }
        public void CalculateModuleDimensions(Facades facades, Dimensions dimensions, string formula)
        {
            if (formula == "F1-01-0001")
            {
                dimensions.Width = facades.Records[0].HorizontalDimension + 4;
                dimensions.Height = facades.Records[0].VerticalDimension + 4;
            }
        }
    }
}
