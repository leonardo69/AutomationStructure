using System;
using System.Data;
using System.Globalization;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp
{
    public class KitchenUpCalculator
    {
        private readonly string _moduleAssembly = "не разъёмная (конф.)";
        private int _moduleForm = 1;

        public Dimensions Dimensions;
        public Facade Facade;
        public string ShelfAssembly;
        public string ShelvesCount;
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string BackPanelAssembly { get; set; }
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }

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

            detailsInfo.Rows.Add("1", "бока", Fl1(), DF1() + "|" + DF2(), Fw1(), DF3() + "|" + DF4(), FN1(), Mf7());
            detailsInfo.Rows.Add("2", "верх/низ", Fl2(), DF5() + "|" + DF6(), Fw2(), DF7() + "|" + DF8(), FN2(),
                Mf11());
            detailsInfo.Rows.Add("3", Fa3(), Fl3(), DF9() + "|" + DF10(), Fw3(), DF11() + "|" + DF12(), Fn3(), Mf15());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("4", "задняя стенка", MF41(), "", MF42(), "", "", MF43());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("5", "фасад", FL5(), DF17() + "|" + DF18(), FW5(), DF19() + "|" + DF20(), FN5(),
                FP5());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("6", "задняя панель", FL7(), DF17() + "|" + DF18(), FW7(), DF19() + "|" + DF20(),
                FN7(), FP7());
            detailsInfo.Rows.Add("ф1", "фасад 1", MF24(), DF21(), MF25(), DF21(), "", "");
            detailsInfo.Rows.Add("ф2", "фасад 2", "26", "", "27", "", "", "");
            detailsInfo.Rows.Add("ф3", "фасад 3", "28", "", "29", "", "", "");
            detailsInfo.Rows.Add("ф4", "фасад 4", "30", "", "31", "", "", "");
            return detailsInfo;
        }

        private void SetDetailsInfoColumns(DataTable detailsInfo)
        {
            detailsInfo.Columns.Add("№");
            detailsInfo.Columns.Add("Наименование");

            var firstColumn = new DataColumn
            {
                ColumnName = "firstMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(firstColumn);

            var secondColumn = new DataColumn
            {
                ColumnName = "firstEdge",
                Caption = "Кромка"
            };
            detailsInfo.Columns.Add(secondColumn);

            var thirdColumn = new DataColumn
            {
                ColumnName = "secondMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(thirdColumn);

            var fourthColumn = new DataColumn
            {
                ColumnName = "secondEdge",
                Caption = "Кромка"
            };
            detailsInfo.Columns.Add(fourthColumn);

            detailsInfo.Columns.Add("Количество");
            detailsInfo.Columns.Add("Примечание");
        }

        public DataTable GetDimensionsInfo()
        {
            var dimensionsInfo = new DataTable();
            return dimensionsInfo;
        }

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
            if (Facade.Records.Count == 0)
                return "";
            var type = Facade.Records[0].Type;
            if (type == null)
                return "";
            if (type == "накладной")
                return "накладные";
            if (type.Substring(0, Math.Min(8, type.Length)) == "вкладной")
                return "вкладные";
            return "";
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
            if (Facade.Records.Count == 0)
                return 0;
            if (Facade.Records[0].Type == "нет")
                return 0;
            var height = Facade.Records[0].VerticalDimension;
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
            // ReSharper disable once IdentifierTypo
            double ldspShelfs = 0;
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                ldspShelfs = Fl3() * Fw3() * 0.001 * Fn3();
            double backPanel = 0;
            if (BackPanelAssembly == "ЛДСП внутрь")
                backPanel = FL7() * FW7() * 0.001 * FN7();
            double facades = 0;
            if (Facade.Records.Count != 0)
                if (Facade.Records[0].Type != "нет" &&
                    (Facade.Records[0].Material == "ЛДСП вертик. фактура" ||
                     Facade.Records[0].Material == "ЛДСП гориз. фактура"))
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

        #region Calculation formules

        //main formules
        private double Fl1()
        {
            return Dimensions.Height - (ModuleThickness.UpModule + ModuleThickness.DownModule);
        }

        private double Fw1()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = Dimensions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
                case "на гвозди":
                    result = Dimensions.Depth - (ModuleThickness.BackPanel + ModuleThickness.FrontModule +
                                                 ModuleThickness.BackModule);
                    break;
                case "в четверть":
                case "в паз":
                case "ЛДСП внутрь":
                    result = Dimensions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
            }

            return result;
        }

        private double FN1()
        {
            return 2;
        }

        private string Mf7()
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

        private string Mf11()
        {
            return Mf7();
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
                return Dimensions.Width - (ModuleThickness.Plate * 2 + ModuleThickness.SideShelf * 2 + 2);
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
                    case "в четверть":
                        result = Dimensions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                                                     ModuleThickness.BackPanel);
                        break;
                    case "в паз":
                        result = Dimensions.Depth - (21 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                                                     ModuleThickness.BackPanel);
                        break;
                    case "ЛДСП внутрь":
                        result = Dimensions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                                                     ModuleThickness.Plate);
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
            if (ShelvesCount.Substring(0, Math.Min(4, ShelvesCount.Length)) == "ЛДСП")
                return "ЛДСП";
            if (ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "стекло";
            return "";
        }

        private double Mf16()
        {
            return Dimensions.Width - (ModuleThickness.Plate * 2 + 2 + ModuleThickness.SideShelf * 2);
        }

        private double Mf17()
        {
            return Fw3();
        }

        private string Mf19()
        {
            return "";
        }

        private string MF41()
        {
            var result = "";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (Dimensions.Height - 4).ToString();
                    break;
                case "в четверть":
                case "в паз":
                    result = (Dimensions.Height - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (Dimensions.Height - ModuleThickness.Plate * 2).ToString();
                    break;
            }

            return result;
        }

        private string MF42()
        {
            var result = "";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (Dimensions.Width - 4).ToString();
                    break;
                case "в четверть":
                case "в паз":
                    result = (Dimensions.Width - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (Dimensions.Width - ModuleThickness.Plate * 2).ToString();
                    break;
            }

            return result;
        }

        private string MF43()
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
                    result = "ДВП/фанера";
                    break;
                case "ЛДСП внутрь":
                    result = "ЛДСП";
                    break;
            }

            return result;
        }

        private double FL5()
        {
            if (Facade.Records.Count == 0)
                return 0;
            if (Facade.Records[0].Material == "нет")
                return 0;
            return Facade.Records[0].VerticalDimension;
        }

        private double FW5()
        {
            if (Facade.Records.Count == 0)
                return 0;
            if (Facade.Records[0].Material == "нет")
                return 0;
            return Facade.Records[0].HorizontalDimension;
        }

        private int FN5()
        {
            return 1;
        }

        private string FP5()
        {
            if (Facade.Records.Count == 0)
                return "";
            var result = "";
            switch (Facade.Records[0].Material)
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
                    result = Dimensions.Height - (ModuleThickness.Plate * 2 + ModuleThickness.UpModule +
                                                  ModuleThickness.DownModule);
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
            var moduleForm = 1;
            double result = 0;
            if (Facade.Records.Count == 0)
                return result;
            if (moduleForm == 1)
                switch (Facade.Records[0].Material)
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
                }
            else if (moduleForm == 2)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                    case "Гориз.":
                        result = Dimensions.Width - 4;
                        break;
                    case "нет":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                }
            else if (moduleForm == 3)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                    case "Гориз.":
                        result = Dimensions.Width - 4;
                        break;
                    case "нет":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                }
            return result;
        }

        private double MF25()
        {
            var moduleForm = 1;
            double result = 0;
            if (Facade.Records.Count == 0)
                return 0;
            if (moduleForm == 1)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = Dimensions.Width - 4;
                        break;
                    case "Гориз.":
                        result = Dimensions.Height - 4;
                        break;
                    case "нет":
                        result = Dimensions.Width - 4;
                        break;
                }
            else if (moduleForm == 2)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = Dimensions.Width - 4;
                        break;
                    case "Гориз.":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                    case "нет":
                        result = Dimensions.Width - 4;
                        break;
                }
            else if (moduleForm == 3)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = Dimensions.Width - 4;
                        break;
                    case "Гориз.":
                        result = Dimensions.Height - Dimensions.A - 4;
                        break;
                    case "нет":
                        result = Dimensions.Width - 4;
                        break;
                }
            return result;
        }

        public string MF45()
        {
            var moduleForm = 1;
            var result = "";
            if (moduleForm == 1)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            else if (moduleForm == 2)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            else if (moduleForm == 3)
                switch (Facade.Records[0].Material)
                {
                    case "Верт.":
                        result = "фактура ЛДСП вертик.";
                        break;
                    case "Гориз.":
                        result = "фактура ЛДСП гориз.";
                        break;
                    case "нет":
                        result = "на заказ";
                        break;
                }
            return result;
        }

        #endregion

        #region Calculation dop formules 

        private string DF1()
        {
            return GetEdgeThickness(ModuleThickness.FrontModule);
        }

        private string DF2()
        {
            return GetEdgeThickness(BackPanelAssembly == "в четверть" ? 0.4 : ModuleThickness.BackModule);
        }

        private string DF3()
        {
            return GetEdgeThickness(ModuleThickness.UpModule);
        }

        private string DF4()
        {
            return GetEdgeThickness(ModuleThickness.DownModule);
        }

        private string DF5()
        {
            return DF1();
        }

        private string DF6()
        {
            return DF2();
        }

        private string DF7()
        {
            return GetEdgeThickness(ModuleThickness.SideModule);
        }

        private string DF8()
        {
            return GetEdgeThickness(ModuleThickness.SideModule);
        }

        private string DF9()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "";
            return GetEdgeThickness(ModuleThickness.FrontShelf);
        }

        private string DF10()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "";
            return GetEdgeThickness(ModuleThickness.BackShelf);
        }

        private string DF11()
        {
            if (ShelvesCount == "нет" || ShelvesCount.Substring(0, Math.Min(6, ShelvesCount.Length)) == "стекло")
                return "";
            if (ShelfAssembly == "полкодержатель")
                return GetEdgeThickness(ModuleThickness.SideShelf);
            return "";
        }

        private string DF12()
        {
            return DF11();
        }

        private string DF13()
        {
            return DF9();
        }

        private string DF14()
        {
            return DF10();
        }

        private string DF15()
        {
            return GetEdgeThickness(ModuleThickness.SideShelf);
        }

        private string GetEdgeThickness(double par)
        {
            var result = string.Empty;
            switch (par.ToString())
            {
                case "0":
                    result = "";
                    break;
                case "0,4":
                case "0.4":
                    result = "I";
                    break;
                case "2":
                    result = "V";
                    break;
            }

            return result;
        }

        private string DF16()
        {
            return GetEdgeThickness(ModuleThickness.SideShelf);
        }

        private string DF17()
        {
            if (Facade.Records.Count == 0)
                return "";
            if (Facade.Records[0].Type == "нет" || Facade.Records[0].Material == "на заказ глухой" ||
                Facade.Records[0].Material == "на заказ витрина" || Facade.Records[0].Material == "на заказ особый")
                return "";
            return GetEdgeThickness(ModuleThickness.Facade);
        }

        private string DF18()
        {
            return DF17();
        }

        private string DF19()
        {
            return DF17();
        }

        private string DF20()
        {
            return DF17();
        }

        private string DF21()
        {
            var result = string.Empty;
            if (Facade.Records.Count == 0)
                return "";
            if (Facade.Records[0].Type == "нет" || (int) ModuleThickness.Facade == 0) result = "";

            if (Facade.Records[0].Type != "нет" && ModuleThickness.Facade == 0.4) result = "I";

            if (Facade.Records[0].Type != "нет" && ModuleThickness.Facade == 2) result = "V";

            return result;
        }

        #endregion
    }
}