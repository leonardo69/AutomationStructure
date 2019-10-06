using System;
using System.Collections.Generic;
using System.Data;
using Automation.Model;
using Automation.View;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Automation.Infrastructure;
using Automation.Model.MainModels;


namespace Automation
{
   public class Presenter
    {
        private readonly BlService _blService;
        private readonly MainForm _view;
        public ModuleManager Manager { get; set; }

       

        public Presenter(BlService model, MainForm view)
        {
            _blService = model;
            _view = view;
        }

        public void NewProject()
        {
            _blService.MakeNewProject();
        }

        internal void OpenProject(string pathToFile)
        {
            Project project;


            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(pathToFile,FileMode.OpenOrCreate))
            {
                project = (Project)formatter.Deserialize(fs);
            }

            _blService.SetCurrentProject(project);
            _view.SetCustomerTable(project.Customer._records);
            _view.UpdateCustomerString(project.Customer.GetTotalCustomerInfoRecord());
            _view.SetCategoriesTable(project.Categories);
            _view.ShowLayout();
            _view.ShowServiceMenu();
        }

        internal void SaveProject(string pathToFile)
        {
            var order = _blService.GetCurrentProject();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(pathToFile,FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,order);
            }
        }

        public void SetCustomer(List<string[]> customerRecord)
        {
            _blService.SetCustomer(customerRecord);
            UpdateCustomerString();
        }


       public void AddNewModule(NewModuleData data)
       {
           _blService.AddNewModule(data);
           UpdateModuleList(CategoryType.KitchenUp);
           UpdateModulesCount(CategoryType.KitchenUp);
           UpdateTotalModules(CategoryType.KitchenUp);
       }

       

        #region For Update View

        
        public void UpdateModuleList(CategoryType type)
        {
            List<string> modulesNumbers = _blService.GetModulesNamesByCategory(type);
            Manager.UpdateModuleList(modulesNumbers);
        }
        
        private void UpdateCustomerString()
        {
            string customerRecord = _blService.GetTotalCustomerRecord();
            _view.UpdateCustomerString(customerRecord);
        }

        #endregion


        internal void AddNewProduct(string nameProduct)
         {
             _blService.AddNewCategory(nameProduct);
         }

        public void UpdateModulesCount(CategoryType type)
        {
            var nameProduct = _blService.GetCategoryNameByType(type);
            var countModules = _blService.GetCountModules(type);
            _view.UpdateProductCount(countModules,nameProduct);
        }

 

        public void ShowModuleInformation(string moduleName, CategoryType type)
        {
            DataTable table = _blService.GetDetailDataForModule(moduleName, type);
            Manager.UpdateDetailDataDataGrid(table);
        }

   

        public void UpdateTotalModules(CategoryType type)
        {
            DataTable table = _blService.GetTotalModulesInfo(type);
            Manager.UpdateAllModuleInfo(table);
            
        }

        public void DeleteModule(string nameModule, CategoryType type)
        {
            if (_blService.GetCountModules(type) <= 0) return;

            _blService.DeleteModule(nameModule, type);
            UpdateModuleList(type);
            UpdateTotalModules(type);
            Manager.ClearModuleDetailsDgv();
        }

        public void AddSimilarModule(string similarName, CategoryType type)
        {
            _blService.AddSimilarModule(similarName, type);
             UpdateModuleList(type);
             UpdateTotalModules(type);
            
        }


        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, CategoryType type)
        {
            _blService.UpdateModuleInfo(moduleInfoTable, numberModule, type);
            UpdateTotalModules(type);
        }

        public bool IsModuleExist(string name, CategoryType getTypeCategory)
        {
            return _blService.IsModuleExist(name, getTypeCategory);
        }

        public List<Category> GetAllProducts()
        {
           return _blService.GetCurrentProject().Categories.GetAllCategories();
        }

        public Category GetCategoryByName(string productName)
        {
           return _blService.GetCurrentProject().Categories.GetCategory((CategoryType)Enum.Parse(typeof(CategoryType),productName));
        }

        public void CreateModuleReport(string moduleName, string fileName)
        {
            _blService.CreateModuleReport(moduleName, fileName);
        }

        public void CreateAllModulesReport(string fileName)
        {
            _blService.CreateAllModulesReport(fileName);
        }

        public DataTable GetAllDetailsGroupInfo(string tableName)
        {
            return _blService.GetAllDetailsGroupInfo(tableName);
        }

        public DataTable GetCountGroupInfo(string tableName)
        {
            return _blService.GetCountGroupInfo(tableName);
        }


    }
}
