using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenDownOneFacade.Calculation
{
    public class ShelfCalculator
    {
        public string ShelvesCount;
        public Dimensions Dimensions;

        public ShelfItem GetShelfItem()
        {
            var shelfsCount = CalculateShelfsCount();

            var item = new ShelfItem
            {
                Count = shelfsCount
            };

            var shelfThickness = CalculateShelfThickness();
            var sizeSpaceShelf = (Dimensions.Height - ModuleThickness.Plate * 2 -
                                  shelfsCount * shelfThickness) / (shelfsCount + 1);
            var dim = shelfThickness;
            item.Sizes.Add(dim);

            for (var i = 1; i < shelfsCount; i++)
            {
                dim += shelfThickness + sizeSpaceShelf;
                item.Sizes.Add(dim);
            }

            return item;
        }


        public int CalculateShelfsCount()
        {
            if (ShelvesCount == "нет")
                return 0;
            var begin = ShelvesCount.IndexOfAny("0123456789".ToCharArray());
            if (begin == -1)
                return 0;
            return int.Parse(ShelvesCount.Substring(begin, ShelvesCount.Length - begin));
        }


        public double CalculateShelfThickness()
        {
            if (ShelvesCount == "нет")
                return 0;
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return ModuleThickness.Plate;
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return 5;
            return 0;
        }


    }
}
