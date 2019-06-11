using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    class LdspAllDetailsBaseGroup: BaseGroup
    {
        public LdspAllDetailsBaseGroup(List<BaseModule> modules): base(modules)
        {
        }


        protected override void MapRow(DataRow resultRow, BaseModule module, DataRow row)
        {
            resultRow["№ модуля"] = module.Number;
            resultRow["№ детали"] = row["№"];
            resultRow["Наименование"] = row["Наименование"];
            resultRow["firstMM"] = row["firstMM"];
            resultRow["firstEdge"] = row["firstEdge"];
            resultRow["secondMM"] = row["secondMM"];
            resultRow["secondEdge"] = row["secondEdge"];
            resultRow["Количество"] = row["Количество"];
        }

        protected override bool IsEmptyRow(DataRow row)
        {
            return string.IsNullOrEmpty(row["№"].ToString()) &&
                   string.IsNullOrEmpty(row["Наименование"].ToString()) &&
                   string.IsNullOrEmpty(row["firstMM"].ToString()) &&
                   string.IsNullOrEmpty(row["firstEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["secondMM"].ToString()) &&
                   string.IsNullOrEmpty(row["secondEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["Количество"].ToString());
        }

        protected override void AddDetailsColumns(DataTable table)
        {
            table.Columns.Add("№ модуля");
            table.Columns.Add("№ детали");

            table.Columns.Add("Наименование");

            var firstColumn = new DataColumn
            {
                ColumnName = "firstMM",
                Caption = "ММ"
            };
            table.Columns.Add(firstColumn);

            var secondColumn = new DataColumn
            {
                ColumnName = "firstEdge",
                Caption = "Кромка"
            };
            table.Columns.Add(secondColumn);

            var thirdColumn = new DataColumn
            {
                ColumnName = "secondMM",
                Caption = "ММ"
            };
            table.Columns.Add(thirdColumn);

            var fourthColumn = new DataColumn
            {
                ColumnName = "secondEdge",
                Caption = "Кромка"
            };
            table.Columns.Add(fourthColumn);

            table.Columns.Add("Количество");
        }


    }
}
