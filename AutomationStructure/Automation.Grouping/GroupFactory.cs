using System;
using System.Collections.Generic;
using Automation.Infrastructure;

namespace Automation.Grouping
{
    public static class GroupFactory
    {
        public static IBaseGroup GetGroup(string tableName, List<BaseModule> modules)
        {
            switch (tableName)
            {
                case "DetailsInfo": return new LdspGroup(modules);
                case "ShelfInfo": return new BackPanelGroup(modules);
                case "FurnitureInfo": return new FurnitureGroup(modules);
                case "LoopsInfo": return new FacadeGroup(modules);
                default: throw new Exception("Неизвестное название таблицы");
            }
        }
    }
}
