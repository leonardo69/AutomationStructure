using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public class FacadeGroup : IBaseGroup
    {
        // TODO: move to constants
        // Make refactoring

        private readonly List<BaseModule> _modules;
        private const string LDSP_TABLE_NAME = "DetailsInfo";

        public FacadeGroup(List<BaseModule> modules)
        {
            _modules = modules;
        }

        public DataTable GetAllDetailsGroupInfo()
        {
            var result = new DataTable();
            AddDetailsColumns(result);

            foreach (var module in _modules)
            {
                var infoTable = module.CalculationResult.GetInfoTableByName(LDSP_TABLE_NAME);

                foreach (DataRow row in infoTable.Rows)
                {
                    if (IsEmptyRow(row) || !IsFacadeRow(row)) continue;

                    var resultRow = result.NewRow();
                    MapRow(resultRow, module, row);
                    result.Rows.Add(resultRow);
                }
            }
            return result;
        }

        private bool IsFacadeRow(DataRow row) => row["Наименование"].ToString().Contains("фасад");

        private void MapRow(DataRow resultRow, BaseModule module, DataRow row)
        {
            resultRow["№ модуля"] = module.Number;
            resultRow["№ детали"] = row["№"];
            resultRow["Наименование"] = row["Наименование"];
            resultRow["firstMM"] = Math.Round(Convert.ToDecimal(row["firstMM"]), 0); 
            resultRow["firstEdge"] = row["firstEdge"];
            resultRow["secondMM"] = Math.Round(Convert.ToDecimal(row["secondMM"]), 0);
            resultRow["secondEdge"] = row["secondEdge"];
            resultRow["Количество"] = row["Количество"];
        }

        private bool IsEmptyRow(DataRow row)
        {
            return string.IsNullOrEmpty(row["Количество"].ToString()) ||
                   string.IsNullOrEmpty(row["№"].ToString()) &&
                   string.IsNullOrEmpty(row["Наименование"].ToString()) &&
                   string.IsNullOrEmpty(row["firstMM"].ToString()) &&
                   string.IsNullOrEmpty(row["firstEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["secondMM"].ToString()) &&
                   string.IsNullOrEmpty(row["secondEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["Количество"].ToString());
        }

        private void AddDetailsColumns(DataTable table)
        {
            table.Columns.Add("№ модуля");
            table.Columns.Add("№ детали");

            table.Columns.Add("Наименование");

            var firstColumn = new DataColumn { ColumnName = "firstMM", Caption = "ММ" };
            var secondColumn = new DataColumn { ColumnName = "firstEdge", Caption = "Кромка" };
            var thirdColumn = new DataColumn { ColumnName = "secondMM", Caption = "ММ" };
            var fourthColumn = new DataColumn { ColumnName = "secondEdge", Caption = "Кромка" };

            table.Columns.Add(firstColumn);
            table.Columns.Add(secondColumn);
            table.Columns.Add(thirdColumn);
            table.Columns.Add(fourthColumn);
            table.Columns.Add("Количество");
        }
        
        public DataTable GetCountGroupInfo()
        {
            var result = new DataTable();
            AddCountGroupColumns(result);

            var rows = new List<DataRow>();

            foreach (var module in _modules)
            {
                var infoTable = module.CalculationResult.GetInfoTableByName(LDSP_TABLE_NAME);

                foreach (DataRow row in infoTable.Rows)
                {
                    if (IsEmptyRow(row) || !IsFacadeRow(row)) continue;

                    rows.Add(row);
                }
            }

            var groupRows = rows
                .Select(x =>
                    new {
                        FirstMM = x["FirstMM"],
                        FirstEdge = x["FirstEdge"],
                        SecondMM = x["SecondMM"],
                        SecondEdge = x["SecondEdge"],
                        Count = x["Количество"],
                        Mark = x["Примечание"]
                    }
                )
                .GroupBy(g => new { g.FirstEdge, g.FirstMM, g.SecondEdge, g.SecondMM, g.Mark })
                .Select(s =>
                {
                    var row = result.NewRow();
                    row["FirstMM"] = Math.Round(Convert.ToDecimal(s.Key.FirstMM), 0);
                    row["FirstEdge"] = s.Key.FirstEdge;
                    row["SecondMM"] = Math.Round(Convert.ToDecimal(s.Key.SecondMM), 0);
                    row["SecondEdge"] = s.Key.SecondEdge;
                    row["Примечание"] = s.Key.Mark.ToString().
                                        Replace("ЛДСП гориз. факт.", "Из ЛДСП модуля").
                                        Replace("ЛДСП вертик. факт.", "Из ЛДСП модуля");
                    row["Количество"] = s.Sum(x => Math.Round(Convert.ToDecimal(x.Count), 2));
                    return row;
                })
                .ToList();

            result.Rows.Clear();

            groupRows.ForEach(row => result.Rows.Add(row));

            return result;
        }

        private void AddCountGroupColumns(DataTable result)
        {
            var firstColumn = new DataColumn { ColumnName = "firstMM", Caption = "Длина ММ" };
            var secondColumn = new DataColumn { ColumnName = "firstEdge", Caption = "Кромка" };
            var thirdColumn = new DataColumn { ColumnName = "secondMM", Caption = "Ширина ММ" };
            var fourthColumn = new DataColumn { ColumnName = "secondEdge", Caption = "Кромка" };

            result.Columns.Add(firstColumn);
            result.Columns.Add(secondColumn);
            result.Columns.Add(thirdColumn);
            result.Columns.Add(fourthColumn);
            result.Columns.Add("Количество");
            result.Columns.Add("Примечание");
        }

    }
}