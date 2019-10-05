using System.Collections.Generic;
using System.Data;
using Automation.Module.KitchenDownOneFacade.Calculation;

namespace Automation.Module.KitchenDownOneFacade.ResultTables
{
    public class LoopPresenter
    {
        internal DataTable GetLoopInfo(List<LoopsItem> items)
        {
            var loopsInfo = new DataTable {TableName = "Петли"};
            loopsInfo.Columns.Add("Петли");
            loopsInfo.Columns.Add("1");
            loopsInfo.Columns.Add("2");
            loopsInfo.Columns.Add("3");
            loopsInfo.Columns.Add("4");

            foreach (var item in items)
            {
                loopsInfo.Rows.Add(item.ConvertToDataRow());
            }

            return loopsInfo;
        }
    }
}