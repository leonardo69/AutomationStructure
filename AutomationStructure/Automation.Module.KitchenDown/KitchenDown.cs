using System;
using System.Data;
using Automation.Infrastructure;
using Xceed.Words.NET;

namespace Automation.Module.KitchenDown
{
    public class KitchenDown:BaseModule
    {
        public KitchenDown()
        {
            _facade = new Facade();
        }


        public string ShelfPO { get; set; }

        public string ShelfMinusTwoMM { get; set; }

        public string ShelfForRazdel { get; set; }

        public string ShelfGlass { get; set; }
        
        Facade _facade;


        public override void AddFacade()
        {
            throw new NotImplementedException();
        }

        public override void DeleteFacade()
        {
            throw new NotImplementedException();
        }

        public override void SetupModule(DataTable changedInfo)
        {
            throw new NotImplementedException();
        }

        public override void GetInfoRows(DataTable table)
        {
            throw new NotImplementedException();
        }

        public override DataTable GetInfoTable()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetEmptyTable()
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override Result Calculate()
        {
            return null;
        }

        public override void CreateReport(string pathToSave)
        {
            throw new NotImplementedException();
        }

        public override void AddReportContent(DocX doc)
        {
            throw new NotImplementedException();
        }

        //TODO:Мб принимать строки?
        public void SetupData(params string[] parameters )
        {
            //присваиваем значения переменным
        }
    }

   
}
