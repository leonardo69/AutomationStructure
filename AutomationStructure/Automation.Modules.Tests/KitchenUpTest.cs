using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Automation.Module.KitchenUp;
using Automation.Infrastructure;

namespace Automation.Modules.Tests
{
    [TestClass]
    public class KitchenUpTest
    {
        private void AddColumns(DataTable input)
        {
            input.Columns.Add("Номер модуля");
            input.Columns.Add("Форма модуля");
            input.Columns.Add("Изображение");
            input.Columns.Add("Высота модуля (мм)");
            input.Columns.Add("Ширина модуля (мм)");
            input.Columns.Add("Глубина модуля (мм)");
            input.Columns.Add("A размер (мм)");
            input.Columns.Add("B размер (мм)");
            input.Columns.Add("C размер (мм)");
            input.Columns.Add("D размер (мм)");
            input.Columns.Add("Сборка модуля");
            input.Columns.Add("Задняя стенка");
            input.Columns.Add("Крепление полки");
            input.Columns.Add("Кол-во полок");
            input.Columns.Add("№ схемы фасада");
            input.Columns.Add("Тип фасада");
            input.Columns.Add("Режим расчёта");
            input.Columns.Add("Высота");
            input.Columns.Add("Ширина");
            input.Columns.Add("Материал фасада");
        }
        private void AddRow(DataTable input)
        {
            DataRow row = input.NewRow();
            row["Номер модуля"] = "1";
            row["Форма модуля"] = "Тип фасада 1";
            row["Изображение"] = "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_icon.png";
            row["Высота модуля (мм)"] = 100;
            row["Ширина модуля (мм)"] = 200;
            row["Глубина модуля (мм)"] = 300;
            row["A размер (мм)"] = 4;
            row["B размер (мм)"] = 5;
            row["C размер (мм)"] = 6;
            row["D размер (мм)"] = 7;
            row["Сборка модуля"] = "не разъёмная(конф.)";
            row["Задняя стенка"] = "нет";
            row["Крепление полки"] = "полкодержатель";
            row["Кол-во полок"] = "нет";
            row["№ схемы фасада"] = 1;
            row["Высота"] = 8;
            row["Ширина"] = 9;
            row["Тип фасада"] = "нет";
            row["Режим расчёта"] = "авт. фас.";
            row["Материал фасада"] = "нет";
            input.Rows.Add(row);
        }
        [TestMethod]
        public void TestCalculate()
        {
            KitchenUp module = new KitchenUp();
            DataTable input=new DataTable();
            AddColumns(input);
            AddRow(input);
            module.SetupModule(input);
            Result result = module.Calculate();
            Assert.AreEqual(result.ModuleName, "1");
            Assert.AreEqual(result.ImagePath, "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_result.png");
            var mainInfo = result.MainInfo;
            Assert.AreEqual(mainInfo.Rows[0]["Высота H"], "100");
            Assert.AreEqual(mainInfo.Rows[0]["Ширина W"], "200");
            Assert.AreEqual(mainInfo.Rows[0]["Глубина T"], "300");
            Assert.AreEqual(mainInfo.Rows[0]["A"], "4");
            Assert.AreEqual(mainInfo.Rows[0]["B"], "5");
            Assert.AreEqual(mainInfo.Rows[0]["C"], "6");
            Assert.AreEqual(mainInfo.Rows[0]["D"], "7");
            var detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[0]["Наименование"], "бока");
            Assert.AreEqual(detailsInfo.Rows[0]["firstMM"], "96");
            Assert.AreEqual(detailsInfo.Rows[0]["firstEdge"], "V|");
            Assert.AreEqual(detailsInfo.Rows[0]["secondMM"], "298");
            Assert.AreEqual(detailsInfo.Rows[0]["secondEdge"], "V|V");
            Assert.AreEqual(detailsInfo.Rows[0]["Количество"], "2");
            Assert.AreEqual(detailsInfo.Rows[0]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[1]["Наименование"], "верх/низ");
            Assert.AreEqual(detailsInfo.Rows[1]["firstMM"], "180");
            Assert.AreEqual(detailsInfo.Rows[1]["firstEdge"], "V|");
            Assert.AreEqual(detailsInfo.Rows[1]["secondMM"], "298");
            Assert.AreEqual(detailsInfo.Rows[1]["secondEdge"], "V|V");
            Assert.AreEqual(detailsInfo.Rows[1]["Количество"], "2");
            Assert.AreEqual(detailsInfo.Rows[1]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[2]["Наименование"], "полок нет");
            Assert.AreEqual(detailsInfo.Rows[2]["firstMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[2]["firstEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[2]["secondEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[2]["Количество"], "0");
            Assert.AreEqual(detailsInfo.Rows[2]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[4]["Наименование"], "задняя стенка");
            Assert.AreEqual(detailsInfo.Rows[4]["firstMM"], "");
            Assert.AreEqual(detailsInfo.Rows[4]["secondMM"], "");
            Assert.AreEqual(detailsInfo.Rows[4]["Количество"], "");
            Assert.AreEqual(detailsInfo.Rows[4]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[6]["Наименование"], "фасад");
            Assert.AreEqual(detailsInfo.Rows[6]["firstMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[6]["firstEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[6]["secondMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[6]["secondEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[6]["Количество"], "1");
            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[8]["Наименование"], "задняя панель");
            Assert.AreEqual(detailsInfo.Rows[8]["firstMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[8]["secondMM"], "0");
            Assert.AreEqual(detailsInfo.Rows[8]["Количество"], "1");
            Assert.AreEqual(detailsInfo.Rows[8]["Примечание"], "");

            var shelfsInfo = result.ShelfInfo;
            Assert.AreEqual(shelfsInfo.Columns.Count, 1);

            var furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли "], "0");
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на полкодержатель"], "0");
            Assert.AreEqual(furnitureInfo.Rows[0]["полки на полкодержатель"], "0");
            Assert.AreEqual(furnitureInfo.Rows[0]["ручки"], "1");
            Assert.AreEqual(furnitureInfo.Rows[0]["навесы обычные"], "2");
            Assert.AreEqual(furnitureInfo.Rows[0]["плита, м.кв. 10"], "164,496");
            Assert.AreEqual(furnitureInfo.Rows[0]["задняя стенка ДВП/фанера"], "0");

            input.Rows[0]["Задняя стенка"]="на гвозди";
            input.Rows[0]["Кол-во полок"] = "ЛДСП 1";
            input.Rows[0]["Материал фасада"] = "ЛДСП вертик. фактура";
            input.Rows[0]["Тип фасада"] = "накладной";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[0]["secondMM"], "298");
            Assert.AreEqual(detailsInfo.Rows[0]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[1]["secondMM"], "298");
            Assert.AreEqual(detailsInfo.Rows[1]["Примечание"], "");

            Assert.AreEqual(detailsInfo.Rows[2]["Наименование"], "полка съёмная");
            Assert.AreEqual(detailsInfo.Rows[2]["firstMM"], "174");
            Assert.AreEqual(detailsInfo.Rows[2]["firstEdge"], "V|V");
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "291");
            Assert.AreEqual(detailsInfo.Rows[2]["secondEdge"], "V|V");
            Assert.AreEqual(detailsInfo.Rows[2]["Примечание"], "ЛДСП");

            Assert.AreEqual(detailsInfo.Rows[4]["firstMM"], "96");
            Assert.AreEqual(detailsInfo.Rows[4]["secondMM"], "196");
            Assert.AreEqual(detailsInfo.Rows[4]["Примечание"], "ДВП/фанера");

            Assert.AreEqual(detailsInfo.Rows[6]["firstMM"], "96");
            Assert.AreEqual(detailsInfo.Rows[6]["firstEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[6]["secondMM"], "196");
            Assert.AreEqual(detailsInfo.Rows[6]["secondEdge"], "|");
            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "ЛДСП вертик. факт.");

            Assert.AreEqual(detailsInfo.Rows[8]["firstMM"], "96");
            Assert.AreEqual(detailsInfo.Rows[8]["secondMM"], "198");
            Assert.AreEqual(detailsInfo.Rows[8]["Примечание"], "ДВП или фанера 4 мм");

            shelfsInfo = result.ShelfInfo;
            Assert.AreEqual(shelfsInfo.Rows[0]["полка 1"], "10");

            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли накладные"], "2");
            Assert.AreEqual(furnitureInfo.Rows[0]["плита, м.кв. 10"], "233,946");
            Assert.AreEqual(furnitureInfo.Rows[0]["задняя стенка ДВП/фанера"], "19,008");

            input.Rows[0]["Задняя стенка"] = "в четверть";
            input.Rows[0]["Крепление полки"] = "конфирмат";
            input.Rows[0]["Материал фасада"] = "ЛДСП гориз. фактура";
            input.Rows[0]["Режим расчёта"] = "ручн.";
            input.Rows[0]["Тип фасада"] = "вкладной ЛДСП";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[0]["firstEdge"], "V|I");
            Assert.AreEqual(detailsInfo.Rows[0]["Примечание"], "четверть 10*4 мм");

            Assert.AreEqual(detailsInfo.Rows[1]["firstEdge"], "V|I");
            Assert.AreEqual(detailsInfo.Rows[1]["Примечание"], "четверть 10*4 мм");

            Assert.AreEqual(detailsInfo.Rows[2]["Наименование"], "полка несъёмная");
            Assert.AreEqual(detailsInfo.Rows[2]["firstMM"], "180");

            Assert.AreEqual(detailsInfo.Rows[4]["firstMM"], "78");
            Assert.AreEqual(detailsInfo.Rows[4]["secondMM"], "178");
            Assert.AreEqual(detailsInfo.Rows[4]["Примечание"], "ДВП/фанера");

            Assert.AreEqual(detailsInfo.Rows[6]["firstMM"], "8");
            Assert.AreEqual(detailsInfo.Rows[6]["secondMM"], "9");
            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "ЛДСП гориз. факт.");

            Assert.AreEqual(detailsInfo.Rows[8]["firstMM"], "62");
            Assert.AreEqual(detailsInfo.Rows[8]["secondMM"], "162");

            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли вкладные"], "2");
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на конфирмат"], "8");

            input.Rows[0]["Задняя стенка"] = "в паз";
            input.Rows[0]["Кол-во полок"] = "ЛДСП 2";
            input.Rows[0]["Материал фасада"] = "на заказ глухой";
            input.Rows[0]["Крепление полки"] = "нагель";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[0]["Примечание"], "паз 10*4*16");

            Assert.AreEqual(detailsInfo.Rows[1]["Примечание"], "паз 10*4*16");

            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "275");

            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "глухой, на заказ");

