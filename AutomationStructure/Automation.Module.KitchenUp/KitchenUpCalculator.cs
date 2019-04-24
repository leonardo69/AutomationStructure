using System;
using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;
using Automation.Model;


namespace Automation.Module.KitchenUp
{
    public class KitchenUpCalculator
    {
        public string Name { get; set; }
        public string Sсheme { get; set; }
        public string BackPanelAssembly { get; set; }
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }
        public Dimensions _dimentions;
        public Facade _facade;
        public string _shelfAssembly;
        public string _shelfsCount;

        private string BigImagePath
        {
            get
            {
                var fullImagePath = IconPath.Split('_');
                return  fullImagePath[0] + "_" +
                       fullImagePath[1] + "_result.png";
            }

        }



        public string GetModuleName()
        {
            return Number;
        }

        public DataTable GetMainInfo()
        {
            DataTable mainInfo = new DataTable();
            mainInfo.Columns.Add("Высота H");
            mainInfo.Columns.Add("Ширина W");
            mainInfo.Columns.Add("Глубина T");
            mainInfo.Columns.Add("A");
            mainInfo.Columns.Add("B");
            mainInfo.Columns.Add("C");
            mainInfo.Columns.Add("D");
            DataRow row = mainInfo.NewRow();
            row[0] = _dimentions.Height;
            row[1] = _dimentions.Width;
            row[2] = _dimentions.Depth;
            row[3] = _dimentions.A;
            row[4] = _dimentions.B;
            row[5] = _dimentions.C;
            row[6] = _dimentions.D;
            mainInfo.Rows.Add(row);

            return mainInfo;
        }

        public string GetImagePath()
        {
            return BigImagePath;
        }


        public DataTable GetDetailsInfo()
        {
            DataTable detailsInfo = new DataTable();
            SetDetailsInfoColumns(detailsInfo);

            detailsInfo.Rows.Add("1", "бока", FL1(), DF1() + "|" + DF2(), FW1(), DF3() + "|" + DF4(), FN1(), MF7());
            detailsInfo.Rows.Add("2", "верх/низ", FL2(), DF5() + "|" + DF6(), FW2(), DF7()+ "|" + DF8(), FN2(), MF11());
            detailsInfo.Rows.Add("3", FA3(), FL3(), DF9() + "|" + DF10(), FW3(), DF11() + "|" + DF12(), FN3(), MF15());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("4", "задняя стенка", MF41(), "", MF42(), "", "", MF43());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("5", "фасад", FL5(), DF17() + "|" + DF18(), FW5(), DF19() + "|" + DF20(), FN5(), FP5());
            detailsInfo.Rows.Add("");
            detailsInfo.Rows.Add("6", "задняя панель", FL7(), DF17() + "|" + DF18(), FW7(), DF19() + "|" + DF20(), FN7(), FP7());
            detailsInfo.Rows.Add("ф1", "фасад 1", MF24(), DF21() ,MF25(), DF21(), "", "");
            detailsInfo.Rows.Add("ф2", "фасад 2", "26", "", "27", "", "", "");
            detailsInfo.Rows.Add("ф3", "фасад 3", "28", "", "29", "", "", "");
            detailsInfo.Rows.Add("ф4", "фасад 4", "30", "", "31", "", "", "");
            return detailsInfo;

        }

