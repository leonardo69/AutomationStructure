using System;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp.Calculation
{
    public class FurnitureCalculator
    {
        public Dimensions Dimensions;
        public Facades Facades;
        public string ShelfAssembly;
        public string ShelvesCount;

        public string BackPanelAssembly { get; set; }

        /// <summary>
        ///     Навес на стену
        /// </summary>
        public string Canopies { get; set; }


        public FurnitureItem GetFurnitureItem()
        {
            var furnitureItem = new FurnitureItem
            {
                LoopsCount = Mat1(),
                ModuleCount = Mat2(),
                ShelfsCount = Mat2(),
                HandlesCount = 1,
                CanopyCount = 2,
                Plate = Mat6(),
                Kant = Mat7(),
                BackPanel = Mat8()
            };

            return furnitureItem;
        }

        private int Mat1()
        {
            if (Facades.Records.Count == 0)
                return 0;
            if (Facades.Records[0].Type == "нет")
                return 0;
            var height = Facades.Records[0].VerticalDimension;
            if (height < 900)
                return 2;
            if (height < 1600)
                return 3;
            if (height < 2000)
                return 4;
            if (height < 2400)
                return 5;
            return 0;
        }

        private int Mat2()
        {
            var result = 0;
            switch (ShelfAssembly)
            {
                case "конфирмат":
                case "эксцентрик":
                    if (Dimensions.Depth < 499)
                        result = 8;
                    else
                        result = 12;
                    break;
                case "нагель":
                    if (Dimensions.Depth < 499)
                        result = 12;
                    else
                        result = 16;
                    break;
                case "конфирмат + нагель":
                case "эксцентрик + нагель":
                    if (Dimensions.Depth < 499)
                        result = 8;
                    else
                        result = 16;
                    break;
            }

            return result;
        }


        private int Mat7()
        {
            return 0;
        }

        private double Mat8()
        {
            if (BackPanelAssembly == "ЛДСП внутрь")
                return 0;
            return FL7() * FW7() * FN7() * 0.001;
        }


        private double Mat6()
        {
            double ldspShelfs = 0;
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                ldspShelfs = Fl3() * Fw3() * 0.001 * Fn3();
            double backPanel = 0;
            if (BackPanelAssembly == "ЛДСП внутрь")
                backPanel = FL7() * FW7() * 0.001 * FN7();
            double facades = 0;
            if (Facades.Records.Count != 0)
                if (Facades.Records[0].Type != "нет" &&
                    (Facades.Records[0].Material == "ЛДСП вертик. фактура" ||
                     Facades.Records[0].Material == "ЛДСП гориз. фактура"))
                    facades = FL5() * FW5() * 0.001 * FN5();
            return Fl1() * Fw1() * 0.001 * FN1() + Fl2() * Fw2() * 0.001 * FN2() + ldspShelfs + backPanel + facades;
        }


        private double Fl3()
        {
            if (ShelvesCount == "нет")
                return 0;
            if (ShelfAssembly == "полкодержатель" &&
                ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return Dimensions.Width - (ModuleThickness.Plate * 2 + ModuleThickness.SideShelfKant * 2 + 2);
            if ((ShelfAssembly == "конфирмат" || ShelfAssembly == "эксцентрик" ||
                 ShelfAssembly == "конфирмат + нагель" ||
                 ShelfAssembly == "нагель") && ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return Dimensions.Width - ModuleThickness.Plate * 2;
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return Dimensions.Width - (ModuleThickness.Plate * 2 + 3);
            return 0;
        }

        private double FN2()
        {
            return 2;
        }

        private double Fw1()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = Dimensions.Depth - (ModuleThickness.FrontModuleKant + ModuleThickness.BackModuleKant);
                    break;
                case "на гвозди":
                    result = Dimensions.Depth - (ModuleThickness.BackPanel + ModuleThickness.FrontModuleKant +
                                                 ModuleThickness.BackModuleKant);
                    break;
                case "в четверть":
                case "в паз":
                case "ЛДСП внутрь":
                    result = Dimensions.Depth - (ModuleThickness.FrontModuleKant + ModuleThickness.BackModuleKant);
                    break;
            }

            return result;
        }

        private double Fw3()
        {
            double result = 0;
            if (ShelvesCount == "нет")
                return result;
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                        result = Dimensions.Depth -
                                 (5 + ModuleThickness.FrontShelfKant + ModuleThickness.BackShelfKant +
                                  ModuleThickness.FrontModuleKant + ModuleThickness.BackModuleKant +
                                  ModuleThickness.BackPanel);
                        break;
                    case "в четверть":
                        result = Dimensions.Depth -
                                 (5 + 4 + ModuleThickness.FrontShelfKant + ModuleThickness.BackShelfKant +
                                  ModuleThickness.FrontModuleKant + ModuleThickness.BackModuleKant);
                        break;
                    case "в паз":
                        result = Dimensions.Depth -
                                 (5 + 4 + 16 + 1 + ModuleThickness.FrontShelfKant + ModuleThickness.BackShelfKant +
                                  ModuleThickness.FrontModuleKant + ModuleThickness.BackModuleKant);
                        break;
                    case "ЛДСП внутрь":
                        result = Dimensions.Depth -
                                 (5 + ModuleThickness.FrontShelfKant + ModuleThickness.BackShelfKant +
                                  ModuleThickness.Plate + ModuleThickness.FrontModuleKant +
                                  ModuleThickness.BackModuleKant);
                        break;
                }

                return result;
            }

            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                    case "в четверть":
                        result = Dimensions.Depth - (5 + ModuleThickness.BackPanel);
                        break;
                    case "в паз":
                        result = Dimensions.Depth - (21 + ModuleThickness.BackPanel);
                        break;
                    case "ЛДСП внутрь":
                        result = Dimensions.Depth - (5 + ModuleThickness.Plate);
                        break;
                }

                return result;
            }

            return result;
        }

        private int FN1()
        {
            return 2;
        }

        private int Fn3()
        {
            return CalculateShelfsCount();
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

        private double FL5()
        {
            if (Facades.Records.Count == 0)
                return 0;
            if (Facades.Records[0].Material == "нет")
                return 0;
            return Facades.Records[0].VerticalDimension;
        }

        private double FW5()
        {
            if (Facades.Records.Count == 0)
                return 0;
            if (Facades.Records[0].Material == "нет")
                return 0;
            return Facades.Records[0].HorizontalDimension;
        }

        private int FN5()
        {
            return 1;
        }

        private double FL7()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = 0;
                    break;
                case "на гвозди":
                    result = Dimensions.Height - 4;
                    break;
                case "в четверть":
                case "в паз":
                    result = Dimensions.Height - (ModuleThickness.Plate * 2 + 18);
                    break;
                case "ЛДСП внутрь":
                    result = Dimensions.Height - (ModuleThickness.Plate * 2 + ModuleThickness.UpModuleKant +
                                                  ModuleThickness.DownModuleKant);
                    break;
            }

            return result;
        }

        private double FW7()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = 0;
                    break;
                case "на гвозди":
                    result = Dimensions.Width - 2;
                    break;
                case "в четверть":
                case "в паз":
                    result = Dimensions.Width - (ModuleThickness.Plate * 2 + 18);
                    break;
                case "ЛДСП внутрь":
                    result = Dimensions.Width - (ModuleThickness.Plate * 2 + 2);
                    break;
            }

            return result;
        }

        private int FN7()
        {
            return 1;
        }

        private double Fl1()
        {
            return Dimensions.Height - (ModuleThickness.UpModuleKant + ModuleThickness.DownModuleKant);
        }

        private double Fl2()
        {
            return Dimensions.Width - ModuleThickness.Plate * 2;
        }

        private double Fw2()
        {
            return Fw1();
        }
    }
}