using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Automation.Model;
using Automation.Properties;
using Automation.View.Helps;
using Automation.View.Model;
using Telerik.WinControls;

namespace Automation.View
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {


        public Presenter _presenter;
        public MainForm()
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Office2010Silver";
            InitCustomerTable();
        }

        private void about_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
        
        private void InitCustomerTable()
        {
            CustomerTable.InitCustomerTable(customerDGV);
            customerDGV.EditingControlShowing += customerDGV_EditingControlShowing;
        }

        public void UpdateThicknessColumn(string thicknessExt)
        {
            hideThicknessExt = thicknessExt;
            label2.Text = @"Подробная запись кромки: "+thicknessExt.Substring(0,30)+" ...";

        }

        private string hideThicknessExt;


        public void UpdateCustomerString(string customerRecord)
        {
            label3.Text = customerRecord;
        }

        private void openProjectMI_Click(object sender, EventArgs e)
        {
            string pathToFile = Dialogs.GetOpenProjectPath();
            if (pathToFile.Length == 0)
            {
                return;
            }
            _presenter.OpenProject(pathToFile);

        }

        private void newProjectMI_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            _presenter.NewProject();
            radMenuItem2.Visibility= ElementVisibility.Visible;
            
        }

        private void save_Click(object sender, EventArgs e)
        {
            string pathToFile = Dialogs.GetSaveProjectPath();
            if (pathToFile.Length == 0)
            {
                return;
            }
            _presenter.SaveProject(pathToFile);
            MessageBox.Show("Проект сохранён.");
        }
        
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void kitchenUpModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            ModulesTable.AddProductRowDgv(productsDgv, "Кухня верхние модули");
            _presenter.AddNewProduct("Кухня верхние модули");

        }

        private void kitchenDownModules_Click(object sender, EventArgs e)
        {
            panelCustomer.Height = 55;
            modulesPanel.Visible = true;
            ModulesTable.AddProductRowDgv(productsDgv, "Кухня нижние модули");
            _presenter.AddNewProduct("Кухня нижние модули");
        }

        private void turn_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> customerRecord = CustomerTable.GetData(customerDGV, hideThicknessExt);
            _presenter.SetCustomer(customerRecord);
            SetMoluleThickness();

        }

        private void SetMoluleThickness()
        {
            var thickness = customerDGV.Rows[1].Cells[2].Value;
            if (thickness!=null && thickness.ToString()!="опционально")
                ModuleThickness.SetAllSameValues(thickness.ToString());
            var plateThickness = customerDGV.Rows[0].Cells[2].Value;
            if (plateThickness != null)
                ModuleThickness.SetPlateThickness(plateThickness.ToString());
            var backPanelThickness = customerDGV.Rows[2].Cells[2].Value;
            if (backPanelThickness != null)
                ModuleThickness.SetBackPanelThickness(backPanelThickness.ToString());
        }

        private void customerDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (customerDGV.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            var extendOption= sendingCB.EditingControlFormattedValue.ToString();
            if (extendOption == "опционально")
            {
                ShowThicknessForm();
            }
        }

        private void ShowThicknessForm()
        {
            Form thicknessForm = Application.OpenForms["ThicknessMaterialEssential"];
            if (thicknessForm==null)
            {
                thicknessForm = new ThicknessMaterialEssential(this);
                thicknessForm.Show();
            }
            else
            {
                thicknessForm.Focus();
            }
        }

        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (e.RowIndex)
                {
                    case 0:
                        ShowCustomerHelpForm("ЛДСП ПОМОЩЬ", "Ldsp.png", "Ldsp_help.rtf");
                        break;
                    case 1:
                        ShowCustomerHelpForm("ДВП ПОМОЩЬ","Dvp.png", "Ldsp_help.rtf");
                        break;
                    case 2:
                        ShowCustomerHelpForm("КРОМКА ПОМОЩЬ", "Kromka.png", "Kromka_help.rtf");
                        break;
                    case 3:
                        ShowCustomerHelpForm("ФАСАД ПОМОЩЬ", "Fasad.png", "Fasad_help.rtf");
                        break;
                }
               
            }
        }
        
        private void ShowCustomerHelpForm(string title, string imageName, string textName)
        {
            Form customerHelpForm = Application.OpenForms["Helper"];
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

        private void productsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string productName = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                new ModuleManager(_presenter,productName).Show();
            }
        }

        public void UpdateProductCount(int count, string nameProduct)
        {
            for (int i = 0; i < productsDgv.RowCount; i++)
            {
                if (productsDgv.Rows[i].Cells[0].Value.ToString()==nameProduct)
                {
                    productsDgv.Rows[i].Cells[1].Value = count;
                }
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radMenuItem13_Click(object sender, EventArgs e)
        {
            new Results(_presenter).Show();
        }
    }
}
