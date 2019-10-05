using System.Drawing;
using Automation.Infrastructure;

namespace Automation.Module.KitchenDownOneFacade.Core
{
    public class Module
    {

        private const int FACADES_COUNT = 1;

        /// <summary>
        /// Иконка модуля
        /// </summary>
        public Image Icon { get; set; }
        public Image ResultsImage { get; set; }

        public string CalcMode;
        public  Dimensions Dimensions;
        public Facades Facades;
        public string ModuleAssembly;
        public string BackPanelAssembly;
        public string ShelfAssembly;
        public string ShelfsCount;
        public string DishDryer;
        public string Canopies;

        public Module()
        {
            Dimensions = new Dimensions();
            Icon = Properties.Resources.icon;
            ResultsImage = Properties.Resources.result;
            Facades = new Facades();
            Facades.InitFacadeRecords(FACADES_COUNT);
            ShelfsCount = "";
            DishDryer = "-";
            Canopies = "универс. (УХО)";
        }
    }
}
