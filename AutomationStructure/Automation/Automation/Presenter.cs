﻿using System;
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
             _blService.AddNewProduct(nameProduct);
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

        public void AddFacade(string numberModule, CategoryType type)
        {
            _blService.AddFacade(numberModule, type);
            UpdateTotalModules(type);
        }

        public void DeleteFacade(string numberModule, CategoryType type)
        {
            _blService.DeleteFacade(numberModule, type);
            UpdateTotalModules(type);
        }

        public void UpdateModuleInfo(DataTable moduleInfoTable, string numberModule, CategoryType type)
        {
            _blService.UpdateModuleInfo(moduleInfoTable, numberModule, type);
            UpdateTotalModules(type);
        }

        public bool IsModuleExist(string number, CategoryType getTypeCategory)
        {
            return _blService.IsModuleExist(number, getTypeCategory);
        }

        public List<Category> GetAllProducts()
        {
           return _blService.GetCurrentProject().Categories.GetAllCategories();
        }

        public Category GetProductByName(string productName)
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

        public DataTable GetLdspAllDetailsGroupInfo()
        {
            return _blService.GetLdspAllDetailsGroupInfo();
        }

        public DataTable GetBackWallAllDetailsGroupInfo()
        {
            return _blService.GetBackWallAllDetailsGroupInfo();
        }

        public DataTable GetFurnitureAllDetailsGroupInfo()
        {
            return _blService.GetFurnitureAllDetailsGroupInfo();
        }

        public DataTable GetFacadeAllDetailsGroupInfo()
        {
            return _blService.GetFacadeAllDetailsGroupInfo();
        }


        public void AddTestModules()
        {
            const CategoryType categoryType = CategoryType.KitchenUp;

            var testModule1 = new NewModuleData
            {
                Number = "1",
                Name = "1",
                Scheme = "Тип фасада 1",
                SubScheme = "Подтип 1",
                SubSchemeIconPath = "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_icon.png",
                Type = categoryType
            };
            _blService.AddNewModule(testModule1);

            var inputFirst = new DataTable();
            AddColumns(inputFirst);
            AddRow(inputFirst,"1", 100, 150, 200);

            _blService.UpdateModuleInfo(inputFirst, "1", CategoryType.KitchenUp);


            var testModule2 = new NewModuleData
            {
                Number = "2",
                Name = "2",
                Scheme = "Тип фасада 1",
                SubScheme = "Подтип 1",
                SubSchemeIconPath = "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_icon.png",
                Type = categoryType
            };
            _blService.AddNewModule(testModule2);

            var input = new DataTable();
            AddColumns(input);
            AddRow(input, "2", 100, 200, 300);

            _blService.UpdateModuleInfo(input,"2", CategoryType.KitchenUp);

            var moduleList = _blService.GetModulesNumbersByType(categoryType);

            Manager.ClearModuleDetailsDgv();
            Manager.UpdateAllModuleInfo(_blService.GetTotalModulesInfo(categoryType));
            Manager.UpdateModuleList(moduleList);
            UpdateModulesCount(CategoryType.KitchenUp);
        }

        private void AddColumns(DataTable input)
        {
            input.Columns.Add("Номер модуля");
            input.Columns.Add("Форма модуля");
            input.Columns.Add("Изображение");
            input.Columns.Add("Высота модуля (мм)");
            input.Columns.Add("Ширина модуля (мм)");
            input.Columns.Add("Глубина модуля (мм)");
            input.Columns.Add("A размер (мм)");
            input.Columns.Add("B размер (мм)");
            input.Columns.Add("C размер (мм)");
            input.Columns.Add("D размер (мм)");
            input.Columns.Add("Сборка модуля");
            input.Columns.Add("Задняя стенка");
            input.Columns.Add("Крепление полки");
            input.Columns.Add("Кол-во полок");
            input.Columns.Add("№ схемы фасада");
            input.Columns.Add("Тип фасада");
            input.Columns.Add("Режим расчёта");
            input.Columns.Add("Высота");
            input.Columns.Add("Ширина");
            input.Columns.Add("Материал фасада");
            input.Columns.Add("ПОСУДОСУШИЛКА");
            input.Columns.Add("Навесы на стену");
        }

        private void AddRow(DataTable input, string moduleNumber, int width, int length, int depth)
        {
            var row = input.NewRow();
            row["Номер модуля"] = moduleNumber;
            row["Форма модуля"] = "Тип фасада 1";
            row["Изображение"] = "Кухня верхние модули\\scheme 1\\kitchen-upper-module-table-type1-subtype1_F1-01-0001_icon.png";
            row["Высота модуля (мм)"] = width;
            row["Ширина модуля (мм)"] = length;
            row["Глубина модуля (мм)"] = depth;
            row["A размер (мм)"] = 4;
            row["B размер (мм)"] = 5;
            row["C размер (мм)"] = 6;
            row["D размер (мм)"] = 7;
            row["Сборка модуля"] = "не разъёмная(конф.)";
            row["Задняя стенка"] = "нет";
            row["Крепление полки"] = "полкодержатель";
            row["Кол-во полок"] = "нет";
            row["№ схемы фасада"] = 1;
            row["Высота"] = 8;
            row["Ширина"] = 9;
            row["Тип фасада"] = "нет";
            row["Режим расчёта"] = "авт. фас.";
            row["Материал фасада"] = "нет";
            row["ПОСУДОСУШИЛКА"] = "";
            row["Навесы на стену"] = "";
            input.Rows.Add(row);
        }


    }
}
