using System;
using System.Collections.Generic;
using System.Data;

namespace Automation.Infrastructure
{
    [Serializable]
    public abstract class BaseModule: ICloneable
    {

        public string Name { get; set; }
        public string Sсheme { get; set; }
        
        protected string BackPanelAssembly { get; set;}
        public string Number { get; set; }
        public string SubScheme { get; set; }
        public string IconPath { get; set; }

        public abstract void AddFacade();
        public abstract void DeleteFacade();
        public abstract void SetupModule(DataTable changedInfo);
        public abstract void GetInfoRows(DataTable table);
        public abstract DataTable GetInfoTable();

        public abstract DataTable GetEmptyTable();

        public abstract object Clone();

        public abstract Result Calculate();
    }

    [Serializable]
    public class Dimensions
    {

        public double Depth { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }


    }

    [Serializable]
    public class Facade
    {
        public List<FacadeRecord> _records;

        public Facade()
        {
           _records = new List<FacadeRecord>();
        }

        public void InitFacadeRecords(int numberRecords)
        {
            for (int i = 0; i < numberRecords; i++)
            {
                _records.Add(new FacadeRecord { NumberOnScheme = i+1});
            }
            
        }

    }

    [Serializable]
    public  class FacadeRecord
    {
        public int NumberOnScheme { get; set; }

        public string Type { get; set; }

        public double VerticalDimension { get; set; }

        public double HorisontalDimension { get; set; }

        public string Material { get; set; }

    }
}
