using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Infrastructure;

namespace Automation.Model.MainModels
{
    [Serializable]
    public class Category
    {
        public CategoryType Type { get; set; }
        
        private List<BaseModule> _modules;

        public List<string> GetNamesModules()
        {
            return _modules.Select(module => module.Name).ToList();
        }


        public Category(string nameProduct)
        {
            _modules = new List<BaseModule>();
            Type = GetType(nameProduct);
        }

        public int GetCountModules()
        {
            return _modules.Count;
        }

        public void AddNewModule(NewModuleData data)
        {
            var module = GetModuleByType();
            module.Name = data.Name;
            module.Number = data.Number;
            module.SubScheme = data.SubScheme;
            module.Scheme =  data.Scheme;
            module.IconPath = data.SubSchemeIconPath;
            _modules.Add(module);
        }

        private BaseModule GetModuleByType()
        {
            var module = ModuleFactory.ModuleFactory.GetModule(Type);
            return module;
        }
        

        public void DeleteModule(string moduleName)
        {
            var module = _modules.First(x => x.Number == moduleName);
            _modules.Remove(module);

        }

        public void AddFacade(string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            module.AddFacade();
        }

        public void DeleteFacade(string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            module.DeleteFacade();
        }

        public void UpdateModule(DataTable data, string moduleNumber)
        {
            var module = _modules.FirstOrDefault(x => x.Number == moduleNumber);
            if (module == null)
                throw new ArgumentException($"Модуль {moduleNumber} не найден");
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

        public DataTable GetModuleDetailInfoByNumber(string moduleNumber)
        {
            var module = _modules.First(x => x.Number == moduleNumber);
            DataTable table = module.GetInfoTable();
            return table;
        }

        public BaseModule GetCloneLastModule()
        {
            var lastModule =  _modules.Last();
            var newCloneModule =  (BaseModule)lastModule.Clone();
            return newCloneModule;
        }

        public void AddSimilarModule(BaseModule module)
        {
            _modules.Add(module);
        }

        public List<string> GetNumbersModules()
        {
            return _modules.Select(module => module.Number).ToList();
        }

        public bool IsModuleExist(string number)
        {
            return _modules.Exists(module => module.Number == number);

        }

        public List<BaseModule> GetAllModules()
        {
            return _modules;
        }

        public void CreateModuleReport(string moduleName, string fileName)
        {
            var module = _modules.First(x => x.Number == moduleName);
            module.CreateReport(fileName);
        }
    }
}
