using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    internal class LoopsGroup : BaseGroup
    {
        public LoopsGroup(List<BaseModule> modules) : base(modules)
        {
        }

        protected override void AddCountGroupColumns(DataTable result)
        {
            throw new System.NotImplementedException();
        }

        protected override void AddDetailsColumns(DataTable table)
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsEmptyRow(DataRow row)
        {
            throw new System.NotImplementedException();
        }

        protected override void MapRow(DataRow resultRow, BaseModule module, DataRow row)
        {
            throw new System.NotImplementedException();
        }
    }
}