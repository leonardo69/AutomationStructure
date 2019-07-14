using System;
using System.Linq;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Properties;
using Automation.View.Helps;
using Automation.View.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class MainForm : RadForm
    {
        public Presenter _presenter;

        private string _hideThicknessExt;

        public MainForm()
        {
            InitializeComponent();
            InitCustomerTable();
        }

        private void About_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void InitCustomerTable()
        {
            CustomerTable.InitCustomerTable(customerDGV);
            customerDGV.EditingControlShowing += CustomerDGV_EditingControlShowing;
        }

        public void UpdateThicknessColumn(string thicknessExt)
        {
            _hideThicknessExt = thicknessExt;
            label2.Text = @"Подробная запись кромки: " + thicknessExt.Substring(0, 30) + " ...";
        }


        public void UpdateCustomerString(string customerRecord)
        {
            label3.Text = customerRecord;
        }

        private void OpenProjectMI_Click(object sender, EventArgs e)
        {
            var pathToFile = Dialogs.GetOpenProjectPath();
            if (pathToFile.Length == 0) return;
            _presenter.OpenProject(pathToFile);
        }

        private void NewProjectMI_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            _presenter.NewProject();
            radMenuItem2.Visibility = ElementVisibility.Visible;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var pathToFile = Dialogs.GetSaveProjectPath();
            if (pathToFile.Length == 0) return;
            _presenter.SaveProject(pathToFile);
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
                _presenter.AddNewProduct("Кухня верхние модули");
                ModulesTable.AddProductRowDgv(productsDgv, "Кухня верхние модули");
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
            ModulesTable.AddProductRowDgv(productsDgv, "Кухня нижние модули");
            _presenter.AddNewProduct("Кухня нижние модули");
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
            _presenter.SetCustomer(customerRecord);
            SetMoluleThickness();
        }

        private void SetMoluleThickness()
        {
            var thickness = customerDGV.Rows[1].Cells[2].Value;
            if (thickness != null && thickness.ToString() != "опционально")
                ModuleThickness.SetAllSameValues(thickness.ToString());
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
            new ModuleManager(_presenter, productName).Show();
        }

        public void UpdateProductCount(int count, string nameProduct)
        {
            for (var i = 0; i < productsDgv.RowCount; i++)
                if (productsDgv.Rows[i].Cells[0].Value.ToString() == nameProduct)
                    productsDgv.Rows[i].Cells[1].Value = count;
        }

        private void RadMenuItem13_Click(object sender, EventArgs e)
        {
            var allProducts = _presenter.GetAllProducts();
            if (allProducts.Count == 0 || allProducts.Any(x => x.GetCountModules() == 0) )
            {
                MessageBox.Show(@"Сначала добавьте категорию модулей", @"Инфо ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new Results(_presenter).Show();
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

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}