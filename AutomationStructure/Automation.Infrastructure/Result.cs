using System;
using System.Data;

namespace Automation.Infrastructure
{
    [Serializable]
    public class Result
    {
        public string ModuleName { get; set; }
        public string ImagePath { get; set; }
        public DataTable MainInfo { get; set; }
        public DataTable DetailsInfo { get; set; }
        public DataTable ShelfInfo { get; set; }
        public DataTable FurnitureInfo { get; set; }
        public DataTable LoopsInfo { get; set; }

        public DataTable GetInfoTableByName(string tableName)
        {
            switch (tableName)
            {
                case "MainInfo": return MainInfo;
                case "DetailsInfo": return DetailsInfo;
                case "ShelfInfo": return ShelfInfo;
                case "FurnitureInfo": return FurnitureInfo;
                case "LoopsInfo": return LoopsInfo;
                default: throw new Exception("Таблица не найдена");
            }
        }
    }
}
