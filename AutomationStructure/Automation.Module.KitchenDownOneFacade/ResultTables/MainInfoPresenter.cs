using System.Data;
using System.Drawing;
using Automation.Infrastructure;

namespace Automation.Module.KitchenDownOneFacade.ResultTables
{
    public class MainInfoPresenter
    {
        /// <summary>
        /// Основные размеры модуля
        /// </summary>
        public Dimensions Dimensions { get; set;}
        public Image ResultImage { get; set; }

        public string Name { get; set; }

        public MainInfoPresenter(string moduleName, Image resultImage, Dimensions dimensions)
        {
            Name = moduleName;
            ResultImage = resultImage;
            Dimensions = dimensions;
        }

        public string GetModuleName()
        {
            return Name;
        }

        public Image GetModuleBigImagePath()
        {
            return ResultImage;
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
