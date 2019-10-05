using System;
using System.Data;
using Automation.Module.KitchenDownOneFacade.Calculation;

namespace Automation.Module.KitchenDownOneFacade.Core
{
    public class ModuleMapper
    {

        public static DataTable GetEmptyModuleTable()
        {
            var table = new DataTable();
            table.Columns.Add("Номер модуля");
            table.Columns.Add("Форма модуля");
            table.Columns.Add("Изображение");
            table.Columns.Add("Высота модуля (мм)");
            table.Columns.Add("Ширина модуля (мм)");
            table.Columns.Add("Глубина модуля (мм)");
            table.Columns.Add("A размер (мм)");
            table.Columns.Add("B размер (мм)");
            table.Columns.Add("C размер (мм)");
            table.Columns.Add("D размер (мм)");
            table.Columns.Add("Сборка модуля");
            table.Columns.Add("Задняя стенка");
            table.Columns.Add("Крепление полки");
            table.Columns.Add("Кол-во полок");
            table.Columns.Add("№ схемы фасада");
            table.Columns.Add("Тип фасада");
            table.Columns.Add("Режим расчёта");
            table.Columns.Add("Высота");
            table.Columns.Add("Ширина");
            table.Columns.Add("Материал фасада");
            table.Columns.Add("ПОСУДОСУШИЛКА");
            table.Columns.Add("Навесы на стену");
            return table;
        }


        /// <summary>
        /// Map table to module
        /// </summary>
        /// <param name="changedInfo"></param>
        /// <returns></returns>
        public static Module Setup(DataTable changedInfo)
        {

            var module = new Module();

            var row = changedInfo.Rows[0];
            module.Number = row["Номер модуля"].ToString();
            module.IconPath = row["Изображение"].ToString();

            module.Scheme = row["Форма модуля"].ToString();

            if (!double.TryParse(row["Высота модуля (мм)"].ToString(), out var height))
                throw new ArgumentException("Высота модуля должна быть числом");
            if (height < 0)
                throw new ArgumentException("Высота модуля не может быть отрицательной");
            module.Dimensions.Height = height;

            if (!double.TryParse(row["Ширина модуля (мм)"].ToString(), out var width))
                throw new ArgumentException("Ширина модуля должна быть числом");
            if (width < 0)
                throw new ArgumentException("Ширина модуля не может быть отрицательной");
            module.Dimensions.Width = width;


            if (!int.TryParse(row["№ схемы фасада"].ToString(), out var facadeNumber))
                throw new ArgumentException("№ схемы фасада должен быть целым числом");
            module.CalcMode = row["Режим расчёта"].ToString();

            var formula = module.IconPath.Split('_')[1];
            if (facadeNumber > 0 && module.CalcMode == "авт. мод.")
            {
                module.Facades.Records[0].HorizontalDimension = double.Parse(row["Ширина"].ToString());
                module.Facades.Records[0].VerticalDimension = double.Parse(row["Высота"].ToString());
                var calculator = new KitchenUpFacadeCalculator();
                calculator.CalculateModuleDimensions(module.Facades, module.Dimensions, formula);
            }

            if (!double.TryParse(row["Глубина модуля (мм)"].ToString(), out var depth))
                throw new ArgumentException("Глубина модуля должна быть числом");
            if (depth < 0)
                throw new ArgumentException("Глубина модуля не может быть отрицательной");
            module.Dimensions.Depth = depth;

            if (!double.TryParse(row["A размер (мм)"].ToString(), out var a))
                throw new ArgumentException("A размер должен быть числом");
            if (a < 0)
                throw new ArgumentException("A размер не может быть отрицательным");
            module.Dimensions.A = a;


            if (!double.TryParse(row["B размер (мм)"].ToString(), out var b))
                throw new ArgumentException("B размер должен быть числом");
            if (b < 0)
                throw new ArgumentException("B размер не может быть отрицательным");
            module.Dimensions.B = b;


            if (!double.TryParse(row["C размер (мм)"].ToString(), out var c))
                throw new ArgumentException("C размер должен быть числом");
            if (c < 0)
                throw new ArgumentException("C размер не может быть отрицательным");
            module.Dimensions.C = c;


            if (!double.TryParse(row["D размер (мм)"].ToString(), out var d))
                throw new ArgumentException("D размер должен быть числом");
            if (d < 0)
                throw new ArgumentException("D размер не может быть отрицательным");
            module.Dimensions.D = d;


            module.ModuleAssembly = row["Сборка модуля"].ToString();
            module.BackPanelAssembly = row["Задняя стенка"].ToString();

            module.ShelfAssembly = row["Крепление полки"].ToString();
            module.ShelfsCount = row["Кол-во полок"].ToString();

            module.Facades.Records[0].NumberOnScheme = facadeNumber;
            module.Facades.Records[0].Type = row["Тип фасада"].ToString();
            module.Facades.Records[0].Material = row["Материал фасада"].ToString();

            for (var i = 0; i < changedInfo.Rows.Count; i++)
            {
                row = changedInfo.Rows[i];
                if (module.CalcMode == "авт. фас.")
                {
                    var calculator = new KitchenUpFacadeCalculator();
                    calculator.CalculateFacadeDimensions(module.Facades, module.Dimensions, formula, i);
                }
                else
                {
                    module.Facades.Records[i].HorizontalDimension = double.Parse(row["Ширина"].ToString());
                    module.Facades.Records[i].VerticalDimension = double.Parse(row["Высота"].ToString());
                }
            }


            module.DishDryer = row["ПОСУДОСУШИЛКА"].ToString();
            module.Canopies = row["Навесы на стену"].ToString();

            return module;
        }

