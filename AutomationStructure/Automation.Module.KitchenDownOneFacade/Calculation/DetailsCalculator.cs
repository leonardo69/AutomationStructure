using System;
using System.Collections.Generic;
using Automation.Infrastructure;
using Automation.Module.KitchenDownOneFacade.Utils;

namespace Automation.Module.KitchenDownOneFacade.Calculation
{
    public class DetailsCalculator
    {

        public Dimensions Dimensions;
        public Facades Facades;
        public string ShelfAssembly;
        public string ShelvesCount;
  
        public string BackPanelAssembly { get; set; }

        /// <summary>
        ///  Навес на стену
        /// </summary>
        public string Canopies { get; set; }


        public List<DetailsItem> GetDetails()
        {
            var items = new List<DetailsItem>();

            var sideDetail = new DetailsItem
            {
                Number = 1,
                Name = "бока",
                Length = GetSideLength().RoundToInt(),
                KantByLength = new Kant
                {
                    Width = ModuleThickness.FrontModuleKant,
                    Length = BackPanelAssembly == "в четверть" ? 0.4 : ModuleThickness.BackModuleKant
                },
                Width = Fw1().RoundToInt(),
                KantByWidth = new Kant
                {
                    Width = ModuleThickness.UpModuleKant,
                    Length = ModuleThickness.DownModuleKant
                },
                Count = FN1(),
                Note = GetDetailNote()
            };

            items.Add(sideDetail);


            var upAndDownDetail = new DetailsItem
            {
                Number = 2,
                Name = "верх/низ",
                Length = Fl2().RoundToInt(),
                KantByLength = new Kant
                {
                    Width = 0,
                    Length = 0
                },
                Width = Fw2().RoundToInt(),
                KantByWidth = new Kant
                {
                    Width = 0,
                    Length = 0
                },
                Count = 2,
                Note = GetDetailNote()
            };

            items.Add(upAndDownDetail);


            var shelfDetail = new DetailsItem
            {
                Number = 3,
                Name = Fa3(),
                Length = Fl3().RoundToInt(),
                KantByLength = new Kant
                {
                    Width = DF9(),
                    Length = DF10()
                },
                Width = Fw3().RoundToInt(),
                KantByWidth = new Kant
                {
                    Width = DF11(),
                    Length = DF11()
                },
                Count = Fn3(),
                Note = Mf15()
            };

            items.Add(shelfDetail);

            if (Canopies == "планка ЛДСП // вставляем между боковыми панелями доску ЛДСП шириной 100 мм")
            {
                var ldspPlank = new DetailsItem
                {
                    Number = 100,
                    Name = "для крепления модуля",
                    Length = (Dimensions.Width - ModuleThickness.Plate * 2).RoundToInt(),
                    KantByLength = new Kant
                    {
                        Width = ModuleThickness.BackShelfKant,
                        Length = 0
                    },
                    Width = (Dimensions.Height - (ModuleThickness.UpModuleKant + ModuleThickness.DownModuleKant +
                                                  ModuleThickness.Plate * 2)).RoundToInt(),
                    KantByWidth = new Kant
                    {
                        Width = 0,
                        Length = 0
                    },
                    Count = 1,
                    Note = ""
                };

                items.Add(ldspPlank);
            }

            var backPanel = new DetailsItem
            {
                Number = 4,
                Name = "задняя стенка",
                Length = FL7().RoundToInt(),
                KantByLength = new Kant
                {
                    Width = 0,
                    Length = 0
                },
                Width = FW7().RoundToInt(),
                KantByWidth = new Kant
                {
                    Width = 0,
                    Length = 0
                },
                Count = 1,
                Note = FP7()
            };

            items.Add(backPanel);


            var facadeDetail = new DetailsItem
            {
                Number = 5,
                Name = "фасад",
                Length = MF24().RoundToInt(),
                KantByLength = new Kant
                {
                    Width = DF17(),
                    Length = DF17()
                },
                Width = FW5().RoundToInt(),
                KantByWidth = new Kant
                {
                    Width = DF19(),
                    Length = DF20()
                },
                Count = FN5(),
                Note = FP5()
            };

            items.Add(facadeDetail);

            return items;
        }

   

