using System;

namespace Automation.Infrastructure
{
    /// <summary>
    /// Толщина материалов и кромок по деталям
    /// </summary>
    public static class ModuleThickness
    {
        /// <summary>
        /// Устанавливаем начальные значения для кромок
        /// </summary>
        static ModuleThickness()
        {
            SetValueForKantsThickness("1");
            SetPlateThickness("16 мм");
            SetBackPanelThickness("4 мм (станд.)");
        }

        public static string GetModuleThickness()
        {
            var info = "1.BackPanel: " + BackPanel + " \n ";
            info += "2.LDSP Plate:" + Plate + " \n ";
            info += "3.FrontModuleKant:" + FrontModuleKant + " \n ";

            info += "UpModuleKant:" + UpModuleKant + " \n ";
            info += "DownModuleKant:" + DownModuleKant + "\n ";
            info += "SideModuleKant:" + SideModuleKant + " \n";
            info += "BackModuleKant:" + BackModuleKant + "\n ";

            info += "FrontShelfKant:" + FrontShelfKant + "\n ";
            info += "SideShelfKant:" + SideShelfKant + " \n ";
            info += "BackShelfKant:" + BackShelfKant + " \n ";

            info += "Facades:" + FacadeKant + " \n ";

            return info;
        }

        /// Толщины кромок

        /// <summary>
        /// Толщина кромки фронтовой части модуля
        /// </summary>
        public static double FrontModuleKant { get; set; }

        /// <summary>
        /// Толщина кромки верхней части модуля
        /// </summary>
        public static double UpModuleKant { get; set; }

        /// <summary>
        /// Толщина кромки нижней части модуля
        /// </summary>
        public static double DownModuleKant { get; set; }

        /// <summary>
        /// Толщина кромки боковых частей модуля
        /// </summary>
        public static double SideModuleKant { get; set; }

        /// <summary>
        /// Толщина кромки задней части модуля
        /// </summary>
        public static double BackModuleKant { get; set; }


        /// <summary>
        /// Толщина кромки передней части полки модуля
        /// </summary>
        public static double FrontShelfKant { get; set; }

        /// <summary>
        /// Толщина кромки боковой части полки модуля
        /// </summary>
        public static double SideShelfKant { get; set; }

        /// <summary>
        /// Толщина кромки задней части полки модуля
        /// </summary>
        public static double BackShelfKant { get; set; }

        /// <summary>
        /// Толщина кромки фасада модуля
        /// </summary>
        public static double FacadeKant { get; set; }



        // Толщины материалов деталей

        /// <summary>
        /// Задняя стенка
        /// </summary>
        public static double BackPanel { get; set; }

        /// <summary>
        /// ЛДСП
        /// </summary>
        public static double Plate { get; set; }




        public static double InputPlateConverter(string value)
        {
            double result;
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
            double result;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "3,2 мм":
                    result = 3.2;
                    break;
                case "4 мм (станд.)":
                    result = 4;
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

        // TODO : проверить опционально кейс
        public static double InputFrontModuleConverter(string value)
        {
            double result;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.4;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                case "0,4 (max)":
                    result = 0.4;
                    break;
                case "0,4...2 (оптим.)":
                    result = 2;
                    break;
                default:
                    throw new Exception("Недоступимое значение");
            }
            return result;
        }

        public static double InputUpModuleConverter(string value)
        {
            double result;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.4;
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
                    result = 0.4;
                    break;
                default:
                    throw new Exception("Неверное значение");
            }
            return result;
        }

        public static double InputDownModuleConverter(string value) => InputUpModuleConverter(value);

        public static double InputSideModuleConverter(string value) => InputUpModuleConverter(value);

        public static double InputBackModuleConverter(string value)
        {
            double result;
            switch (value)
            {
                case "нет":
                case "0,4 (стандарт)":
                case "1":
                case "2":
                case "0,4 (min)":
                    result = 0;
                    break;
                case "0,4 (max)":
                    result = 0.4;
                    break;
                case "0,4...2 (оптим.)":
                    result = 0;
                    break;
                default:
                   throw new Exception("Недопустимое значение");
            }
            return result;
        }

        public static double InputFrontShelfConverter(string value) => InputFrontModuleConverter(value);

        public static double InputSideShelfConverter(string value)
        {
            double result;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.4;
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
                    result = 0.4;
                    break;
                default:
                    throw new Exception("Неверное значение");
            }
            return result;
        }

        public static double InputBackShelfConverter(string value) => InputSideShelfConverter(value);

        public static double InputFacadeConverter(string value)
        {
            double result;
            switch (value)
            {
                case "нет":
                    result = 0;
                    break;
                case "0,4 (стандарт)":
                    result = 0.4;
                    break;
                case "1":
                    result = 1;
                    break;
                case "2":
                    result = 2;
                    break;
                case "0,4 (min)":
                    result = 0.4;
                    break;
                case "0,4 (max)":
                    result = 2;
                    break;
                case "0,4...2 (оптим.)":
                    result = 2;
                    break;
                default:
                    throw new Exception("Неверное значение");
            }
            return result;
        }

 

        public static void SetBackPanelThickness(string value)
        {
            BackPanel = InputBackPanelConverter(value);
        }

        public static void SetPlateThickness(string value)
        {
            Plate = InputPlateConverter(value);
        }

        public static void SetValueForKantsThickness(string value)
        {
            FrontModuleKant = InputFrontModuleConverter(value);
            UpModuleKant = InputUpModuleConverter(value);
            DownModuleKant = InputDownModuleConverter(value);
            SideModuleKant = InputSideModuleConverter(value);
            BackModuleKant = InputBackModuleConverter(value);
            FrontShelfKant = InputFrontShelfConverter(value);
            SideShelfKant = InputSideShelfConverter(value);
            BackShelfKant = InputBackShelfConverter(value);
            FacadeKant = InputFacadeConverter(value);
        }
    }
}