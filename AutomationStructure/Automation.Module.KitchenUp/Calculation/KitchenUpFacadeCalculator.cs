using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUpOneFacade.Calculation
{
    [Serializable]
    internal class KitchenUpFacadeCalculator
    {
        public void CalculateFacadeDimensions(Facades facades, Dimensions dimensions)
        {
            facades.Records[0].HorizontalDimension = dimensions.Width - 4;
            facades.Records[0].VerticalDimension = dimensions.Height - 4;
        }

        public void CalculateModuleDimensions(Facades facades, Dimensions dimensions)
        {
            dimensions.Width = facades.Records[0].HorizontalDimension + 4;
            dimensions.Height = facades.Records[0].VerticalDimension + 4;
        }
    }
}