        //main formulas
        private double GetSideLength() => Dimensions.Height - (ModuleThickness.UpModuleKant + ModuleThickness.DownModuleKant);

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

        private int FN1() => 2;

        private string GetDetailNote()
        {
            var result = string.Empty;
            switch (BackPanelAssembly)
            {
                case "в паз":
                    result = "паз 10*4*16";
                    break;
                case "в четверть":
                    result = "четверть 10*4 мм";
                    break;
            }

            return result;
        }


        private double Fl2() => Dimensions.Width - ModuleThickness.Plate * 2;

        private double Fw2() => Fw1();


        private string Fa3()
        {
            if (ShelfAssembly == "полкодержатель" &&
                ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return "полка съёмная";
            if ((ShelfAssembly == "конфирмат" || ShelfAssembly == "эксцентрик" ||
                 ShelfAssembly == "конфирмат + нагель" ||
                 ShelfAssembly == "нагель") && ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return "полка несъёмная";
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "полка стекло";
            if (ShelvesCount == "нет")
                return "полок нет";
            return "";
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

        private int Fn3()
        {
            if (ShelvesCount == "нет")
                return 0;
            var begin = ShelvesCount.IndexOfAny("0123456789".ToCharArray());
            if (begin == -1)
                return 0;
            return int.Parse(ShelvesCount.Substring(begin, ShelvesCount.Length - begin));
        }

        private string Mf15()
        {
            if (ShelvesCount == "нет")
                return "";
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "стекло";
            return "";
        }



        private double FW5()
        {
            if (Facades.Records.Count == 0)
                return 0;
            if (Facades.Records[0].Material == "нет")
                return 0;
            return Facades.Records[0].HorizontalDimension;
        }

        private int FN5() => 1;

        private string FP5()
        {
            if (Facades.Records.Count == 0)
                return "";
            var result = "";
            switch (Facades.Records[0].Material)
            {
                case "нет":
                    result = "";
                    break;
                case "ЛДСП вертик. фактура":
                    result = "ЛДСП вертик. факт.";
                    break;
                case "ЛДСП гориз. фактура":
                    result = "ЛДСП гориз. факт.";
                    break;
                case "на заказ глухой":
                    result = "глухой, на заказ";
                    break;
                case "на заказ витрина":
                    result = "витрина, на заказ";
                    break;
                case "на заказ особый":
                    result = "особый, на заказ";
                    break;
            }

            return result;
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


        private string FP7()
        {
            var result = "";
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = "";
                    break;
                case "на гвозди":
                case "в четверть":
                case "в паз":
                    result = "ДВП или фанера 4 мм";
                    break;
                case "ЛДСП внутрь":
                    result = "ЛДСП внутрь";
                    break;
            }

            return result;
        }

        private double MF24()
        {
            double result;
            switch (Facades.Records[0].Material)
            {
                case "Верт.":
                    result = Dimensions.Height - 4;
                    break;
                case "Гориз.":
                    result = Dimensions.Width - 4;
                    break;
                case "нет":
                    result = Dimensions.Height - 4;
                    break;
                default:
                    result = Dimensions.Height - 4;
                    break;
            }

            return result;
        }


        private double DF9()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return 0;
            return ModuleThickness.FrontShelfKant;
        }

        private double DF10()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return 0;
            return ModuleThickness.BackShelfKant;
        }

        private double DF11()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return 0;
            return ShelfAssembly == "полкодержатель" ? ModuleThickness.SideShelfKant : 0;
        }

        private double DF17()
        {
            if (Facades.Records.Count == 0)
                return 0;
            if (Facades.Records[0].Type == "нет" || Facades.Records[0].Material == "на заказ глухой" ||
                Facades.Records[0].Material == "на заказ витрина" || Facades.Records[0].Material == "на заказ особый")
                return 0;
            return ModuleThickness.FacadeKant;
        }

        private double DF19() => DF17();

        private double DF20() => DF17();
    }
}
