using Automation.Infrastructure;

namespace Automation.Module.KitchenUp.Core
{
    public class Module
    {

        private const int FACADES_COUNT = 1;

        public string Number { get; set; }
        public string IconPath { get; set; }
        public string Scheme { get; set; }

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
            Facades = new Facades();
            Facades.InitFacadeRecords(FACADES_COUNT);
            ShelfsCount = "";
            DishDryer = "-";
            Canopies = "универс. (УХО)";
        }
    }
}
