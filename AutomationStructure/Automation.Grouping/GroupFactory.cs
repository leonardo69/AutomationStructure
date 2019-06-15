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
                case "DetailsInfo": return new LdspGroup(modules);
                case "ShelfInfo": return new ShelfGroup(modules);
                case "FurnitureInfo": return new FurnitureGroup(modules);
                case "LoopsInfo": return new LoopsGroup(modules);
                default: throw new Exception("Неизвестное название таблицы");
            }
        }
    }
}
