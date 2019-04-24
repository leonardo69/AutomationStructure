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
        private BLService _blService;
        private MainForm _view;
        public ModuleManager Manager { get; set; }

       

        public Presenter(BLService model, MainForm view)
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
            Order order = null;


            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(pathToFile,FileMode.OpenOrCreate))
            {
                order = (Order)formatter.Deserialize(fs);
            }

            _blService.SetCurrentOrder(order);

        }

        internal void SaveProject(string pathToFile)
        {
            var order = _blService.GetCurrentOrder();
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
       }

       

        #region For Update View

        
        public void UpdateModuleList(ProductType type)
        {
            List<string> modulesNumbers = _blService.GetModulesNumbersByType(type);
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
             _blService.AddNewProduct( nameProduct);
         }

        public void UpdateModulesCount(ProductType type)
        {
            var nameProduct = _blService.GetProductNameByType(type);
            var countModules = _blService.GetCountModules(type);
            _view.UpdateProductCount(countModules,nameProduct);
        }

 

        public void ShowModuleInformation(string moduleName, ProductType type)
        {
            DataTable table = _blService.GetDetailDataForModule(moduleName, type);
            Manager.UpdateDetailDataDataGrid(table);
        }

        public void UpdateTotalModules(ProductType type)
        {
            DataTable table = _blService.GetTotalModulesInfo(type);
            
            Manager.UpdateAllModuleInfo(table);
            
        }

        public void DeleteModule(string nameModule, ProductType type)
        {
            if (_blService.GetCountModules(type)>0)
            {
                 _blService.DeleteModule(nameModule, type);
                 UpdateModuleList(type);
                 UpdateTotalModules(type);
                 Manager.ClearModuleDetailsDgv();
             }
            
            
            
            
        }

        public void AddSimilarModule(string similarName, ProductType type)
        {
            _blService.AddSimilarModule(similarName, type);
             UpdateModuleList(type);
             UpdateTotalModules(type);
            
        }

        public void AddFacade(string numberModule, ProductType type)
        {
            try
            {
                _blService.AddFacade(numberModule, type);
            }
            catch (ArgumentException exp)
            {
                throw exp;
            }
            UpdateTotalModules(type);
        }

        public void DeleteFacade(string numberModule, ProductType type)
        {
            try
            {
                _blService.DeleteFacade(numberModule, type);
            }
            catch (ArgumentException exp)
            {
                throw exp;
            }
            UpdateTotalModules(type);
        }

        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, ProductType type)
        {
            _blService.UpdateModuleInfo(moduleInfoTable, numberModule, type);
            UpdateTotalModules(type);
        }

        public bool IsModuleExist(string number, ProductType getTypeProduct)
        {
            return _blService.IsModuleExist(number, getTypeProduct);
        }

        public List<Product> GetAllProducts()
        {
           return _blService.GetCurrentOrder().Products.GetAllProducts();
        }

        public Product GetProductByName(string productName)
        {
           return _blService.GetCurrentOrder().Products.GetProduct((ProductType)Enum.Parse(typeof(ProductType),productName));
        }
    }
}
