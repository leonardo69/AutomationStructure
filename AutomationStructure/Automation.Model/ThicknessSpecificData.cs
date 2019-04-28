using System.Collections.Generic;

namespace Automation.Model
{
    public class ThicknessSpecificData
    {
        private readonly List<ThicknessSpecificRecord> _main;
        private readonly List<ThicknessSpecificRecord> _shelf;
        private readonly List<ThicknessSpecificRecord> _facade;


        public ThicknessSpecificData()
        {
            _main = new List<ThicknessSpecificRecord>();
            _shelf = new List<ThicknessSpecificRecord>();
            _facade = new List<ThicknessSpecificRecord>();
        }

        private void InitMainRecords()
        {
            _main.Add(new ThicknessSpecificRecord { PartModule = "Перед (видимая)" });
            _main.Add(new ThicknessSpecificRecord { PartModule = "Верх" });
            _main.Add(new ThicknessSpecificRecord { PartModule = "Низ" });
            _main.Add(new ThicknessSpecificRecord { PartModule = "Задняя часть" });

        }

        private void InitShelfRecords()
        {
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Перед (видимая)" });
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Лево/право" });
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Задняя часть" });
        }

        private void InitFacadeRecords()
        {
            _facade.Add(new ThicknessSpecificRecord { PartModule = "Периметр фасада" });
        }


    }

    class ThicknessSpecificRecord
    {
        public string Color { get; set; }
        public string PartModule { get; set; }
        public string Thickness { get; set; }
    }
}