            shelfsInfo = result.ShelfInfo;
            Assert.AreEqual(shelfsInfo.Rows[0]["полка 2"], "40");

            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на нагель"], "12");

            input.Rows[0]["Задняя стенка"] = "ЛДСП внутрь";
            input.Rows[0]["Кол-во полок"] = "стекло 1";
            input.Rows[0]["Материал фасада"] = "на заказ витрина";
            input.Rows[0]["Крепление полки"] = "конфирмат + нагель";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[2]["Наименование"], "полка стекло");
            Assert.AreEqual(detailsInfo.Rows[2]["firstMM"], "177");
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "285");
            Assert.AreEqual(detailsInfo.Rows[2]["Примечание"], "стекло");

            Assert.AreEqual(detailsInfo.Rows[4]["firstMM"], "80");
            Assert.AreEqual(detailsInfo.Rows[4]["secondMM"], "180");
            Assert.AreEqual(detailsInfo.Rows[4]["Примечание"], "ЛДСП");

            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "витрина, на заказ");

            Assert.AreEqual(detailsInfo.Rows[8]["firstMM"], "76");
            Assert.AreEqual(detailsInfo.Rows[8]["secondMM"], "178");
            Assert.AreEqual(detailsInfo.Rows[8]["Примечание"], "ЛДСП внутрь");

            shelfsInfo = result.ShelfInfo;
            Assert.AreEqual(shelfsInfo.Rows[0]["полка 1"], "5");

            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на конфирмат + нагель"], "8");
            Assert.AreEqual(furnitureInfo.Rows[0]["плита, м.кв. 10"], "178,024");
            Assert.AreEqual(furnitureInfo.Rows[0]["задняя стенка ЛДСП"], "0");

            input.Rows[0]["Кол-во полок"] = "ЛДСП 1";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "281");

            input.Rows[0]["Кол-во полок"] = "стекло 1";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "285");

            input.Rows[0]["Задняя стенка"] = "на гвозди";
            input.Rows[0]["Материал фасада"] = "на заказ особый";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "295");

            Assert.AreEqual(detailsInfo.Rows[6]["Примечание"], "особый, на заказ");

            input.Rows[0]["Задняя стенка"] = "в паз";
            module.SetupModule(input);
            result = module.Calculate();
            detailsInfo = result.DetailsInfo;
            Assert.AreEqual(detailsInfo.Rows[2]["secondMM"], "279");

            input.Rows[0]["Режим расчёта"] = "авт. мод.";
            module.SetupModule(input);
            result = module.Calculate();
            mainInfo = result.MainInfo;
            Assert.AreEqual(mainInfo.Rows[0]["Высота H"], "12");
            Assert.AreEqual(mainInfo.Rows[0]["Ширина W"], "13");

            input.Rows[0]["Режим расчёта"] = "ручн.";
            input.Rows[0]["Высота"] = 900;
            input.Rows[0]["Крепление полки"] = "конфирмат";
            input.Rows[0]["Глубина модуля (мм)"] = 500;
            module.SetupModule(input);
            result = module.Calculate();
            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли вкладные"], "3");
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на конфирмат"], "12");

            input.Rows[0]["Высота"] = 1600;
            input.Rows[0]["Крепление полки"] = "нагель";
            module.SetupModule(input);
            result = module.Calculate();
            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли вкладные"], "4");
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на нагель"], "16");

            input.Rows[0]["Высота"] = 2000;
            input.Rows[0]["Крепление полки"] = "конфирмат + нагель";
            module.SetupModule(input);
            result = module.Calculate();
            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли вкладные"], "5");
            Assert.AreEqual(furnitureInfo.Rows[0]["модуль на конфирмат + нагель"], "16");

            input.Rows[0]["Высота"] = 2400;
            module.SetupModule(input);
            result = module.Calculate();
            furnitureInfo = result.FurnitureInfo;
            Assert.AreEqual(furnitureInfo.Rows[0]["петли вкладные"], "0");
        }
    }
}