        private void SetDetailsInfoColumns(DataTable detailsInfo)
        {
            detailsInfo.Columns.Add("№");
            detailsInfo.Columns.Add("Наименование");

            DataColumn firstColumn = new DataColumn()
            {
                ColumnName = "firstMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(firstColumn);

            DataColumn secondColumn = new DataColumn
            {
                ColumnName = "firstEdge",
                Caption = "Кромка"
            };
            detailsInfo.Columns.Add(secondColumn);

            DataColumn thirdColumn = new DataColumn()
            {
                ColumnName = "secondMM",
                Caption = "ММ"
            };
            detailsInfo.Columns.Add(thirdColumn);

            DataColumn fourthColumn = new DataColumn
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
            DataTable dimensionsInfo = new DataTable();
            return dimensionsInfo;
        }

        public DataTable GetFurnitureInfo()
        {
            DataTable furnitureInfo = new DataTable();
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
            if (_facade._records.Count == 0)
                return "";
            string type = _facade._records[0].Type;
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
            return _shelfAssembly;
        }

        private string Mat_txt_3_2()
        {
            return _shelfAssembly;
        }

        private string Mat_txt_5_2()
        {
            if (BackPanelAssembly == "в паз")
                return "регулируемые";
            return "обычные";
        }

        private string Mat_txt_6_2()
        {
            return ModuleThickness.Plate.ToString();
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
            if (_facade._records.Count == 0)
                return 0;
            if (_facade._records[0].Type == "нет")
                return 0;
            double height = _facade._records[0].VerticalDimension;
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
            int result = 0;
            switch (_shelfAssembly)
            {
                case "конфирмат":
                case "эксцентрик":
                    if (_dimentions.Depth < 499)
                        result = 8;
                    else
                        result = 12;
                    break;
                case "нагель":
                    if (_dimentions.Depth < 499)
                        result = 12;
                    else
                        result = 16;
                    break;
                case "конфирмат + нагель":
                case "эксцентрик + нагель":
                    if (_dimentions.Depth < 499)
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
            double LDSP_Shelfs = 0;
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                LDSP_Shelfs = FL3() * FW3() * 0.001 * FN3();
            double backPanel = 0;
            if (BackPanelAssembly == "ЛДСП внутрь")
                backPanel = FL7() * FW7() * 0.001 * FN7();
            double facades = 0;
            if (_facade._records.Count != 0)
            {
                if (_facade._records[0].Type != "нет" && 
                    (_facade._records[0].Material == "ЛДСП вертик. фактура" || _facade._records[0].Material == "ЛДСП гориз. фактура"))
                    facades = FL5() * FW5() * 0.001 * FN5();
            }
            return FL1() * FW1() * 0.001 * FN1() + FL2() * FW2() * 0.001 * FN2() + LDSP_Shelfs + backPanel + facades;
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

        //TODO:изменить переменные как надо
        string moduleAssembly = "не разъёмная (конф.)";
        int moduleForm = 1;

        public int CalculateShelfsCount()
        {
            if (_shelfsCount == "нет")
                return 0;
            int begin = _shelfsCount.IndexOfAny("0123456789".ToCharArray());
            if (begin == -1)
                return 0;
            return Int32.Parse(_shelfsCount.Substring(begin, _shelfsCount.Length - begin));
        }

        public double CalculateShelfThickness()
        {
            if (_shelfsCount == "нет")
                return 0;
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return ModuleThickness.Plate;
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return 5;
            return 0;
        }

        public DataTable GetShelfInfo()
        {
            DataTable shelfInfo = new DataTable();
            int shelfsCount = CalculateShelfsCount();
            shelfInfo.Columns.Add("наименование");
            for (int i = 1; i <= shelfsCount; i++)
            {
                shelfInfo.Columns.Add("полка " + i.ToString());
            }
            shelfInfo.Rows.Add();
            double shelfThickness = CalculateShelfThickness();
            double sizeSpaceShelf = (_dimentions.Height - ModuleThickness.Plate * 2 - 
                shelfsCount * shelfThickness) / (shelfsCount + 1);
            double dim = shelfThickness;
            shelfInfo.Rows[0][0] = "размер";
            for (int i = 1; i <= shelfsCount; i++)
            {
                shelfInfo.Rows[0][i]=dim;
                dim += (shelfThickness + sizeSpaceShelf);
            }
            return shelfInfo;
        }

        public DataTable GetLoopsInfo()
        {
            DataTable loopsInfo = new DataTable();
            loopsInfo.Columns.Add("Петли");
            loopsInfo.Columns.Add("1");
            loopsInfo.Columns.Add("2");
            loopsInfo.Columns.Add("3");
            loopsInfo.Columns.Add("4");
            loopsInfo.Rows.Add("на фасаде", L1(), L2(), L3(), "");
            loopsInfo.Rows.Add("на модуле", ML1(), ML2(), ML3(), "");
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
            return _dimentions.Height - 100;
        }

        private double ML2()
        {
            return _dimentions.Height - 100 - 2;
        }

        private double L3()
        {
            return (_dimentions.Height - 4)/2;

        }

        private double ML3()
        {
            return _dimentions.Height/2;
        }

        #region Calculation formules

        //main formules
        private double FL1()
        {
            return _dimentions.Height - (ModuleThickness.UpModule + ModuleThickness.DownModule);
        }

        private double FW1()
        {
            double result = 0;
            switch (BackPanelAssembly)
            {
                case "нет":
                    result = _dimentions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
                case "на гвозди":
                    result = _dimentions.Depth - (ModuleThickness.BackPanel + ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
                case "в четверть":
                case "в паз":
                case "ЛДСП внутрь":
                    result = _dimentions.Depth - (ModuleThickness.FrontModule + ModuleThickness.BackModule);
                    break;
            }
            return result;
        }

        private double FN1()
        {
            return 2;
        }

        private string MF7()
        {
            string result = string.Empty;
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

        private double FL2()
        {
            return _dimentions.Width - (ModuleThickness.Plate*2);
        }

        private double FW2()
        {
            return FW1();
        }

        private double FN2()
        {
            return 2;
        }

        private string MF11()
        {
            return MF7();
        }

        private string FA3()
        {
            if (_shelfAssembly == "полкодержатель" && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "полка съёмная";
            if ((_shelfAssembly == "конфирмат" || _shelfAssembly == "эксцентрик" || _shelfAssembly == "конфирмат + нагель" || 
                _shelfAssembly == "нагель") && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "полка несъёмная";
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "полка стекло";
            if (_shelfsCount == "нет")
                return "полок нет";
            return "";
        }

        private double FL3()
        {
            if (_shelfsCount == "нет")
                return 0;
            if (_shelfAssembly == "полкодержатель" && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return _dimentions.Width - (ModuleThickness.Plate * 2 + ModuleThickness.SideShelf * 2 + 2);
            if ((_shelfAssembly == "конфирмат" || _shelfAssembly == "эксцентрик" || _shelfAssembly == "конфирмат + нагель" ||
                _shelfAssembly == "нагель") && _shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return _dimentions.Width - (ModuleThickness.Plate * 2);
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return _dimentions.Width - (ModuleThickness.Plate * 2 + 3);
            return 0;
        }

        private double FW3()
        {
            double result = 0;
            if (_shelfsCount == "нет")
                return result;
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                    case "в четверть":
                        result = _dimentions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf + 
                            ModuleThickness.BackPanel);
                        break;
                    case "в паз":
                        result = _dimentions.Depth - (21 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                            ModuleThickness.BackPanel);
                        break;
                    case "ЛДСП внутрь":
                        result = _dimentions.Depth - (5 + ModuleThickness.FrontShelf + ModuleThickness.BackShelf +
                            ModuleThickness.Plate);
                        break;
                }
                return result;
            }
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
            {
                switch (BackPanelAssembly)
                {
                    case "на гвозди":
                    case "в четверть":
                        result = _dimentions.Depth - (5 + ModuleThickness.BackPanel);
                        break;
                    case "в паз":
                        result = _dimentions.Depth - (21 + ModuleThickness.BackPanel);
                        break;
                    case "ЛДСП внутрь":
                        result = _dimentions.Depth - (5 + ModuleThickness.Plate);
                        break;
                }
                return result;
            }
            return result;
        }

        private int FN3()
        {
            return CalculateShelfsCount();
        }


        private string MF15()
        {
            if (_shelfsCount == "нет")
                return "";
            if (_shelfsCount.Substring(0, Math.Min(4, _shelfsCount.Length)) == "ЛДСП")
                return "ЛДСП";
            if (_shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "стекло";
            return "";
        }

        private double MF16()
        {
            return _dimentions.Width - ((ModuleThickness.Plate*2) + 2 + (ModuleThickness.SideShelf * 2));
        }

        private double MF17()
        {
            return FW3();
        }

        private string MF19()
        {
            return "";
        }

        private string MF41()
        {
            string result="";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (_dimentions.Height - 4).ToString();
                    break;
                case "в четверть":
                case "в паз":
                    result = (_dimentions.Height - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (_dimentions.Height - (ModuleThickness.Plate*2)).ToString();
                    break;
            }
            return result;
        }

        private string MF42()
        {
            string result = "";
            switch (BackPanelAssembly)
            {
                case "на гвозди":
                    result = (_dimentions.Width - 4).ToString();
                    break;
                case "в четверть":
                case "в паз":
                    result = (_dimentions.Width - 22).ToString();
                    break;
                case "ЛДСП внутрь":
                    result = (_dimentions.Width - (ModuleThickness.Plate * 2)).ToString();
                    break;
            }
            return result;
        }

        private string MF43()
        {
            string result = "";
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
            if (_facade._records.Count == 0)
                return 0;
            if (_facade._records[0].Material == "нет")
                return 0;
            return _facade._records[0].VerticalDimension;
        }

        private double FW5()
        {
            if (_facade._records.Count == 0)
                return 0;
            if (_facade._records[0].Material == "нет")
                return 0;
            return _facade._records[0].HorisontalDimension;
        }

        private int FN5()
        {
            return 1;
        }

        private string FP5()
        {
            if (_facade._records.Count == 0)
                return "";
            string result = "";
            switch (_facade._records[0].Material)
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
                    result = _dimentions.Height - 4;
                    break;
                case "в четверть":
                case "в паз":
                    result = _dimentions.Height - (ModuleThickness.Plate * 2 + 18);
                    break;
                case "ЛДСП внутрь":
                    result = _dimentions.Height - (ModuleThickness.Plate * 2 + ModuleThickness.UpModule + 
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
                    result = _dimentions.Width - 2;
                    break;
                case "в четверть":
                case "в паз":
                    result = _dimentions.Width - (ModuleThickness.Plate * 2 + 18);
                    break;
                case "ЛДСП внутрь":
                    result = _dimentions.Width - (ModuleThickness.Plate * 2 + 2);
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
            string result = "";
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
            if (_facade._records.Count == 0)
                return result;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result =_dimentions.Height - 4;
                        break;
                    case "Гориз.":
                        result =  _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Height - 4;
                        break;
                }
            }
            else if(moduleForm ==2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Height -_dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Height - _dimentions.A - 4;
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Height - _dimentions.A - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Width - 4;
                        break;
                    case "нет":
                        result = _dimentions.Height - _dimentions.A - 4;
                        break;
                }
            }
            return result;

        }

        private double MF25()
        {
            var moduleForm = 1;
            double result = 0;
            if (_facade._records.Count == 0)
                return 0;
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Height - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            else if (moduleForm == 2)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Height - _dimentions.A - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
                {
                    case "Верт.":
                        result = _dimentions.Width - 4;
                        break;
                    case "Гориз.":
                        result = _dimentions.Height - _dimentions.A - 4;
                        break;
                    case "нет":
                        result = _dimentions.Width - 4;
                        break;
                }
            }
            return result;
        }

        public string MF45()
        {
            var moduleForm = 1;
            string result = "";
            if (moduleForm == 1)
            {
                switch (_facade._records[0].Material)
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
            }
            else if (moduleForm == 2)
            {
                switch (_facade._records[0].Material)
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
            }
            else if (moduleForm == 3)
            {
                switch (_facade._records[0].Material)
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
            if(BackPanelAssembly == "в четверть")
                return GetEdgeThickness(0.4);
            return GetEdgeThickness(ModuleThickness.BackModule);
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
            if (_shelfsCount == "нет" || _shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "";
            return GetEdgeThickness(ModuleThickness.FrontShelf);
        }

        private string DF10()
        {
            if (_shelfsCount == "нет" || _shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "";
            return GetEdgeThickness(ModuleThickness.BackShelf);
        }

        private string DF11()
        {
            if (_shelfsCount == "нет" || _shelfsCount.Substring(0, Math.Min(6, _shelfsCount.Length)) == "стекло")
                return "";
            if (_shelfAssembly == "полкодержатель")
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
            string result = string.Empty;
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
            if (_facade._records.Count == 0)
                return "";
            if (_facade._records[0].Type == "нет" || _facade._records[0].Material == "на заказ глухой" ||
                _facade._records[0].Material == "на заказ витрина" || _facade._records[0].Material == "на заказ особый")
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
            string result = string.Empty;
            if (_facade._records.Count == 0)
                return "";
            if (_facade._records[0].Type == "нет" || (int)ModuleThickness.Facade == 0)
            {
                result = "";
            }

            if (_facade._records[0].Type !="нет" && ModuleThickness.Facade == 0.4)
            {
                result = "I";
            }

            if (_facade._records[0].Type != "нет" && ModuleThickness.Facade == 2)
            {
                result = "V";
            }

            return result;
        }


        #endregion

    }
}
