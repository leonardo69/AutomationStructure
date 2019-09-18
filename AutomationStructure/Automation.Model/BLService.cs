using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Automation.Grouping;
using Automation.Infrastructure;
using Automation.Model.MainModels;

namespace Automation.Model
{
    public class BlService
    {
        private Project _project;

        #region Project Methods

        public void MakeNewProject()
        {
            _project = new Project();
        }

        public Project GetCurrentProject()
        {
            return _project;
        }

        public void SetCurrentProject(Project project)
        {
            _project = project;
        }

        #endregion

        #region Category Methods

        public void AddNewProduct(string nameProduct)
        {
            _project.Categories.AddCategory(nameProduct);
        }

        #endregion
        

        #region Customer Methods

        public string GetTotalCustomerRecord()
        {
            return _project.Customer.GetTotalCustomerInfoRecord();
        }


        public void SetCustomer(List<string[]> customerRecord)
        {
            _project.Customer.SetInputData(customerRecord);
        }

        #endregion

        #region Modules Methods


        public void ReportModule(string moduleName, CategoryType categoryType, string pathToSave)
        {
            var category = _project.Categories.GetCategory(categoryType);
            var module = category.GetAllModules().FirstOrDefault(x => x.Number == moduleName);
            module?.CreateReport(pathToSave);
        }

        public bool IsModuleExist(string number, CategoryType type)
        {
            var category = _project.Categories.GetCategory(type);
            return category.IsModuleExist(number);
        }


        public void AddNewModule(NewModuleData data)
        {
            var category = _project.Categories.GetCategory(data);
            category.AddNewModule(data);
        }


        public List<string> GetModulesNamesByType(CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            return product.GetNamesModules();
        }

        public List<string> GetModulesNumbersByType(CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            return product.GetNumbersModules();
        }


        public string GetCategoryNameByType(CategoryType type)
        {
            var result = string.Empty;
            switch (type)
            {
                case CategoryType.KitchenUp:
                    result = "Кухня верхние модули";
                    break;
                case CategoryType.KitchenDown:
                    result = "Кухня нижние модули";
                    break;
            }

            return result;
        }


        public int GetCountModules(CategoryType type)
        {
            var count = _project.Categories.GetCountModules(GetCategoryNameByType(type));
            return count;
        }

        public DataTable GetDetailDataForModule(string moduleName, CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            var moduleInfo = product.GetModuleDetailInfoByNumber(moduleName);
            return moduleInfo;
        }

        public DataTable GetTotalModulesInfo(CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            var table = product.GetTotalDetailInfo();
            return table;
        }

        public void DeleteModule(string nameModule, CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            product.DeleteModule(nameModule);
        }

        public void AddSimilarModule(string similarName, CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            var module = product.GetCloneLastModule();
            module.Number = similarName;
            product.AddSimilarModule(module);
        }


        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, CategoryType type)
        {
            var category = _project.Categories.GetCategory(type);
            category.UpdateModule(moduleInfoTable, numberModule);
        }

        #endregion

        public void CreateModuleReport(string moduleName, string fileName)
        {
            var category = _project.Categories.GetCategory(CategoryType.KitchenUp);
            category.CreateModuleReport(moduleName, fileName);
        }

        public void CreateAllModulesReport(string fileName)
        {
            var category = _project.Categories.GetCategory(CategoryType.KitchenUp);
            category.CreateAllModulesReport(fileName);
        }

        

        public DataTable GetAllDetailsGroupInfo(string tableName)
        {
            var modules = _project.Categories.GetAllModules();
            return GroupingManager.GetAllDetailsGrouping(tableName, modules);
        }

        public DataTable GetCountGroupInfo(string tableName)
        {
            var modules = _project.Categories.GetAllModules();
            return GroupingManager.GetCountGrouping(tableName, modules);
        }
    }
}