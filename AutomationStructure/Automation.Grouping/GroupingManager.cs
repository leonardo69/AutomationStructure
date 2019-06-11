using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public static class GroupingManager
    {
        public static  DataTable GetAllDetailsGrouping(string tableName, List<BaseModule> modules)
        {
            var group = GroupFactory.GetGroup(tableName, modules);
            return group.GetAllDetailsGroupInfo(tableName);
        }

       

    }
}
