using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Model
{
    public class ThicknessSpecificData
    {
        private List<ThicknessSpecificRecord> _main;
        private List<ThicknessSpecificRecord> _shelf;
        private List<ThicknessSpecificRecord> _facade;


        public ThicknessSpecificData()
        {
            _main = new List<ThicknessSpecificRecord>();
            _shelf = new List<ThicknessSpecificRecord>();
            _facade = new List<ThicknessSpecificRecord>();
        }

        private void InitMainRecords()
        {
            _main.Add(new ThicknessSpecificRecord { PartModule = "Перед (видимая)"});
            _main.Add(new ThicknessSpecificRecord { PartModule = "Верх" });
            _main.Add(new ThicknessSpecificRecord { PartModule = "Низ" });
            _main.Add(new ThicknessSpecificRecord { PartModule = "Задняя часть" });

        }

        private void InitShelfRecords()
        {
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Перед (видимая)"} );
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Лево/право"} );
            _shelf.Add(new ThicknessSpecificRecord { PartModule = "Задняя часть"} );
        }

        private void InitFacadeRecords()
        {
            _facade.Add(new ThicknessSpecificRecord {PartModule = "Периметр фасада"});
        }


    }

    class ThicknessSpecificRecord
    {
        public string Color { get; set; }
        public string PartModule { get; set; }
        public string Thickness { get; set; }
    }
}
