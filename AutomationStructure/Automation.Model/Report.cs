using System.Data;

namespace Automation.Model
{
    public static class Report
    {
        public static DataTable GetLdspInfo()
        {
            var table = new DataTable();
            table.Columns.Add("Номер");
            table.Columns.Add("Размер вдоль листа");
            table.Columns.Add("Кромка 1.");
            table.Columns.Add("Кромка 2.");
            table.Columns.Add("Размер поперёк листа");
            table.Columns.Add("Кромка 1");
            table.Columns.Add("Кромка 2");
            table.Columns.Add("Количество");
            table.Columns.Add("Примечание");

            var row = table.NewRow();
            table.Rows.Add(row);
            return table;
        }

        public static DataTable GetBackPanelAssemblyInfo()
        {
            var table = new DataTable();
            table.Columns.Add("Номер");
            table.Columns.Add("Размер вдоль листа");
            table.Columns.Add("Размер поперёк листа");
            table.Columns.Add("Количество");
            table.Columns.Add("Примечание");

            var row = table.NewRow();
            table.Rows.Add(row);
            return table;
        }

        public static DataTable GetFurnitureInfo()
        {
            var table = new DataTable();
            table.Columns.Add("Уточнить");
            return table;
        }


        public static DataTable GetFasadeInfo()
        {
            var table = new DataTable();
            table.Columns.Add("Высота");
            table.Columns.Add("Ширина");
            table.Columns.Add("Тип");
            table.Columns.Add("Примечание");

            var row = table.NewRow();
            table.Rows.Add(row);
            return table;
        }
    }
}