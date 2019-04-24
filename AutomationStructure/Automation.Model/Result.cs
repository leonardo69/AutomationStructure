using System.Data;

namespace Automation.Model
{ 
    public class Result
    {
        public string ModuleName { get; set; }
        public string ImagePath { get; set; }
        public DataTable DimensionInfo { get; set; }
        public DataTable DetailsInfo { get; set; }
        public DataTable ShelfInfo { get; set; }
        public DataTable FurnitureInfo { get; set; }
        public DataTable LoopsInfo { get; set; }
    }
}
