using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Infrastructure.Utils;
using Automation.Model;
using Automation.Model.MainModels;
using Automation.Properties;
using Automation.View.Helps;
using Automation.View.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class MainForm : RadForm
    {
        public Presenter Presenter;

        private string _hideThicknessExt;

        public MainForm()
        {
            InitializeComponent();
            InitCustomerTable();
            ModuleThickness.GetModuleThickness();
        }

        private void InitCustomerTable()
        {
            CustomerTable.InitCustomerTable(customerDGV);
            customerDGV.EditingControlShowing += CustomerDGV_EditingControlShowing;
        }

        public void SetCustomerTable(List<CustomerInfoRecord> records)
        {

            customerDGV.Rows[0].Cells[0].Value = "ЛДСП";
            customerDGV.Rows[0].Cells[1].Value = records[0].Information;
            customerDGV.Rows[0].Cells[2].Value = records[0].ThicknessMaterial;
            customerDGV.Rows[1].Cells[0].Value = "Кромка для ЛДСП";
            customerDGV.Rows[1].Cells[1].Value = records[1].Information;
            customerDGV.Rows[1].Cells[2].Value = records[1].ThicknessMaterial;
            customerDGV.Rows[2].Cells[0].Value = "Задняя стенка";
            customerDGV.Rows[2].Cells[1].Value = records[2].Information;
            customerDGV.Rows[2].Cells[2].Value = records[2].ThicknessMaterial;
            customerDGV.Rows[3].Cells[0].Value = "Фасад";
            customerDGV.Rows[3].Cells[1].Value = records[3].Information;
            if (records[3].ThicknessMaterial != " ")
            {
                customerDGV.Rows[3].Cells[2].Value = records[3].ThicknessMaterial;
            }
            var customerRecord = CustomerTable.GetData(customerDGV, _hideThicknessExt);
            Presenter.SetCustomer(customerRecord);
            SetModuleThickness();
            customerDGV.Refresh();
        }

   
        public void UpdateThicknessColumn(string thicknessExt)
        {
            _hideThicknessExt = thicknessExt;
            label2.Text = @"Подробная запись кромки: " + thicknessExt.Substring(0, 30) + @" ...";
        }


        public void UpdateCustomerString(string customerRecord)
        {
            label3.Text = customerRecord;
        }

        public void SetCategoriesTable(CategoriesCollection categoriesCollection)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            var allCategories = categoriesCollection.GetAllCategories();
            foreach (var category in allCategories)
            {
                CategoriesUtilsTable.AddCategoryRow(categoriesDataGridView, CategoryTypeInfo.Name(category.Type), category.GetCountModules().ToString());
            }
            categoriesDataGridView.Refresh();
        }

        public void ShowLayout()
        {
            flowLayoutPanel1.Visible = true;
        }

        private void OpenProjectMI_Click(object sender, EventArgs e)
        {
            var pathToFile = Dialogs.GetOpenProjectPath();
            if (pathToFile.Length == 0) return;
            Presenter.OpenProject(pathToFile);
        }

        private void NewProjectMI_Click(object sender, EventArgs e)
        {
            ShowLayout();
            Presenter.NewProject();
            
            ShowServiceMenu();
        }

        public void ShowServiceMenu()
        {
            radMenuItem2.Visibility = ElementVisibility.Visible;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var pathToFile = Dialogs.GetSaveProjectPath();
            if (pathToFile.Length == 0) return;
            Presenter.SaveProject(pathToFile);
            MessageBox.Show(@"Проект сохранён.", @"Инфо ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KitchenUpModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            try
            {
                Presenter.AddNewProduct("Кухня верхние модули");
                CategoriesUtilsTable.AddProductRowDgv(categoriesDataGridView, "Кухня верхние модули");
                ((RadMenuItem) sender).Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Инфо ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KitchenDownModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            CategoriesUtilsTable.AddProductRowDgv(categoriesDataGridView, "Кухня нижние модули");
            Presenter.AddNewProduct("Кухня нижние модули");
        }

        private void Turn_Click(object sender, EventArgs e)
        {
            if (panelCustomer.Height == 263)
            {
                panelCustomer.Height = 55;


                turnBtn.Image = Resources.arrow_down_icon;
            }
            else
            {
                panelCustomer.Height = 263;
                turnBtn.Image = Resources.arrow_up_icon;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var customerRecord = CustomerTable.GetData(customerDGV, _hideThicknessExt);
            Presenter.SetCustomer(customerRecord);
            SetModuleThickness();
        }

        private void SetModuleThickness()
        {
            var thickness = customerDGV.Rows[1].Cells[2].Value;
            if (thickness != null && thickness.ToString() != "опционально")
                ModuleThickness.SetValueForKantsThickness(thickness.ToString());
            var plateThickness = customerDGV.Rows[0].Cells[2].Value;
            if (plateThickness != null)
                ModuleThickness.SetPlateThickness(plateThickness.ToString());
            var backPanelThickness = customerDGV.Rows[2].Cells[2].Value;
            if (backPanelThickness != null)
                ModuleThickness.SetBackPanelThickness(backPanelThickness.ToString());
        }

        private void CustomerDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (customerDGV.CurrentCell.ColumnIndex != 2 || !(e.Control is ComboBox)) return;
            var comboBox = (ComboBox) e.Control;
            comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            if (!(sender is DataGridViewComboBoxEditingControl sendingCb)) return;
            var extendOption = sendingCb.EditingControlFormattedValue.ToString();
            if (extendOption == "опционально") ShowThicknessForm();
        }

        private void ShowThicknessForm()
        {
            var thicknessForm = Application.OpenForms["ThicknessMaterialEssential"];
            if (thicknessForm == null)
            {
                thicknessForm = new ThicknessMaterialEssential(this);
                thicknessForm.Show();
            }
            else
            {
                thicknessForm.Focus();
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            switch (e.RowIndex)
            {
                case 0:
                    ShowCustomerHelpForm("ЛДСП ПОМОЩЬ", "Ldsp.png", "Ldsp_help.rtf");
                    break;
                case 1:
                    ShowCustomerHelpForm("ДВП ПОМОЩЬ", "Dvp.png", "Ldsp_help.rtf");
                    break;
                case 2:
                    ShowCustomerHelpForm("КРОМКА ПОМОЩЬ", "Kromka.png", "Kromka_help.rtf");
                    break;
                case 3:
                    ShowCustomerHelpForm("ФАСАД ПОМОЩЬ", "Fasad.png", "Fasad_help.rtf");
                    break;
            }
        }

        private void ShowCustomerHelpForm(string title, string imageName, string textName)
        {
            var customerHelpForm = Application.OpenForms["Helper"];
            if (customerHelpForm == null)
            {
                customerHelpForm = new Helper(title, imageName, textName);
                customerHelpForm.Show();
            }
            else
            {
                customerHelpForm.Focus();
            }
        }

        private void ProductsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var productName = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            new ModuleManager(Presenter, productName).Show();
        }

        public void UpdateProductCount(int count, string nameProduct)
        {
            for (var i = 0; i < categoriesDataGridView.RowCount; i++)
                if (categoriesDataGridView.Rows[i].Cells[0].Value.ToString() == nameProduct)
                    categoriesDataGridView.Rows[i].Cells[1].Value = count;
        }

        private void RadMenuItem13_Click(object sender, EventArgs e)
        {
            var allProducts = Presenter.GetAllProducts();
            if (allProducts.Count == 0 || allProducts.Any(x => x.GetCountModules() == 0) )
            {
                MessageBox.Show(@"Сначала добавьте категорию модулей", @"Инфо ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new Results(Presenter).Show();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            PanelResize();
        }

        private void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            PanelResize();
        }

        private void PanelResize()
        {
            panel1.Width = flowLayoutPanel1.Width - 10;
            panelCustomer.Width = panel1.Width;
            modulesPanel.Width = panel1.Width;
        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void radMenu1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem14_Click(object sender, EventArgs e)
        {
            var info = ModuleThickness.GetModuleThickness();
            MessageBox.Show(info);
        }
    }
}