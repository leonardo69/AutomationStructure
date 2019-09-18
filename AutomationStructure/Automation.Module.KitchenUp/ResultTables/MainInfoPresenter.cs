using System.Data;
using Automation.Infrastructure;

namespace Automation.Module.KitchenUp.ResultTables
{
    public class MainInfoPresenter
    {
        /// <summary>
        /// Основные размеры модуля
        /// </summary>
        public Dimensions Dimensions { get; set;}
        public string IconPath { get; set; }

        public string Name { get; set; }

        public MainInfoPresenter(string moduleName, string iconPath, Dimensions dimensions)
        {
            Name = moduleName;
            IconPath = iconPath;
            Dimensions = dimensions;
        }

        public string GetModuleName()
        {
            return Name;
        }

        public string GetModuleBigImagePath()
        {
            return BigImagePath;
        }

        private string BigImagePath
        {
            get
            {
                var fullImagePath = IconPath.Split('_');
                return fullImagePath[0] + "_" +
                       fullImagePath[1] + "_result.png";
            }
        }

        public DataTable GetDimensionInfo()
        {
            var mainInfo = new DataTable { TableName = "Основная информация" };
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


    }
}
