using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Infrastructure;
using Xceed.Words.NET;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class Category
    {
        public CategoryType Type { get; set; }
        
        private List<BaseModule> _modules;

        public List<string> GetNamesModules() => _modules.Select(module => module.Name).ToList();

        public Category(string name)
        {
            _modules = new List<BaseModule>();
            Type = GetType(name);
        }

        public int GetCountModules() => _modules.Count;

        public void AddNewModule(NewModuleData data)
        {
            var module = ModuleFactory.ModuleFactory.GetModule(data.ModuleInfo.BuildType, data.Type, data.Name, data.ModuleInfo.Name);
            module.Name = data.Name;
            _modules.Add(module);
        }


        public void DeleteModule(string name)
        {
            var module = _modules.First(x => x.Name == name);
            _modules.Remove(module);
        }
 

        public void UpdateModule(DataTable data, string name)
        {
            var module = _modules.FirstOrDefault(x => x.Name == name);
            if (module == null)
                throw new ArgumentException($"Модуль {name} не найден");
            module.SetupModule(data);
        }
        
        public CategoryType GetType(string nameProduct)
        {
            var type=CategoryType.KitchenUp;
            
            switch (nameProduct)
            {
                case "Кухня верхние модули": type=CategoryType.KitchenUp;
                    break;
                case "Кухня нижние модули":
                    type = CategoryType.KitchenDown;
                    break;
            }
            return type;
        }
      
        public DataTable GetTotalDetailInfo()
        {
            DataTable emptyTable = null;
            if (_modules.Count!=0)
            {
                emptyTable = _modules[0].GetEmptyTable();
                foreach (var module in _modules)
                {
                    module.GetInfoRows(emptyTable);
                }
            }
            return emptyTable;
        }

        public DataTable GetModuleDetailInfoByName(string name)
        {
            var module = _modules.First(x => x.Name == name);
            DataTable table = module.GetInfoTable();
            return table;
        }

        public BaseModule GetCloneLastModule()
        {
            var lastModule =  _modules.Last();
            var newCloneModule =  (BaseModule)lastModule.Clone();
            return newCloneModule;
        }

        public void AddSimilarModule(BaseModule module) => _modules.Add(module);

        public List<string> GetModulesNames() => _modules.Select(module => module.Name).ToList();

        public bool IsModuleExist(string name) => _modules.Exists(module => module.Name == name);

        public List<BaseModule> GetAllModules() => _modules;

        public void CreateModuleReport(string moduleName, string fileName)
        {
            var module = _modules.First(x => x.Name == moduleName);
            module.CreateReport(fileName);
        }

        public void CreateAllModulesReport(string fileName)
        {
            var doc = DocX.Create(fileName);
            foreach (var module in _modules)
            {
                module.AddReportContent(doc);
            }
            doc.Save();
        }
    }
}
