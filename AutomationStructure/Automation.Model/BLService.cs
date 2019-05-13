using System;
using System.Collections.Generic;
using System.Data;
using Automation.Infrastructure;
using Automation.Model.MainModels;


namespace Automation.Model
{
    public  class BLService
    {

        private Order _order;

        #region Project Methods


        public void MakeNewProject()
        {
            _order = new Order();
        }


        #endregion

        #region Customer Methods

        public string GetTotalCustomerRecord()
        {
            return _order.Customer.GetTotalCustomerRecord();
        }


        public void SetCustomer(List<string[]> customerRecord)
        {

            _order.Customer.SetInputData(customerRecord);
        }


        #endregion
        
        #region Product Methods

        public void AddNewProduct(string nameProduct)
        {
            _order.Products.AddProduct(nameProduct);
        }

        #endregion
        
        #region Modules Methods


        public void AddNewModule(NewModuleData data)
        {
            var product = _order.Products.GetProduct(data);
            product.AddNewModule(data);
        }


        public List<string> GetModulesNamesByType(ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            return product.GetNamesModules();
        }

        public List<string> GetModulesNumbersByType(ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            return product.GetNumbersModules();
        } 


        public string GetProductNameByType(ProductType type)
        {
            string result = string.Empty;
            switch (type)
            {
                case ProductType.KitchenUp:
                    result = "Кухня верхние модули";
                    break;
                case ProductType.KitchenDown:
                    result = "Кухня нижние модули";
                    break;
            }
            return result;
        }



        public int GetCountModules(ProductType type)
        {
            var count = _order.Products.GetCountModules(GetProductNameByType(type));
            return count;
        }

        public DataTable GetDetailDataForModule(string moduleName, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            DataTable moduleInfo = product.GetModuleDetailInfoByNumber(moduleName);
            return moduleInfo;
        }

        public DataTable GetTotalModulesInfo(ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            DataTable table = product.GetTotalDetailInfo();
            return table;
        }

        public void DeleteModule(string nameModule, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            product.DeleteModule(nameModule);

        }

        public void AddSimilarModule(string similarName, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            var module = product.GetCloneLastModule();
            module.Number = similarName;
            product.AddSimilarModule(module);

        }

        public void AddFacade(string numberModule, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            try
            {
                product.AddFacade(numberModule);
            }
            catch (ArgumentException exp)
            {
                throw exp;
            }
        }

        public void DeleteFacade(string numberModule, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            try
            {
                product.DeleteFacade(numberModule);
            }
            catch (ArgumentException exp)
            {
                throw exp;
            }
        }

        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            product.UpdateModule(moduleInfoTable, numberModule);
        }

        #endregion

        public Order GetCurrentOrder()
        {
            return _order;
        }

        public void SetCurrentOrder(Order order)
        {
            _order = order;
        }

        public bool IsModuleExist(string number, ProductType type)
        {
            var product = _order.Products.GetProduct(type);
            return product.IsModuleExist(number);

        }
    }
}
