using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public void AddFacade(string numberModule, CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            product.AddFacade(numberModule);
        }

        public void DeleteFacade(string numberModule, CategoryType type)
        {
            var product = _project.Categories.GetCategory(type);
            product.DeleteFacade(numberModule);
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



        public DataTable GetLdspAllDetailsGroupInfo()
        {
            var modules = _project.Categories.GetAllModules();
            
            var ldspInfo = new DataTable();
            AddDetailsColumns(ldspInfo);

            foreach (var module in modules)
            {
                var detailsInfo = module.CalculationResult.DetailsInfo;

                foreach (DataRow row in detailsInfo.Rows)
                {
                    if(IsEmptyRow(row)) continue;

                    var resultRow = ldspInfo.NewRow();
                    // add check if empty
                    resultRow["№ модуля"] = module.Number;
                    resultRow["№ детали"] = row["№"];
                    resultRow["Наименование"] = row["Наименование"];
                    resultRow["firstMM"] = row["firstMM"];
                    resultRow["firstEdge"] = row["firstEdge"];
                    resultRow["secondMM"] = row["secondMM"];
                    resultRow["secondEdge"] = row["secondEdge"];
                    resultRow["Количество"] = row["Количество"];
                    ldspInfo.Rows.Add(resultRow);
                }
            }

            return ldspInfo;

        }

        private bool IsEmptyRow(DataRow row)
        {
            return string.IsNullOrEmpty(row["№"].ToString()) &&
                   string.IsNullOrEmpty(row["Наименование"].ToString()) &&
                   string.IsNullOrEmpty(row["firstMM"].ToString()) &&
                   string.IsNullOrEmpty(row["firstEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["secondMM"].ToString()) &&
                   string.IsNullOrEmpty(row["secondEdge"].ToString()) &&
                   string.IsNullOrEmpty(row["Количество"].ToString());
        }

        private static void AddDetailsColumns(DataTable ldspInfo)
        {
            ldspInfo.Columns.Add("№ модуля");
            ldspInfo.Columns.Add("№ детали");

            ldspInfo.Columns.Add("Наименование");

            var firstColumn = new DataColumn
            {
                ColumnName = "firstMM",
                Caption = "ММ"
            };
            ldspInfo.Columns.Add(firstColumn);

            var secondColumn = new DataColumn
            {
                ColumnName = "firstEdge",
                Caption = "Кромка"
            };
            ldspInfo.Columns.Add(secondColumn);

            var thirdColumn = new DataColumn
            {
                ColumnName = "secondMM",
                Caption = "ММ"
            };
            ldspInfo.Columns.Add(thirdColumn);

            var fourthColumn = new DataColumn
            {
                ColumnName = "secondEdge",
                Caption = "Кромка"
            };
            ldspInfo.Columns.Add(fourthColumn);

            ldspInfo.Columns.Add("Количество");
        }

        public DataTable GetBackWallAllDetailsGroupInfo()
        {
            return null;
        }

        public DataTable GetFurnitureAllDetailsGroupInfo()
        {
            throw new NotImplementedException();
        }

        public DataTable GetFacadeAllDetailsGroupInfo()
        {
            throw new NotImplementedException();
        }
    }
}