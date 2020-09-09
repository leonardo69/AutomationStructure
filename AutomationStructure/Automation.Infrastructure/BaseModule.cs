using System;
using System.Collections.Generic;
using System.Data;
using Xceed.Words.NET;

namespace Automation.Infrastructure
{
    [Serializable]
    public abstract class BaseModule: ICloneable
    {

        public string Name { get; set; }
        public string Scheme { get; set; }
        protected string BackPanelAssembly { get; set;}

        //public string Number { get; set; }
        //public string IconPath { get; set; }
        public Result CalculationResult { get; set; }

        public abstract void SetupModule(DataTable changedInfo);
        public abstract void GetInfoRows(DataTable table);
        public abstract DataTable GetInfoTable();

        public abstract DataTable GetEmptyTable();

        public abstract object Clone();

        public abstract Result Calculate();

        public abstract void CreateReport(string pathToSave);

        public abstract void AddReportContent(DocX doc);
    }

    /// <summary>
    /// Размеры модуля
    /// </summary>
    [Serializable]
    public class Dimensions
    {
        /// <summary>
        /// Глубина модуля
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Высота модуля
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Ширина модуля
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Цоколь
        /// </summary>
        public double Pedestal { get; set; }

        /// <summary>
        /// Специальный размер
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Специальный размер
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Специальный размер
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Специальный размер
        /// </summary>
        public double D { get; set; }
    }

    /// <summary>
    /// Фасады
    /// </summary>
    [Serializable]
    public class Facades
    {
        public List<FacadeRecord> Records;

        public Facades()
        {
           Records = new List<FacadeRecord>();
        }

        public void InitFacadeRecords(int numberRecords)
        {
            for (int i = 0; i < numberRecords; i++)
            {
                Records.Add(new FacadeRecord { NumberOnScheme = i+1});
            }
            
        }

    }

    [Serializable]
    public  class FacadeRecord
    {
        public int NumberOnScheme { get; set; }

        //public string Type { get; set; }

        public double VerticalDimension { get; set; }

        public double HorizontalDimension { get; set; }

        public string Material { get; set; }

    }
}
