using System;
using System.Data;
using System.Globalization;
using Automation.Infrastructure;
using Automation.Module.KitchenUp.Details;

namespace Automation.Module.KitchenUp
{
    public class Calculator
    {
        public Dimensions Dimensions;
        public Facades Facades;
        public string ShelfAssembly;
        public string ShelvesCount;
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string BackPanelAssembly { get; set; }
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }

        /// <summary>
        ///     Навес на стену
        /// </summary>
        public string Canopies { get; set; }

        private string BigImagePath
        {
            get
            {
                var fullImagePath = IconPath.Split('_');
                return fullImagePath[0] + "_" +
                       fullImagePath[1] + "_result.png";
            }
        }


        public string GetModuleName()
        {
            return Number;
        }

        public DataTable GetMainInfo()
        {
            var mainInfo = new DataTable {TableName = "Основная информация"};
            mainInfo.Columns.Add("Высота H");
            mainInfo.Columns.Add("Ширина W");
            mainInfo.Columns.Add("Глубина T");
            mainInfo.Columns.Add("A");
            mainInfo.Columns.Add("B");
            mainInfo.Columns.Add("C");
            mainInfo.Columns.Add("D");
            var row = mainInfo.NewRow();
            row[0] = Dimensions.Height;
            row[1] = Dimensions.Width;
            row[2] = Dimensions.Depth;
            row[3] = Dimensions.A;
            row[4] = Dimensions.B;
            row[5] = Dimensions.C;
            row[6] = Dimensions.D;
            mainInfo.Rows.Add(row);

            return mainInfo;
        }

        public string GetImagePath()
        {
            return BigImagePath;
        }


        public DataTable GetDetailsInfo()
        {
            var detailsInfo = new DataTable {TableName = "Детальная информация"};
            SetDetailsInfoColumns(detailsInfo);

            var sideDetail = new DetailsItem
            {
                Number = 1,
                Name = "бока",
                Length = Fl1().RoundToInt(),
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

            detailsInfo.Rows.Add(sideDetail.ConvertToDataRow());

            //detailsInfo.Rows.Add("1", "бока", Fl1(), KantValueJoin(DF1(),DF2()), Fw1(), KantValueJoin(DF3(), DF4()), FN1(), GetDetailNote());


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

            detailsInfo.Rows.Add(upAndDownDetail.ConvertToDataRow());

            //detailsInfo.Rows.Add("2", "верх/низ", Fl2(), KantValueJoin(DF5(), DF6()), Fw2(), KantValueJoin(DF7(), DF8()), FN2(),
            //    Mf11());


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

            detailsInfo.Rows.Add(shelfDetail.ConvertToDataRow());

            //detailsInfo.Rows.Add("3", Fa3(), Fl3(), KantValueJoin(DF9(), DF10()), Fw3(), KantValueJoin(DF11(), DF12()), Fn3(), Mf15());

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

                detailsInfo.Rows.Add(ldspPlank.ConvertToDataRow());
            }

            detailsInfo.Rows.Add("");

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

            detailsInfo.Rows.Add(backPanel.ConvertToDataRow());


            detailsInfo.Rows.Add("");


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

            detailsInfo.Rows.Add(facadeDetail.ConvertToDataRow());

            //detailsInfo.Rows.Add("5", "фасад", MF24(), KantValueJoin(DF17(), DF17()), FW5(), KantValueJoin(DF19(), DF20()), FN5(),FP5());
            return detailsInfo;
        }

        private void SetDetailsInfoColumns(DataTable detailsInfo)
        {
            detailsInfo.Columns.Add("№");
            detailsInfo.Columns.Add("Наименование");

            var firstColumn = new DataColumn {ColumnName = "firstMM", Caption = "Длина"};
            detailsInfo.Columns.Add(firstColumn);

            var secondColumn = new DataColumn {ColumnName = "firstEdge", Caption = "Кромка"};
            detailsInfo.Columns.Add(secondColumn);

            var thirdColumn = new DataColumn {ColumnName = "secondMM", Caption = "Ширина"};
            detailsInfo.Columns.Add(thirdColumn);

            var fourthColumn = new DataColumn {ColumnName = "secondEdge", Caption = "Кромка"};
            detailsInfo.Columns.Add(fourthColumn);

            detailsInfo.Columns.Add("Количество");
            detailsInfo.Columns.Add("Примечание");
        }

