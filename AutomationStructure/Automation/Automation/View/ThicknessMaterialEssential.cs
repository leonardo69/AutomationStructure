using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Model;
using Automation.View.Model;

namespace Automation.View
{
    public partial class ThicknessMaterialEssential : Telerik.WinControls.UI.RadForm
    {
        private MainForm _form;
        private int gridColumnIndex = 2;
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
            comboBoxPatternValue.DataSource = CustomerTable.KromkaThickness.Keys.Where(x => x != "опционально").ToList();
            comboBoxPatternValue.SelectedIndex = -1;
        }

        private void SetCell(IList<string> titles, DataGridViewComboBoxCell comboboxCell)
        {
            foreach (var title in titles)
            {
                comboboxCell.Items.Add(title);
            }
        }

        private void LoadThirdTable()
        {
            fasadeThicknessDgv.Rows.Add();
            //
            SetCellItems(fasadeThicknessDgv, 2);

            fasadeThicknessDgv.Rows[0].Cells[1].Value = "Периметр фасада";
            fasadeThicknessDgv.Rows[0].Cells[0].Style.BackColor = Color.Red;

            //
            ThicknessMapping.GridLoad(fasadeThicknessDgv, gridColumnIndex);
        }

        private void LoadSecondTable()
        {
            shelfThicknessDgv.Rows.Add();
            shelfThicknessDgv.Rows.Add();
            shelfThicknessDgv.Rows.Add();
            //
            SetCellItems(shelfThicknessDgv, 2);

            shelfThicknessDgv.Rows[0].Cells[1].Value = "Фронт";
            shelfThicknessDgv.Rows[0].Cells[0].Style.BackColor = Color.LightSkyBlue;
            shelfThicknessDgv.Rows[1].Cells[1].Value = "Бока Лево/право";
            shelfThicknessDgv.Rows[1].Cells[0].Style.BackColor = Color.Peru;
            shelfThicknessDgv.Rows[2].Cells[1].Value = "Задняя часть";
            shelfThicknessDgv.Rows[2].Cells[0].Style.BackColor = Color.AntiqueWhite;
            //
            ThicknessMapping.GridLoad(shelfThicknessDgv, gridColumnIndex);
        }

        private void LoadFirstTable()
        {
            kromkaThicknessDgv.Rows.Add();
            kromkaThicknessDgv.Rows.Add();
            kromkaThicknessDgv.Rows.Add();
            kromkaThicknessDgv.Rows.Add();
            kromkaThicknessDgv.Rows.Add();
            //
            SetCellItems(kromkaThicknessDgv, 2);

            kromkaThicknessDgv.Rows[0].Cells[1].Value = "Фронт";
            kromkaThicknessDgv.Rows[0].Cells[0].Style.BackColor= Color.LightGray;
            
            kromkaThicknessDgv.Rows[1].Cells[1].Value = "Верх";
            kromkaThicknessDgv.Rows[1].Cells[0].Style.BackColor = Color.Red;
            kromkaThicknessDgv.Rows[2].Cells[1].Value = "Низ";
            kromkaThicknessDgv.Rows[2].Cells[0].Style.BackColor = Color.BlueViolet;
            kromkaThicknessDgv.Rows[3].Cells[1].Value = "Бока лево/право";
            kromkaThicknessDgv.Rows[3].Cells[0].Style.BackColor = Color.ForestGreen;
            kromkaThicknessDgv.Rows[4].Cells[1].Value = "Задн.";
            kromkaThicknessDgv.Rows[4].Cells[0].Style.BackColor = Color.AntiqueWhite;
           
            ThicknessMapping.GridLoad(kromkaThicknessDgv, gridColumnIndex);
        }

        private void SetCellItems(DataGridView dataGridView, int intColumnIndex)
        {
            var KromkaThicknessList = CustomerTable.KromkaThickness.Keys.Where(x => x != "опционально").ToList();
            DataGridViewComboBoxCell comboboxCell;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                comboboxCell = (DataGridViewComboBoxCell)row.Cells[intColumnIndex];
                comboboxCell.Items.Clear();
                comboboxCell.Value = null;
                SetCell(KromkaThicknessList, comboboxCell);
            }
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
            ModuleThickness.FrontModule = ModuleThickness.InputFrontModuleConverter(kromkaThicknessDgv.Rows[0].Cells[2].Value.ToString());
            ModuleThickness.UpModule = ModuleThickness.InputUpModuleConverter(kromkaThicknessDgv.Rows[1].Cells[2].Value.ToString());
            ModuleThickness.DownModule = ModuleThickness.InputDownModuleConverter(kromkaThicknessDgv.Rows[2].Cells[2].Value.ToString());
            ModuleThickness.SideModule = ModuleThickness.InputSideModuleConverter(kromkaThicknessDgv.Rows[3].Cells[2].Value.ToString());
            ModuleThickness.BackModule = ModuleThickness.InputBackModuleConverter(kromkaThicknessDgv.Rows[4].Cells[2].Value.ToString());

            ModuleThickness.FrontShelf = ModuleThickness.InputFrontShelfConverter(shelfThicknessDgv.Rows[0].Cells[2].Value.ToString());
            ModuleThickness.SideShelf = ModuleThickness.InputSideShelfConverter(shelfThicknessDgv.Rows[1].Cells[2].Value.ToString());
            ModuleThickness.BackShelf = ModuleThickness.InputBackShelfConverter(shelfThicknessDgv.Rows[2].Cells[2].Value.ToString());

            ModuleThickness.Facade = ModuleThickness.InputFacadeConverter(fasadeThicknessDgv.Rows[0].Cells[2].Value.ToString());

            ThicknessMapping.GridSave(kromkaThicknessDgv, 2);
            ThicknessMapping.GridSave(shelfThicknessDgv, 2);
            ThicknessMapping.GridSave(fasadeThicknessDgv, 2);
        }

        private string GetResult()
        {
            string thickness = string.Empty;
            thickness += GetThicknessFromDgv(kromkaThicknessDgv,"Модули");
            thickness += GetThicknessFromDgv(shelfThicknessDgv,"Полка");
            thickness += GetThicknessFromDgv(fasadeThicknessDgv,"Фасад");
            return thickness;
        }


        private string GetThicknessFromDgv(DataGridView dg, string name)
        {
            string result = string.Empty;
            result += name+"\n";

            foreach (DataGridViewRow row in kromkaThicknessDgv.Rows)
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
            int index = comboBoxPatternValue.SelectedIndex;

            foreach (DataGridViewRow row in kromkaThicknessDgv.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }

            foreach (DataGridViewRow row in shelfThicknessDgv.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }

            foreach (DataGridViewRow row in fasadeThicknessDgv.Rows)
            {
                var columnCell = (DataGridViewComboBoxCell)row.Cells[2];
                columnCell.Value = columnCell.Items[index];
            }
        }
    }
}
