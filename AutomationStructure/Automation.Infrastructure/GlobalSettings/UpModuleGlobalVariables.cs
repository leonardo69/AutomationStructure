using System;
using System.Collections.Generic;
using System.Reflection;

namespace Automation.Infrastructure.GlobalSettings
{


    public static class UpModuleFacadesDimensionVariables
    {
        public static int LowByHeight { get; set; }
        public static int LowByWidth { get; set; }
        public static int GapBetweenFacadesByHeight { get; set; }
        public static int GapBetweenFacadesByWidth { get; set; }
        public static int GapBetweenBoxesByHeight { get; set; }
        public static int GapBetweenBoxesByWidth { get; set; }

        static UpModuleFacadesDimensionVariables()
        {
            LowByHeight = 4;
            LowByWidth = 8;
            GapBetweenFacadesByHeight = 4;
            GapBetweenFacadesByWidth = 4;
            GapBetweenBoxesByHeight = 4;
            GapBetweenBoxesByWidth = 4;
        }

        public static int[] Values = { 0,1,2,3,4,5,6,7,8,9,10};

        public static void SetValue(string name, int value)
        {
            var type = typeof(UpModuleFacadesDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }


    public static class UpModuleShelfsDimensionVariables
    {
        public static int ShelfDepth;
        public static int ShelfWidth;
        public static int GlassShelfDepth;

        static UpModuleShelfsDimensionVariables()
        {
            ShelfDepth = 5;
            ShelfWidth = 2;
            GlassShelfDepth = 3;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(UpModuleShelfsDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class UpModuleBackWallDimensionVariables
    {
        public static int BackHeight;
        public static int BackWidth;
        public static int BackDishesHeight;

        static UpModuleBackWallDimensionVariables()
        {
            BackHeight = 4;
            BackWidth = 4;
            BackDishesHeight = 4;
        }

        public static int[] Values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void SetValue(string name, int value)
        {
            var type = typeof(UpModuleBackWallDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }

    public static class UpModuleMountDimensionVariables
    {
        public static int MinMountPlank;
        public static int ModuleDepth;
        public static int MaxMountPlank;

        static UpModuleMountDimensionVariables()
        {
            MinMountPlank = 4;
            ModuleDepth = 4;
            MaxMountPlank = 4;
        }

        public static int[] MinMountPlankValues = {50,80,100,120,150};
        public static int[] ModuleDepthValues = {100,200,250,300,350,400};
        public static int[] MaxMountPlankValues = {100,150,200,250,300};

        public static void SetValue(string name, int value)
        {
            var type = typeof(UpModuleMountDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }


    public static class UpModuleBoxesDimensionVariables
    {
        public static DepthValue Depth;

        static UpModuleBoxesDimensionVariables()
        {
            Depth = new DepthValue
            {
                Type = DepthTypes.ByGuide
            };
        }


        public class DepthValue
        {
            public DepthTypes Type;
            public int? Value;
        }

        public enum DepthTypes
        {
            ByGuide,
            ByValue
        }

        public static Dictionary<DepthTypes, string> DepthTypesValues = new Dictionary<DepthTypes, string>
        { 
            { DepthTypes.ByGuide, "По направляющей"},
            { DepthTypes.ByValue, "По значению" }
        };

        public static int[] DepthValues = {-5, -10, -20, -30, -40, -50};

        public static void SetValue(string name, int value)
        {
            var type = typeof(UpModuleMountDimensionVariables);
            var property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
            if (property != null) property.SetValue(null, value);
        }
    }






}
