using System;
using System.Collections.Generic;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public static class GroupFactory
    {
        public static BaseGroup GetGroup(string tableName, List<BaseModule> modules)
        {
            switch (tableName)
            {
                case "DetailsInfo": return new LdspAllDetailsBaseGroup(modules);
                case "ShelfInfo": return new LdspAllDetailsBaseGroup(modules);
                case "FurnitureInfo": return new LdspAllDetailsBaseGroup(modules);
                case "LoopsInfo": return new LdspAllDetailsBaseGroup(modules);
                default: throw new Exception("Неизвестное название таблицы");
            }
        }
    }
}
