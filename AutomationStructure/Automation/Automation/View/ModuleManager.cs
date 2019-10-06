using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Infrastructure.Utils;
using Automation.Model;
using Automation.View.ModuleViewGenerator;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleManager : RadForm
    {
        private readonly CategoryType _categoryType;

        private readonly string _productName;
        private DataTable _moduleInfoTable;

        public ModuleManager(Presenter presenter, string productName)
        {
            Presenter = presenter;
            Presenter.Manager = this;
            _productName = productName;
            _categoryType = CategoryTypeInfo.Category(productName);
            InitializeComponent();
            Text = "Настройка модулей \"" + productName + "\"";
            LoadModulesList();
            UpdateTotalModulesDatagrid();
            selectedModuleInformationDgv.EnableFastScrolling = true;
            allModulesInformationDgv.EnableFastScrolling = true;
            selectedModuleInformationDgv.MasterTemplate.BestFitColumns();
            // allModulesInformationDgv.MasterTemplate.BestFitColumns();


            //allModulesInformationDgv.VirtualMode = true;
            allModulesInformationDgv.EnableFiltering = false;
            allModulesInformationDgv.EnableGrouping = false;
        }


        public ModuleManager()
        {
            InitializeComponent();
        }

        //Presenter 
        public Presenter Presenter { get; set; }


        private void LoadModulesList()
        {
            Presenter.UpdateModuleList(_categoryType);
        }

        private void UpdateTotalModulesDatagrid()
        {
            Presenter.UpdateTotalModules(_categoryType);
        }


        private void Add_Click(object sender, EventArgs e)
        {
            var configuratorModule = new ModuleConfigurator(_categoryType);
            configuratorModule.OnApply += SetNewModuleInfo;
            configuratorModule.ShowDialog();
        }

        private void SetNewModuleInfo(object sender, ConfiguratorArgs e)
        {
            Presenter.Manager = this;

            if (Presenter.IsModuleExist(e.Number, _categoryType))
            {
                MessageBox.Show(@"Такой модуль уже существует. Измените Название модуля");
                return;
            }

            Presenter.AddNewModule(new NewModuleData
            {
                Name = e.Number,
                ModuleInfo = e.Info,
                Type = _categoryType
            });
        }

        private void AddSimilarBtn_Click(object sender, EventArgs e)
        {
            var similarModule = new SimilarModule();
            similarModule.OnApply += AddSimilarModule;
            similarModule.Show();
        }

        private void AddSimilarModule(object sender, SimilarEventArgs e)
        {
            if (!Presenter.IsModuleExist(e.SimilarName, _categoryType))
                Presenter.AddSimilarModule(e.SimilarName, _categoryType);
            else MessageBox.Show(@"Модуль с таким номером уже существует. Введите другой номер");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (modulesLbx.Items.Count != 0)
            {
                var moduleNameWithNumber = modulesLbx.SelectedItem.ToString();
                var moduleName = moduleNameWithNumber.Remove(0, moduleNameWithNumber.IndexOf(' ') + 1);
                Presenter.DeleteModule(moduleName, _categoryType);
            }
        }

        private void UpdateModuleInfoBtn(object sender, EventArgs e)
        {
            if (modulesLbx.SelectedItem == null)
            {
                MessageBox.Show("Не выбран модуль из списка");
                return;
            }

            var moduleNumber = modulesLbx.SelectedItem.ToString();
            try
            {
                Presenter.UpdateModuleInfo(_moduleInfoTable, moduleNumber, _categoryType);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }

            Presenter.ShowModuleInformation(moduleNumber, _categoryType);
            Presenter.UpdateTotalModules(_categoryType);
            selectedModuleInformationDgv.Columns["Название модуля"].ReadOnly = true;
            selectedModuleInformationDgv.Columns["№ схемы фасада"].ReadOnly = true;
        }

        private void ModulesLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesLbx.SelectedItem == null)
                return;
            if (modulesLbx.Items.Count != 0)
            {
                var moduleNumber = modulesLbx.SelectedItem.ToString();
                Presenter.ShowModuleInformation(moduleNumber, _categoryType);
                selectedModuleInformationDgv.Columns["Название модуля"].ReadOnly = true;
                selectedModuleInformationDgv.Columns["№ схемы фасада"].ReadOnly = true;
            }
        }


        public void UpdateModuleList(List<string> modulesNumbers)
        {
            modulesLbx.Items.Clear();
            for (var i = 0; i < modulesNumbers.Count; i++) modulesLbx.Items.Add(modulesNumbers[i]);
        }

        public void UpdateAllModuleInfo(DataTable modulesInfoTbl)
        {
            if (modulesInfoTbl != null && modulesInfoTbl.Rows.Count != 0)
            {
                var viewGenerator = GetViewGenerator();
                viewGenerator.SetupView(allModulesInformationDgv, modulesInfoTbl);
            }
            else
            {
                allModulesInformationDgv.DataSource = null;
                allModulesInformationDgv.Columns.Clear();
                allModulesInformationDgv.Refresh();
            }
        }


        public void UpdateDetailDataDataGrid(DataTable table)
        {
            if (table.Rows.Count != 0)
            {
                _moduleInfoTable = table;
                var viewGenerator = GetViewGenerator();
                viewGenerator.SetupView(selectedModuleInformationDgv, table);
            }
            else
            {
                selectedModuleInformationDgv.DataSource = null;
                selectedModuleInformationDgv.Refresh();
            }
        }

        private ViewGenerator GetViewGenerator()
        {
            switch (_categoryType)
            {
                case CategoryType.KitchenUp:
                    return new KitchenUpView();
                case CategoryType.KitchenDown:
                    return new KitchenDownView();
                default:
                    return new KitchenUpView();
            }
        }


        public void ClearModuleDetailsDgv()
        {
            selectedModuleInformationDgv.ViewDefinition = new TableViewDefinition();
            selectedModuleInformationDgv.DataSource = null;
            selectedModuleInformationDgv.Columns.Clear();
            selectedModuleInformationDgv.Refresh();
        }


    }
}