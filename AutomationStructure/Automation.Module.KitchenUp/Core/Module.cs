using System.Drawing;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUpOneFacade.Core
{
    public class Module
    {

        private const int FACADES_COUNT = 1;

        public string Scheme { get; set; }

        /// <summary>
        /// Имя модуля
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Иконка
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// Большое изображение в отчёте
        /// </summary>
        public Image ResultImage { get; set; }

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
            ResultImage = Properties.Resources.result;
            Facades = new Facades();
            Facades.InitFacadeRecords(FACADES_COUNT);
            ShelfsCount = "";
            DishDryer = "-";
            Canopies = "универс. (УХО)";
        }
    }
}
