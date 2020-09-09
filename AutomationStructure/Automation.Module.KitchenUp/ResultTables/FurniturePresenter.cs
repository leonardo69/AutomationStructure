using System;
using System.Data;
using System.Globalization;
using Automation.Infrastructure;
using Automation.Module.KitchenUpOneFacade.Calculation;

namespace Automation.Module.KitchenUpOneFacade.ResultTables
{
    class FurniturePresenter
    {

        public Facades Facades;
        public string ShelfAssembly;
        public string BackPanelAssembly { get; set; }


        public DataTable GetFurnitureInfo(FurnitureItem item)
        {
            var furnitureInfo = new DataTable { TableName = "Фурнитура" };
            AddFurnitureInfoColumns(furnitureInfo);
            // Add first row item
            furnitureInfo.Rows.Add(item.ConvertToDataRow());

            return furnitureInfo;
        }

        private void AddFurnitureInfoColumns(DataTable furnitureInfo)
        {
            furnitureInfo.Columns.Add("наименование");
            furnitureInfo.Columns.Add("петли " + Mat_txt_1_2());
            furnitureInfo.Columns.Add("модуль на " + Mat_txt_2_2());
            furnitureInfo.Columns.Add("полки на " + Mat_txt_3_2());
            furnitureInfo.Columns.Add("ручки");
            furnitureInfo.Columns.Add("навесы " + Mat_txt_5_2());
            furnitureInfo.Columns.Add("плита, м.кв. " + Mat_txt_6_2());
            furnitureInfo.Columns.Add("кромка, м " + Mat_txt_7_2());
            furnitureInfo.Columns.Add("задняя стенка " + Mat_txt_8_2());
        }

        private string Mat_txt_1_2()
        {
            //var type = Facades.Records[0].Type;
            //switch (type)
            //{
            //    case null:
            //        return "";
            //    case "накладной":
            //        return "накладные";
            //    default:
            //        return type.Substring(0, Math.Min(8, type.Length)) == "вкладной" ? "вкладные" : "";
            //}

            return "накладные";
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


    }
}
