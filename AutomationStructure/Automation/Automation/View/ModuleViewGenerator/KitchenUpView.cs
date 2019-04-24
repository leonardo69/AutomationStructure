using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Automation.View.ModuleViewGenerator
{
    [Serializable]
    public class KitchenUpView: ViewGenerator
    {


        private GridViewComboBoxColumn GetBackPanelAssemblyColumns()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();

            column.Name = "Задняя стенка2";
            column.HeaderText = "Задняя стенка";
            column.FieldName = "Задняя стенка";
            column.DataSource = new List<string>
            {
                "нет",
                "на гвозди",
                "в паз",
                "в четверть",
                "ЛДСП внутрь",
                "что это?"
            };
            return column;
          
        }

        private GridViewComboBoxColumn GetModuleAssembly()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();
            column.Name = "Сборка модуля2";
            column.HeaderText = "Сборка модуля";
            column.FieldName = "Сборка модуля";
            column.DataSource = new List<string>
            {
                "конфирмат",
                "эксцентрик",
                "конфирмат + нагель",
                "эксцентрик + нагель",
                "нагель"
            };
            return column;
        }

        private GridViewComboBoxColumn GetFacadeMaterial()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();
            column.Name = "Материал фасада2";
            column.HeaderText = "Материал фасада";
            column.FieldName = "Материал фасада";
            column.DataSource = new List<string>
            {
                "нет",
                "ЛДСП вертик. фактура",
                "ЛДСП гориз. фактура",
                "на заказ глухой",
                "на заказ витрина",
                "на заказ особый"
            };
            return column;
        }

        private GridViewComboBoxColumn GetFacadeType()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn();
            column.Name = "Тип фасада2";
            column.HeaderText = "Тип фасада";
            column.FieldName = "Тип фасада";
            column.DataSource = new List<string>
            {
                "нет",
                "накладной",
                "вкладной ЛДСП",
                "вкладной 16 мм",
                "вкладной 18 мм",
                "вкладной 19 мм",
                "вкладной 20 мм",
                "вкладной 21 мм",
                "вкладной 22 мм",
                "что это?"
            };
            return column;
        }

        private GridViewComboBoxColumn GetShelfPO()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn
            {
                Name = "Крепление полки",
                HeaderText = "Крепление полки",
                FieldName = "Крепление полки",
                DataSource = new List<string>
                {
                    "полкодержатель",
                    "конфирмат",
                    "эксцентрик",
                    "конфирмат + нагель",
                    "эксцентрик + нагель",
                    "нагель"
                }
            };
            return column;
        }

        private GridViewComboBoxColumn GetCalculationType()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn
            {
                Name = "Режим расчёта2",
                HeaderText = @"Режим расчёта",
                FieldName = @"Режим расчёта",
                DataSource = new List<string>
                {
                    "авт. фас.",
                    "ручн.",
                    "авт. мод."
                }
            };
            return column;
        }

        private GridViewComboBoxColumn GetShelfMinus2MM()
        {
            GridViewComboBoxColumn column = new GridViewComboBoxColumn
            {
                Name = "Кол-во полок",
                HeaderText = "Кол-во полок",
                FieldName = "Кол-во полок",
                DataSource = new List<string>
                {
                    "нет",
                    "ЛДСП 1",
                    "ЛДСП 2",
                    "ЛДСП 3",
                    "ЛДСП 4",
                    "ЛДСП 5",
                    "ЛДСП 6",
                    "ЛДСП 7",
                    "ЛДСП 8",
                    "стекло 1",
                    "стекло 2",
                    "стекло 3",
                    "стекло 4",
                    "стекло 5",
                    "стекло 6",
                    "стекло 7",
                    "стекло 8"
                }
            };
            return column;
        }

        private GridViewImageColumn GetIcon()
        {
            GridViewImageColumn column = new GridViewImageColumn
            {
                Name ="Icon",
                HeaderText = "Изображение"
        };

            return column;

        }

        private  DataTable resultTable;

        public override void SetupView(RadGridView dgv, DataTable table)
        {
            dgv.Columns.Clear();
            dgv.DataSource = null;
            resultTable = table;
            dgv.DataSource = table;
            dgv.MasterTemplate.AllowAddNewRow = false;

            foreach (var row in dgv.Rows)
            {
                row.Height = 50;
            }

            dgv.Columns["Изображение"].IsVisible = false;
            dgv.Columns["Задняя стенка"].IsVisible = false;
            dgv.Columns.Remove("Крепление полки");
            dgv.Columns.Remove("Кол-во полок");
            dgv.Columns["Тип фасада"].IsVisible = false;
            dgv.Columns["Материал фасада"].IsVisible = false;
            dgv.Columns["Режим расчёта"].IsVisible = false;
            dgv.Columns["Сборка модуля"].IsVisible = false;

            dgv.Columns.Insert(10, GetModuleAssembly());
            dgv.Columns.Insert(10, GetBackPanelAssemblyColumns());
            dgv.Columns.Insert(20, GetFacadeMaterial());
            dgv.Columns.Insert(16, GetFacadeType());
            dgv.Columns.Insert(17,GetCalculationType());
            dgv.Columns.Insert(11, GetShelfPO());
            dgv.Columns.Insert(12, GetShelfMinus2MM());
            dgv.Columns.Insert(3, GetIcon());


            foreach (var column in dgv.Columns )
            {
                column.WrapText = true;
                column.Width = 150;
            }

            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;
       
            var view = SetColumnGroupsView(dgv);
            dgv.ViewDefinition = view;

            dgv.CellFormatting += Dgv_CellFormatting;
            dgv.CellClick += Dgv_CellClick;
            dgv.CellBeginEdit += Dgv_CellBeginEdit;


            dgv.Refresh();

        }

        private void Dgv_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var path = resultTable.Rows[e.RowIndex][2].ToString();
                var parts = path.Split('_');
                var bigImagePath = parts[0] + "_" + parts[1] + "_big.png";

                Form customerHelpForm = Application.OpenForms["BigModuleImageInfo"];
                if (customerHelpForm == null)
                {
                    customerHelpForm = new BigModuleImageInfo(bigImagePath);
                    customerHelpForm.Show();
                }
                else
                {
                    customerHelpForm.Focus();
                }
               
            }
        }

        private ColumnGroupsViewDefinition SetColumnGroupsView(RadGridView dgv)
        {
            ColumnGroupsViewDefinition view = new ColumnGroupsViewDefinition();

            view.ColumnGroups.Add(new GridViewColumnGroup("Num"));
            view.ColumnGroups[0].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[0].Rows[0].ColumnNames.Add("Номер модуля");
            view.ColumnGroups[0].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("F"));
            view.ColumnGroups[1].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[1].Rows[0].ColumnNames.Add("Форма модуля");
            view.ColumnGroups[1].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("I"));
            view.ColumnGroups[2].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[2].Rows[0].ColumnNames.Add("Icon");
            view.ColumnGroups[2].ShowHeader = false;


           

            view.ColumnGroups.Add(new GridViewColumnGroup("Размеры"));
            view.ColumnGroups[3].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("Высота модуля (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("Ширина модуля (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("Глубина модуля (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("A размер (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("B размер (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("C размер (мм)");
            view.ColumnGroups[3].Rows[0].ColumnNames.Add("D размер (мм)");

         
            view.ColumnGroups.Add(new GridViewColumnGroup("zertg"));
            view.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[4].Rows[0].ColumnNames.Add("Сборка модуля2");
            view.ColumnGroups[4].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("z"));
            view.ColumnGroups[4].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[4].Rows[0].ColumnNames.Add("Задняя стенка2");
            view.ColumnGroups[4].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("ppse"));
            view.ColumnGroups[5].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[5].Rows[0].ColumnNames.Add("Крепление полки");
            view.ColumnGroups[5].ShowHeader = false;

            view.ColumnGroups[6].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[6].Rows[0].ColumnNames.Add("Кол-во полок");
            view.ColumnGroups[6].ShowHeader = false;

            view.ColumnGroups.Add(new GridViewColumnGroup("Фасад"));
            view.ColumnGroups[7].Rows.Add(new GridViewColumnGroupRow());
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("№ схемы фасада");
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("Высота");
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("Ширина");
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("Тип фасада2");
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("Режим расчёта2");
            view.ColumnGroups[7].Rows[0].ColumnNames.Add("Материал фасада2");
    


            return view;
        }

        private string _columnName=string.Empty;

        private void Dgv_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

            if (e.Column.Name == "Задняя стенка2" ||
                e.Column.Name == "Тип фасада2")
            {
                _columnName = e.Column.Name;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement).SelectedIndexChanged-=  Form1_SelectedIndexChanged;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement).SelectedIndexChanged += Form1_SelectedIndexChanged;
            }
        }

        private void Form1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadDropDownListEditorElement editor = sender as RadDropDownListEditorElement;
          
            if (editor?.SelectedItem != null && editor.SelectedItem.Text == "что это?")
            {
                ShowHelpForm(_columnName);
                
            }
        }

        private void ShowHelpForm(string columnName)
        {
            var path = resultTable.Rows[0][2].ToString();
            var parts = path.Split('_');
            string bigImagePath = string.Empty;

            switch (columnName)
            {
                case "Задняя стенка2":
                    bigImagePath = parts[0] + "_" + parts[1] + "_stenka-help.png";
                    new BigModuleImageInfo(bigImagePath).Show();
                    break;
                case "Тип фасада2":
                    bigImagePath = parts[0] + "_" + parts[1] + "_fasad-help.png";
                    new BigModuleImageInfo(bigImagePath).Show();
                    break;
                    
            }
        }
        
        private void Dgv_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (e.CellElement.ColumnIndex == 3 )
                {
                    if (resultTable.Rows[e.RowIndex]["Изображение"].ToString().Length != 0)
                    {
                        var pathToImage = Environment.CurrentDirectory + "\\" + resultTable.Rows[e.RowIndex]["Изображение"];
                        e.CellElement.Image = Image.FromFile(pathToImage);
                    }
                   
                }

            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
