using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Automation.Model;
using Automation.View.Model;

namespace Automation.View
{
    public partial class ThicknessMaterialEssential : Telerik.WinControls.UI.RadForm
    {
        private MainForm _form;

        public ThicknessMaterialEssential(MainForm mf)
        {
            _form = mf;
            InitializeComponent();
            LoadComboboxData();
            LoadFirstTable();
            LoadSecondTable();
            LoadThirdTable();
        }

        private void LoadComboboxData()
        {
            comboBox1.DataSource = CustomerTable.KromkaThickness.Keys.Where(x => x != "опционально").ToList();
            comboBox1.SelectedIndex = -1;
        }

        private void LoadThirdTable()
        {
            dataGridView3.Rows.Add();
            dataGridView3.Rows[0].Cells[1].Value = "Периметр фасада";
            dataGridView3.Rows[0].Cells[0].Style.BackColor = Color.Red;
        }

        private void LoadSecondTable()
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();
            dataGridView2.Rows.Add();

            dataGridView2.Rows[0].Cells[1].Value = "Фронт";
            dataGridView2.Rows[0].Cells[0].Style.BackColor = Color.LightSkyBlue;
            dataGridView2.Rows[1].Cells[1].Value = "Бока Лево/право";
            dataGridView2.Rows[1].Cells[0].Style.BackColor = Color.Peru;
            dataGridView2.Rows[2].Cells[1].Value = "Задняя часть";
            dataGridView2.Rows[2].Cells[0].Style.BackColor = Color.AntiqueWhite;
        }

        private void LoadFirstTable()
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[1].Value = "Фронт";
            dataGridView1.Rows[0].Cells[0].Style.BackColor= Color.LightGray;
            dataGridView1.Rows[1].Cells[1].Value = "Верх";
            dataGridView1.Rows[1].Cells[0].Style.BackColor = Color.Red;
            dataGridView1.Rows[2].Cells[1].Value = "Низ";
            dataGridView1.Rows[2].Cells[0].Style.BackColor = Color.BlueViolet;
            dataGridView1.Rows[3].Cells[1].Value = "Бока лево/право";
            dataGridView1.Rows[3].Cells[0].Style.BackColor = Color.ForestGreen;
            dataGridView1.Rows[4].Cells[1].Value = "Задн.";
            dataGridView1.Rows[4].Cells[0].Style.BackColor = Color.AntiqueWhite;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string thicknessResult = GetResult();
            SetupModuleThickness();
            _form.UpdateThicknessColumn(thicknessResult);
            Close();
        }

        private void SetupModuleThickness()
        {
            ModuleThickness.FrontModule = ModuleThickness.InputFrontModuleConverter(dataGridView1.Rows[0].Cells[2].Value.ToString());
            ModuleThickness.UpModule = ModuleThickness.InputUpModuleConverter(dataGridView1.Rows[1].Cells[2].Value.ToString());
            ModuleThickness.DownModule = ModuleThickness.InputDownModuleConverter(dataGridView1.Rows[2].Cells[2].Value.ToString());
            ModuleThickness.SideModule = ModuleThickness.InputSideModuleConverter(dataGridView1.Rows[3].Cells[2].Value.ToString());
            ModuleThickness.BackModule = ModuleThickness.InputBackModuleConverter(dataGridView1.Rows[4].Cells[2].Value.ToString());

            ModuleThickness.FrontShelf = ModuleThickness.InputFrontShelfConverter(dataGridView2.Rows[0].Cells[2].Value.ToString());
            ModuleThickness.SideShelf = ModuleThickness.InputSideShelfConverter(dataGridView2.Rows[1].Cells[2].Value.ToString());
            ModuleThickness.BackShelf = ModuleThickness.InputBackShelfConverter(dataGridView2.Rows[2].Cells[2].Value.ToString());

            ModuleThickness.Facade = ModuleThickness.InputFacadeConverter(dataGridView3.Rows[0].Cells[2].Value.ToString());
        }

        private string GetResult()
        {
            string thickness = string.Empty;
            thickness += GetThicknessFromDgv(dataGridView1,"Модули");
            thickness += GetThicknessFromDgv(dataGridView2,"Полка");
            thickness += GetThicknessFromDgv(dataGridView3,"Фасад");
            return thickness;
        }


        private string GetThicknessFromDgv(DataGridView dg, string name)
        {
            string result = string.Empty;
            result += name+"\n";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                result += " Цвет: " + row.Cells[0].Value +",";
                result += " Часть модуля: " + row.Cells[1].Value + ",";
                result += " Толщина: " + row.Cells[2].Value + ",";
                result += "\n";
            }
            result += "\n";
            return result;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