        public static void AddModuleInfoRows(DataTable table, Module module)
        {
            var row = table.NewRow();
            row["Номер модуля"] = module.Number;
            row["Форма модуля"] = module.Scheme;
            row["Изображение"] = module.IconPath;
            row["Высота модуля (мм)"] = module.Dimensions.Height;
            row["Ширина модуля (мм)"] = module.Dimensions.Width;
            row["Глубина модуля (мм)"] = module.Dimensions.Depth;
            row["A размер (мм)"] = module.Dimensions.A;
            row["B размер (мм)"] = module.Dimensions.B;
            row["C размер (мм)"] = module.Dimensions.C;
            row["D размер (мм)"] = module.Dimensions.D;
            row["Сборка модуля"] = module.ModuleAssembly;
            row["Задняя стенка"] = module.BackPanelAssembly;
            row["Крепление полки"] = module.ShelfAssembly;
            row["Кол-во полок"] = module.ShelfsCount;

            if (module.Facades.Records.Count != 0)
            {
                row["№ схемы фасада"] = module.Facades.Records[0].NumberOnScheme;
                row["Тип фасада"] = module.Facades.Records[0].Type;
                row["Режим расчёта"] = module.CalcMode;
                row["Высота"] = module.Facades.Records[0].VerticalDimension;
                row["Ширина"] = module.Facades.Records[0].HorizontalDimension;
                row["Материал фасада"] = module.Facades.Records[0].Material;
            }
            else
            {
                row["№ схемы фасада"] = 0;
            }

            table.Rows.Add(row);

            for (var i = 1; i < module.Facades.Records.Count; i++)
            {
                var anotherRow = table.NewRow();
                anotherRow["№ схемы фасада"] = module.Facades.Records[i].NumberOnScheme;
                anotherRow["Высота"] = module.Facades.Records[i].VerticalDimension;
                anotherRow["Ширина"] = module.Facades.Records[i].HorizontalDimension;
                table.Rows.Add(anotherRow);
            }

            row["ПОСУДОСУШИЛКА"] = module.DishDryer;
            row["Навесы на стену"] = module.Canopies;
        }

        
    }
}