        public DataTable GetDimensionsInfo()
        {
            var dimensionsInfo = new DataTable();
            return dimensionsInfo;
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

        public double CalculateShelfThickness()
        {
            if (ShelvesCount == "нет")
                return 0;
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return ModuleThickness.Plate;
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return 5;
            return 0;
        }

        public DataTable GetShelfInfo()
        {
            var shelfInfo = new DataTable {TableName = "Полки"};
            var shelfsCount = CalculateShelfsCount();
            shelfInfo.Columns.Add("наименование");
            for (var i = 1; i <= shelfsCount; i++) shelfInfo.Columns.Add("полка " + i);
            shelfInfo.Rows.Add();
            var shelfThickness = CalculateShelfThickness();
            var sizeSpaceShelf = (Dimensions.Height - ModuleThickness.Plate * 2 -
                                  shelfsCount * shelfThickness) / (shelfsCount + 1);
            var dim = shelfThickness;
            shelfInfo.Rows[0][0] = "размер";
            for (var i = 1; i <= shelfsCount; i++)
            {
                shelfInfo.Rows[0][i] = dim;
                dim += shelfThickness + sizeSpaceShelf;
            }

            return shelfInfo;
        }

        public DataTable GetLoopsInfo()
        {
            var loopsInfo = new DataTable {TableName = "Петли"};
            loopsInfo.Columns.Add("Петли");
            loopsInfo.Columns.Add("1");
            loopsInfo.Columns.Add("2");
            loopsInfo.Columns.Add("3");
            loopsInfo.Columns.Add("4");
            loopsInfo.Rows.Add("на фасаде", L1(), L2(), L3(), "");
            loopsInfo.Rows.Add("на модуле", ML1(), Ml2(), Ml3(), "");
            return loopsInfo;
        }

        private int L1()
        {
            return 100;
        }

        private int ML1()
        {
            return 100 + 2;
        }

        private double L2()
        {
            return Dimensions.Height - 100;
        }

        private double Ml2()
        {
            return Dimensions.Height - 100 - 2;
        }

        private double L3()
        {
            return (Dimensions.Height - 4) / 2;
        }

        private double Ml3()
        {
            return Dimensions.Height / 2;
        }


        #region Формулы для фурнитуры

        public DataTable GetFurnitureInfo()
        {
            var furnitureInfo = new DataTable {TableName = "Фурнитура"};
            furnitureInfo.Columns.Add("наименование");
            furnitureInfo.Columns.Add("петли " + Mat_txt_1_2());
            furnitureInfo.Columns.Add("модуль на " + Mat_txt_2_2());
            furnitureInfo.Columns.Add("полки на " + Mat_txt_3_2());
            furnitureInfo.Columns.Add("ручки");
            furnitureInfo.Columns.Add("навесы " + Mat_txt_5_2());
            furnitureInfo.Columns.Add("плита, м.кв. " + Mat_txt_6_2());
            furnitureInfo.Columns.Add("кромка, м " + Mat_txt_7_2());
            furnitureInfo.Columns.Add("задняя стенка " + Mat_txt_8_2());
            furnitureInfo.Rows.Add("кол-во", Mat1(), Mat2(), Mat3(), "1", "2", Mat6(), Mat7(), Mat8());

            return furnitureInfo;
        }

        private string Mat_txt_1_2()
        {
            if (Facades.Records.Count == 0)
                return "";
            var type = Facades.Records[0].Type;
            switch (type)
            {
                case null:
                    return "";
                case "накладной":
                    return "накладные";
                default:
                    return type.Substring(0, Math.Min(8, type.Length)) == "вкладной" ? "вкладные" : "";
            }
        }

        private string Mat_txt_2_2()
        {
            return ShelfAssembly;
        }

        private string Mat_txt_3_2()
        {
            return ShelfAssembly;
        }

        private string Mat_txt_5_2()
        {
            if (BackPanelAssembly == "в паз")
                return "регулируемые";
            return "обычные";
        }

        private string Mat_txt_6_2()
        {
            return ModuleThickness.Plate.ToString(CultureInfo.InvariantCulture);
        }

        private string Mat_txt_7_2()
        {
            return "0.4/1/2 мм";
        }

        private string Mat_txt_8_2()
        {
            if (BackPanelAssembly == "ЛДСП внутрь")
                return "ЛДСП";
            return "ДВП/фанера";
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

        private int Mat3()
        {
            return Mat2();
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

        private int Mat7()
        {
            //not implemented
            return 0;
        }

        private double Mat8()
        {
            if (BackPanelAssembly == "ЛДСП внутрь")
                return 0;
            return FL7() * FW7() * FN7() * 0.001;
        }

        #endregion

        #region Calculation formules

        //main formulas
        private double Fl1()
        {
            return Dimensions.Height - (ModuleThickness.UpModuleKant + ModuleThickness.DownModuleKant);
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

        private int FN1()
        {
            return 2;
        }

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


        private double Fl2()
        {
            return Dimensions.Width - ModuleThickness.Plate * 2;
        }

        private double Fw2()
        {
            return Fw1();
        }

        private double FN2()
        {
            return 2;
        }


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
            return CalculateShelfsCount();
        }


        private string Mf15()
        {
            if (ShelvesCount == "нет")
                return "";
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "стекло";
            return "";
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

        private int FN7()
        {
            return 1;
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

        #endregion

        #region Calculation dop formules 

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


        private double DF19()
        {
            return DF17();
        }

        private double DF20()
        {
            return DF17();
        }

        #endregion
    }
}