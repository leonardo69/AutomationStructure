using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public class FurnitureGroup : IBaseGroup
    {
        private readonly List<BaseModule> _modules;
        private const string FURNITURE_TABLE_NAME = "FurnitureInfo";

        public FurnitureGroup(List<BaseModule> modules)
        {
            _modules = modules;
        }

        public DataTable GetAllDetailsGroupInfo()
        {
            var result = new DataTable();
            var columns = GetDynamicColumns();
            AddDetailsColumns(result, columns);

            foreach (var module in _modules)
            {
                var infoTable = module.CalculationResult.GetInfoTableByName(FURNITURE_TABLE_NAME);

                foreach (DataRow row in infoTable.Rows)
                {
                    var resultRow = result.NewRow();
                    MapRow(resultRow, module, row, infoTable.Columns);
                    result.Rows.Add(resultRow);
                }
            }
            return result;
        }

        private List<DataColumn> GetDynamicColumns()
        {
            var columnsInfo = new Dictionary<string, DataColumn>();
            foreach (var module in _modules)
            {
                var infoTable = module.CalculationResult.GetInfoTableByName(FURNITURE_TABLE_NAME);
                var infoTableColumns = infoTable.Columns;
                foreach (DataColumn column in infoTableColumns)
                {
                    if (!columnsInfo.ContainsKey(column.ColumnName))
                    {
                        columnsInfo.Add(column.ColumnName, column);
                    }
                }
            }

            var columns = columnsInfo.Values.ToList();
            return columns;
        }
        
        private void AddDetailsColumns(DataTable table, List<DataColumn> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));

            table.Columns.Add(new DataColumn("№ модуля"));
            foreach (var column in columns)
            {   
                if(column.ColumnName == "наименование") continue;
                table.Columns.Add(new DataColumn(column.ColumnName));
            }
        }
        
        private void MapRow(DataRow resultRow, BaseModule module, DataRow row, DataColumnCollection columns)
        {
            resultRow["№ модуля"] = module.Name;

            foreach (DataColumn column in columns)
            {
                if(column.ColumnName == "наименование") continue;
                resultRow[column.ColumnName] = row[column.ColumnName];
            }
        }
        
        public DataTable GetCountGroupInfo()
        {
            var resultTable = GetAllDetailsGroupInfo();
            resultTable.Columns.Remove("№ модуля");

            var aggregateRow = resultTable.NewRow();

            foreach (DataColumn column in resultTable.Columns)
            {
                var columnValues = resultTable.Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<string>(column.ColumnName)).ToList();

                var aggregateValue = columnValues.Sum(stringValue => string.IsNullOrEmpty(stringValue)? 0 : double.Parse(stringValue));

                aggregateRow[column.ColumnName] = aggregateValue;
            }

            resultTable.Rows.Clear();
            resultTable.Rows.Add(aggregateRow);
            return resultTable;
        }
    }
}