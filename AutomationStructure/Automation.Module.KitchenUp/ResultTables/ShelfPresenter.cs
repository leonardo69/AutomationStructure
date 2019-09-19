using System.Data;
using System.Linq;
using Automation.Module.KitchenUpOneFacade.Calculation;

namespace Automation.Module.KitchenUpOneFacade.ResultTables
{
    public class ShelfPresenter
    {
        internal DataTable GetShelfInfo(ShelfItem item)
        {
            var shelfInfo = new DataTable { TableName = "Полки" };
            var shelfsCount = item.Count;
            shelfInfo.Columns.Add("наименование");
            for (var i = 1; i <= shelfsCount; i++)
            {
                shelfInfo.Columns.Add("полка " + i);
            }

            var rowData = item.ConvertToDataRow().ToList();
            rowData.Insert(0,"размер");
            shelfInfo.Rows.Add(rowData.ToArray());
            return shelfInfo;
        }
    }
}