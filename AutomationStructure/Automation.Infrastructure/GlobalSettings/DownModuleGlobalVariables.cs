using System.Net.NetworkInformation;
using System.Reflection;

namespace Automation.Infrastructure.GlobalSettings
{

    public static class DownModuleFacadesDimensionVariables
    {
        public static int LowByHeight { get; set; }
        public static int LowByWidth  { get; set; }
        public static int GapBetweenFacadesByHeight { get; set; }
        public static int GapBetweenFacadesByWidth { get; set; }
        public static int GapBetweenBoxesByHeight { get; set; }
        public static int GapBetweenBoxesByWidth { get; set; }

        static DownModuleFacadesDimensionVariables()
        {
            LowByHeight = 4;
            LowByWidth = 4;
            GapBetweenFacadesByHeight = 4;
            GapBetweenFacadesByWidth = 4;
            GapBetweenBoxesByHeight = 4;
            GapBetweenBoxesByWidth = 4;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleFacadesDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleShelfsDimensionVariables
    {
        public static int ShelfDepth { get; set; }
        public static int ShelfWidth { get; set; }
        public static int GlassShelfDepth { get; set; }

        static DownModuleShelfsDimensionVariables()
        {
            ShelfDepth = 5;
            ShelfWidth = 5;
            GlassShelfDepth = 3;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleShelfsDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleBackwallDimensionVariables
    {
        public static int BackHeight { get; set; }
        public static int BackWidth { get; set; }
        public static int BackSlot { get; set; }

        static DownModuleBackwallDimensionVariables()
        {
            BackHeight = 5;
            BackWidth = 5;
            BackSlot = 3;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static int[] SlotValues = { 0, 1, 2, 3, 4 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleBackwallDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleBoxDimensionVariables
    {
        public static int Depth { get; set; }
        public static int DepthSpace { get; set; }
        public static bool FacaseOnBox { get; set; }
        public static int GapUpBox { get; set; }
        public static int GapDownBox { get; set; }
        public static int GapForFacade { get; set; }
        public static int GapDownBoxGuide { get; set; }

        static DownModuleBoxDimensionVariables()
        {
            Depth = -5;
            DepthSpace = 10;
            FacaseOnBox = false;
            GapUpBox = 10;
            GapDownBox = 10;
            GapForFacade = 10;
            GapDownBoxGuide = 3;
        }

        public static int[] Values = { -5, -10, -20, -30, -40, -50};
        public static int[] DepthValues = { 3, 5, 10, 15, 20, 25, 30, 35, 40};
        public static bool[] BoolValues = {true, false};
        public static int[] GapValues = { 5,10,15,20};


        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleBoxDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleSideDimensionVariables
    {
        public static int GapDownAndSide { get; set; }
        public static int PlinthHorSize { get; set; }
        public static int PlinthVertSize { get; set; }

        static DownModuleSideDimensionVariables()
        {
            GapDownAndSide = 5;
            PlinthHorSize = 5;
            PlinthVertSize = 3;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static int[] HorValues = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

        public static int[] VerValues = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 120, 140, 160 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleSideDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleUpPanelDimensionVariables
    {
        public static int MinWidth { get; set; }
        public static int MinDepth { get; set; }
        public static int PlankWidth { get; set; }

        static DownModuleUpPanelDimensionVariables()
        {
            MinWidth = 300;
            MinDepth = 300;
            PlankWidth = 100;
        }

        public static int[] Values = { 200, 250, 300, 400, 500, 600, 700, 800,900, 1000 };

        public static int[] PlankhValues = { 50, 80, 100, 120, 150 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleUpPanelDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleMountDimensionVariables
    {
        public static int MinPlankMount { get; set; }
        public static int ModuleDepth { get; set; }
        public static int MaxPlankMount { get; set; }

        static DownModuleMountDimensionVariables()
        {
            MinPlankMount = 100;
            ModuleDepth = 300;
            MaxPlankMount = 100;
        }

        public static int[] Values = { 50, 80, 100, 120, 150 };

        public static int[] DepthValues = { 100, 200, 250, 300, 350, 400, 500, 600, 700 };

        public static int[] PlankhValues = { 100, 150, 200, 250, 300 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleMountDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class DownModuleCapDimensionVariables
    {
        public static int UpPedestal { get; set; }
        public static int SidePedestal { get; set; }

        static DownModuleCapDimensionVariables()
        {
            UpPedestal = 5;
            SidePedestal = 2;
        }

        public static int[] Values = { 0,1,2,3,4,5,6,7,8,9,10 };
        

        public static void SetValue(string name, int value)
        {
            var type = typeof(DownModuleCapDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

}
