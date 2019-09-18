using System.Collections.Generic;
using System.Data;
using Automation.Module.KitchenUp.Calculation;

namespace Automation.Module.KitchenUp.ResultTables
{
    public class DetailsPresenter
    {
        public DataTable GetDetailsInfo(List<DetailsItem> details)
        {
            var detailsInfo = new DataTable { TableName = "Детальная информация" };
            AddDetailsInfoColumns(detailsInfo);
            foreach (var item in details)
            {
                if (item.Name == "задняя стенка"|| item.Name=="фасад")
                {
                    detailsInfo.Rows.Add();
                }

                detailsInfo.Rows.Add(item.ConvertToDataRow());

            }

            return detailsInfo;
        }


        private void AddDetailsInfoColumns(DataTable detailsInfo)
        {
            detailsInfo.Columns.Add("№");
            detailsInfo.Columns.Add("Наименование");

            var firstColumn = new DataColumn { ColumnName = "firstMM", Caption = "Длина" };
            detailsInfo.Columns.Add(firstColumn);

            var secondColumn = new DataColumn { ColumnName = "firstEdge", Caption = "Кромка" };
            detailsInfo.Columns.Add(secondColumn);

            var thirdColumn = new DataColumn { ColumnName = "secondMM", Caption = "Ширина" };
            detailsInfo.Columns.Add(thirdColumn);

            var fourthColumn = new DataColumn { ColumnName = "secondEdge", Caption = "Кромка" };
            detailsInfo.Columns.Add(fourthColumn);

            detailsInfo.Columns.Add("Количество");
            detailsInfo.Columns.Add("Примечание");
        }

    }
}
