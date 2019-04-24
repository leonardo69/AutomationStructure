namespace Automation.Model
{
    public static class ModuleThickness
    {

        public static double FrontModule { get; set; }
        public static double UpModule { get; set; }
        public static double DownModule { get; set; }
        public static double SideModule { get; set; }
        public static double BackModule { get; set; }
        public static double FrontShelf { get; set; }
        public static double SideShelf { get; set; }
        public static double BackShelf { get; set; }
        public static double Facade { get; set; }

        public static double BackPanel { get; set; }
        public static double Plate { get; set; }

        public static double InputPlateConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "10 мм":
                    result = 10;
                    break;
                case "16 мм":
                    result = 16;
                    break;
                case "18 мм":
                    result = 18;
                    break;
                case "20 мм":
                    result = 20;
                    break;
                case "22 мм":
                    result = 22;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputBackPanelConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "3,2 мм":
                    result = 3.2;
                    break;
                case "4 мм":
                    result = 4;
                    break;
                case "4,2 мм":
                    result = 4.2;
                    break;
                case "6 мм":
                    result = 6;
                    break;
                case "8 мм":
                    result = 8;
                    break;
                case "10 мм":
                    result = 10;
                    break;
                case "12 мм":
                    result = 12;
                    break;
                case "16 мм":
                    result = 16;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputFrontModuleConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.01;
                    break;
                case "0,5":
                    result = 0.5;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                case "0,4 (max)":
                    result = 0.01;
                    break;
                case "0,4...2 (оптим.)":
                    result = 2;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputUpModuleConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.01;
                    break;
                case "0,5":
                    result = 0.5;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                case "0,4 (max)":
                case "0,4...2 (оптим.)":
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputDownModuleConverter(string value)
        {
            return InputUpModuleConverter(value);
        }

        public static double InputSideModuleConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.01;
                    break;
                case "0,5":
                    result = 0.5;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                case "0,4 (max)":
                    result = 0.01;
                    break;
                case "0,4...2 (оптим.)":
                    result = 0;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputBackModuleConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                case "0,4 (стандарт)":
                case "0,5":
                case "1":
                case "2":
                case "0,4 (min)":
                    result = 0;
                    break;
                case "0,4 (max)":
                    result = 0.01;
                    break;
                case "0,4...2 (оптим.)":
                    result = 0;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputFrontShelfConverter(string value)
        {
            return InputFrontModuleConverter(value);
        }

        public static double InputSideShelfConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.01;
                    break;
                case "0,5":
                    result = 0.5;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                    result = 0;
                    break;
                case "0,4 (max)":
                case "0,4...2 (оптим.)":
                    result = 0.01;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public static double InputBackShelfConverter(string value)
        {
            return InputSideShelfConverter(value);
        }

        public static double InputFacadeConverter(string value)
        {
            double result = 0;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        static ModuleThickness()
        {
            SetAllSameValues("2");
            SetPlateThickness("10 мм");
            SetBackPanelThickness("нет");
        }

        public static void SetBackPanelThickness(string value)
        {
            BackPanel = InputBackPanelConverter(value);
        }

        public static void SetPlateThickness(string value)
        {
            Plate = InputPlateConverter(value);
        }

        public static void SetAllSameValues(string value)
        {
            FrontModule = InputFrontModuleConverter(value);
            UpModule = InputUpModuleConverter(value);
            DownModule = InputDownModuleConverter(value);
            SideModule = InputSideModuleConverter(value);
            BackModule = InputBackModuleConverter(value);
            FrontShelf = InputFrontShelfConverter(value);
            SideShelf = InputSideShelfConverter(value);
            BackShelf = InputBackShelfConverter(value);
            Facade = InputFacadeConverter(value);
        }
    }
}