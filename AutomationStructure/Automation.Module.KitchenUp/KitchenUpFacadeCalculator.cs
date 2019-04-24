using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp
{
    [Serializable]
    class KitchenUpFacadeCalculator
    {
        public void CalculateFacadeDimentions(Facade _facade, Dimensions _dimentions, string formula, int index)
        {
            switch (formula)
            {
                case "F1-01-0001":

                    _facade._records[index].HorisontalDimension = _dimentions.Width - 4;
                    _facade._records[index].VerticalDimension = _dimentions.Height - 4;
                    break;
            }
        }
        public void CalculateModuleDimentions(Facade _facade, Dimensions _dimentions, string formula)
        {
            switch (formula)
            {
                case "F1-01-0001":

                    _dimentions.Width = _facade._records[0].HorisontalDimension + 4;
                    _dimentions.Height = _facade._records[0].VerticalDimension + 4;
                    break;
            }
        }
    }
}
