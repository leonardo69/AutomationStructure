using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Automation.Infrastructure;
using Automation.Module.KitchenUpOneFacade.Calculation;
using Automation.Module.KitchenUpOneFacade.Core;
using Automation.Module.KitchenUpOneFacade.Report;
using Automation.Module.KitchenUpOneFacade.ResultTables;
using Xceed.Words.NET;

namespace Automation.Module.KitchenUpOneFacade
{
    [Serializable]
    public class KitchenUpOneFacade : BaseModule
    {
        private Core.Module _module;

        public KitchenUpOneFacade()
        {
            _module = new Core.Module();
        }


        public override void SetupModule(DataTable changedInfo)
        {
            var changedModule = ModuleMapper.Setup(changedInfo);
            _module = changedModule;
            CalculationResult = null;
        }

        public override void GetInfoRows(DataTable table)
        {
            ModuleMapper.AddModuleInfoRows(table, _module);
        }


        public override DataTable GetInfoTable()
        {
            var table = GetEmptyTable();
            GetInfoRows(table);
            return table;
        }

        public override DataTable GetEmptyTable()
        {
            return ModuleMapper.GetEmptyModuleTable();
        }

        public override object Clone()
        {
            using (var stream = new MemoryStream())
            {
                if (!GetType().IsSerializable) return new object();

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }

        public override Result Calculate()
        {

            var calculator = new Calculator(
                _module.Dimensions,
                _module.Facades,
                _module.ShelfAssembly,
                _module.ShelfsCount,
                Name,
                Scheme,
                BackPanelAssembly,
                Number,
                SubScheme,
                IconPath,
                _module.Canopies)
            {
//                Name = Name,
                Scheme = Scheme,
                //IconPath = IconPath,
                BackPanelAssembly = BackPanelAssembly,
                Number = Number,
                SubScheme = SubScheme,
                Dimensions = _module.Dimensions,
                Facades = _module.Facades,
                ShelfAssembly = _module.ShelfAssembly,
                ShelvesCount = _module.ShelfsCount,
                Canopies = _module.Canopies
            };

            var detailsPresenter = new DetailsPresenter();
            var mainPresenter = new MainInfoPresenter(Name, IconPath, _module.Dimensions);
            var furniturePresenter = new FurniturePresenter
            {
                Facades = _module.Facades,
                BackPanelAssembly = _module.BackPanelAssembly,
                ShelfAssembly = _module.ShelfAssembly
            };
            var shelfPresenter = new ShelfPresenter();
            var loopPresenter = new LoopPresenter();

            CalculationResult = new Result
            {
                ModuleName = mainPresenter.GetModuleName(),
                ImagePath = mainPresenter.GetModuleBigImagePath(),
                MainInfo = mainPresenter.GetDimensionInfo(),
                DetailsInfo = detailsPresenter.GetDetailsInfo(calculator.GetDetails()),
                FurnitureInfo = furniturePresenter.GetFurnitureInfo(calculator.GetFurnitureItem()),
                ShelfInfo = shelfPresenter.GetShelfInfo(calculator.GetShelfItem()),
                LoopsInfo = loopPresenter.GetLoopInfo(calculator.GetLoopsItem())
            };

            return CalculationResult;
        }

        public override void CreateReport(string pathToSave)
        {
            if(CalculationResult == null) throw new Exception("Сначала выполните расcчёт");
            var reportManager = new Reports();
            reportManager.CreateReport(CalculationResult, pathToSave);
        }

        public override void AddReportContent(DocX doc)
        {
            if (CalculationResult == null) throw new Exception("Сначала выполните расcчёт");
            var reportManager = new Reports();
            reportManager.AddReportContent(doc, CalculationResult);
        }
    }
}