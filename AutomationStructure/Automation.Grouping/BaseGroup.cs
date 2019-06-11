using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public abstract class BaseGroup
    {
        private readonly List<BaseModule> _modules;

        protected BaseGroup(List<BaseModule> modules)
        {
            _modules = modules;
        }


        public DataTable GetAllDetailsGroupInfo(string tableName)
        {
            var result = new DataTable();
            AddDetailsColumns(result);

            foreach (var module in _modules)
            {
                var detailsInfo = module.CalculationResult.GetInfoTableByName(tableName);

                foreach (DataRow row in detailsInfo.Rows)
                {
                    if (IsEmptyRow(row)) continue;

                    var resultRow = result.NewRow();
                    MapRow(resultRow, module, row);
                    result.Rows.Add(resultRow);
                }
            }
            return result;
        }

        protected abstract void MapRow(DataRow resultRow, BaseModule module, DataRow row);

        protected abstract bool IsEmptyRow(DataRow row);

        protected abstract void AddDetailsColumns(DataTable table);





    }
}