using System.Reflection;

namespace Automation.Infrastructure.GlobalSettings
{

    public static class GeneralFurnitureDimensionVariables
    {
        public static int ExtraKant { get; set; }
        public static int HingeCount { get; set; }
        public static int ShelfHolderCount { get; set; }
        public static int ShelfSkrewCount { get; set; }

        static GeneralFurnitureDimensionVariables()
        {
            ExtraKant = 100;
            // HingeCount = 8;
            // ShelfHolderCount = 4;
            // ShelfSkrewCount = 4;
        }

        public static int[] Values = { 10, 20, 30, 40, 50, 100, 150, 200, 250, 300 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(GeneralFurnitureDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }


    public static class GeneralCutDimensionVariables
    {
        public static int BackPanelGrooveDepth { get; set; }
        public static double BackPanelGrooveWidth { get; set; }
        public static int BackPanelGrooveEdgeIndent { get; set; }
        public static int SlotSpaceUpmBackSlot { get; set; }
        public static int HolderCutUp { get; set; }
        public static int HolderCutSide { get; set; }

        static GeneralCutDimensionVariables()
        {
            BackPanelGrooveDepth = 100;
            BackPanelGrooveWidth = 8;
            BackPanelGrooveEdgeIndent = 4;
            SlotSpaceUpmBackSlot = 4;
            HolderCutUp = 3;
            HolderCutSide = 4;
        }

        public static int[] Values = { 5,6,7,8,9,10,11,12,13,14,15 };
        public static double[] WidthValues = { 3, 3.5,4,4.5,5,6,7,8 };
        public static double[] GrooveValues = {10,12,14,16,18,20,22 };
        public static double[] UpmValues = {0,1,2,3,4};
        public static double[] CutUpValues = {};
        public static double[] CutSideValues = {};

        public static void SetValue(string name, int value)
        {
            var type = typeof(GeneralCutDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class GeneralMaterialDimensionVariables
    {
        public static int SawThick { get; set; }
        public static double DspCut { get; set; }
        public static int DspCutLeavingsDspCut { get; set; }

        static GeneralMaterialDimensionVariables()
        {
            SawThick = 5;
            DspCut = 1.4;
            // DspCutLeavingsDspCut = 4;
        }

        public static int[] SawValues = { 2,3,4,5,6,7 };
        public static double[] CutValues = { 1.2,1.3,1.4,1.5,1.6,1.7,1.8,1.9,2 };
        public static int[] CutLeavingValues = {};

        public static void SetValue(string name, int value)
        {
            var type = typeof(GeneralMaterialDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }



}
