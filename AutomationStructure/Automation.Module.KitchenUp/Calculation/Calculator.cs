using System.Collections.Generic;
using Automation.Infrastructure;
using Automation.Module.KitchenUp.Calculation;

namespace Automation.Module.KitchenUpOneFacade.Calculation
{
    public class Calculator
    {
        private readonly DetailsCalculator _detailsCalculator;
        private readonly FurnitureCalculator _furnitureCalculator;
        private readonly ShelfCalculator _shelfCalculator;
        private readonly LoopsCalculator _loopsCalculator;

        public Calculator(Dimensions dimensions, Facades facades, string shelfAssembly, string shelvesCount,
            string backPanelAssembly, string canopies)
        {
            _detailsCalculator = new DetailsCalculator
            {
                Dimensions = dimensions,
                BackPanelAssembly = backPanelAssembly,
                Facades = facades,
                ShelfAssembly = shelfAssembly,
                ShelvesCount = shelvesCount,
                Canopies = canopies
            };

            _furnitureCalculator = new FurnitureCalculator
            {
                Dimensions = dimensions,
                BackPanelAssembly = backPanelAssembly,
                Canopies = canopies,
                Facades = facades,
                ShelfAssembly = shelfAssembly,
                ShelvesCount = shelvesCount
            };

            _shelfCalculator = new ShelfCalculator
            {
                Dimensions = dimensions,
                ShelvesCount = shelvesCount
            };

            _loopsCalculator = new LoopsCalculator
            {
                Dimensions = dimensions
            };

        }


        public List<DetailsItem> GetDetails()
        {
            return _detailsCalculator.GetDetails();
        }

        public ShelfItem GetShelfItem()
        {
            return _shelfCalculator.GetShelfItem();
        }


        public FurnitureItem GetFurnitureItem()
        {
            return _furnitureCalculator.GetFurnitureItem();
        }

        public List<LoopsItem> GetLoopsItem()
        {
            return _loopsCalculator.GetLoopsItems();
        }

    }
}