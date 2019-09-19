using System.Collections.Generic;
using Automation.Infrastructure;
using Automation.Module.KitchenUp.Calculation;

namespace Automation.Module.KitchenUpOneFacade.Calculation
{
    public class LoopsCalculator
    {

        public Dimensions Dimensions;

        public List<LoopsItem> GetLoopsItems()
        {
            var items = new List<LoopsItem>
            {
                new LoopsItem
                {
                    Name = "на фасаде",
                    FirstLoop = L1(),
                    SecondLoop = L2(),
                    ThirdLoop = L3()
                },
                new LoopsItem
                {
                    Name = "на модуле",
                    FirstLoop = ML1(),
                    SecondLoop = Ml2(),
                    ThirdLoop = Ml3()
                }
            };

            return items;
        }


        private int L1()
        {
            return 100;
        }

        private double ML1()
        {
            return 100 + 2;
        }

        private double L2()
        {
            return Dimensions.Height - 100;
        }

        private double Ml2()
        {
            return Dimensions.Height - 100 - 2;
        }

        private double L3()
        {
            return (Dimensions.Height - 4) / 2;
        }

        private double Ml3()
        {
            return Dimensions.Height / 2;
        }
    }
}
