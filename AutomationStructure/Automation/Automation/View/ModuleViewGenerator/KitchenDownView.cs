using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace Automation.View.ModuleViewGenerator
{
    [Serializable]
    public class KitchenDownView : ViewGenerator
    {
        private string _columnName = string.Empty;

        private DataTable _resultTable;


        private GridViewComboBoxColumn GetBackPanelAssemblyColumns()
        {
            var column = new GridViewComboBoxColumn();

            column.Name = @"Задняя стенка2";
            column.HeaderText = @"Задняя стенка";
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
            var column = new GridViewComboBoxColumn();
            column.Name = "Сборка модуля2";
            column.HeaderText = @"Сборка модуля";
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
            return new GridViewComboBoxColumn
            {
                Name = "Материал фасада2",
                HeaderText = @"Материал фасада",
                FieldName = "Материал фасада",
                DataSource = new List<string>
                {
                    "нет",
                    "ЛДСП вертик. фактура",
                    "ЛДСП гориз. фактура",
                    "на заказ глухой",
                    "на заказ витрина",
                    "на заказ особый",
                    "на заказ РЕШЁТКА"
                }
            };
        }

        private GridViewComboBoxColumn GetFacadeType()
        {
            var column = new GridViewComboBoxColumn();
            column.Name = "Тип фасада2";
            column.HeaderText = @"Тип фасада";
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
            var column = new GridViewComboBoxColumn
            {
                Name = "Крепление полки",
                HeaderText = @"Крепление полки",
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
            var column = new GridViewComboBoxColumn
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
            var column = new GridViewComboBoxColumn
            {
                Name = "Кол-во полок",
                HeaderText = @"Кол-во полок",
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
            var column = new GridViewImageColumn
            {
                Name = "Icon",
                HeaderText = @"Изображение"
            };

            return column;
        }

        private GridViewComboBoxColumn GetDishDrayer()
        {
            return new GridViewComboBoxColumn
            {
                Name = "ПОСУДОСУШИЛКА2",
                HeaderText = "ПОСУДОСУШИЛКА",
                FieldName = "ПОСУДОСУШИЛКА",
                DataSource = new List<string>
                {
                    "-",
                    "вместо полки",
                    "на полку",
                    "помощь"
                }
            };
        }

        private GridViewComboBoxColumn GetCanopies()
        {
            return new GridViewComboBoxColumn
            {
                Name = "Навесы на стену2",
                HeaderText = "Навесы на стену",
                FieldName = "Навесы на стену",
                DataSource = new List<string>
                {
                    "-",
                    "универс. (УХО)",
                    "L-образный (ИКЕА)",
                    "регулируемый",
                    "планка ЛДСП // вставляем между боковыми панелями доску ЛДСП шириной 100 мм",
                    "помощь"
                }
            };
        }

        public override void SetupView(RadGridView dgv, DataTable table)
        {
            dgv.Columns.Clear();
            dgv.DataSource = null;
            _resultTable = table;
            dgv.DataSource = table;
            dgv.MasterTemplate.AllowAddNewRow = false;

            foreach (var row in dgv.Rows) row.Height = 50;

            dgv.Columns["Изображение"].IsVisible = false;
            dgv.Columns["Задняя стенка"].IsVisible = false;
            dgv.Columns.Remove("Крепление полки");
            dgv.Columns.Remove("Кол-во полок");
            dgv.Columns["Тип фасада"].IsVisible = false;
            dgv.Columns["Материал фасада"].IsVisible = false;
            dgv.Columns["Режим расчёта"].IsVisible = false;
            dgv.Columns["Сборка модуля"].IsVisible = false;
            dgv.Columns["ПОСУДОСУШИЛКА"].IsVisible = false;
            dgv.Columns["Навесы на стену"].IsVisible = false;

            dgv.Columns.Insert(10, GetModuleAssembly());
            dgv.Columns.Insert(10, GetBackPanelAssemblyColumns());
            dgv.Columns.Insert(20, GetFacadeMaterial());
            dgv.Columns.Insert(16, GetFacadeType());
            dgv.Columns.Insert(17, GetCalculationType());
            dgv.Columns.Insert(11, GetShelfPO());
            dgv.Columns.Insert(12, GetShelfMinus2MM());
            dgv.Columns.Insert(3, GetIcon());
            dgv.Columns.Insert(21, GetDishDrayer());
            dgv.Columns.Insert(22, GetCanopies());

            foreach (var column in dgv.Columns)
            {
                column.WrapText = true;
                column.Width = 150;
            }

            dgv.Columns[0].Width = 70;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;

            var view = SetColumnGroupsView();
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
                var path = _resultTable.Rows[e.RowIndex][2].ToString();
                var parts = path.Split('_');
                var bigImagePath = parts[0] + "_" + parts[1] + "_big.png";

                var customerHelpForm = Application.OpenForms["BigModuleImageInfo"];
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

        private GridViewColumnGroup ColumnGroupsAdd(string columnGroupText, IEnumerable<string> columnNames, bool showHeader = false)
        {
            var gridViewColumnGroupRow = new GridViewColumnGroupRow();
            foreach (var columnName in columnNames)
                gridViewColumnGroupRow.ColumnNames.Add(columnName);

            var gridViewColumnGroup = new GridViewColumnGroup(columnGroupText) { ShowHeader = showHeader };
            gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);

            return gridViewColumnGroup;
        }

        private ColumnGroupsViewDefinition SetColumnGroupsView()
        {
            var view = new ColumnGroupsViewDefinition();

            view.ColumnGroups.Add(ColumnGroupsAdd("Num", new[] { "Название модуля" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("I", new[] { "Icon" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("Размеры", new[]
            {
                "Высота модуля (мм)",
                "Ширина модуля (мм)",
                "Глубина модуля (мм)",
                "A размер (мм)",
                "B размер (мм)",
                "C размер (мм)",
                "D размер (мм)"
            }, true));
            view.ColumnGroups.Add(ColumnGroupsAdd("zertg", new[] { "Сборка модуля2" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("z", new[] { "Задняя стенка2" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("ppse", new[] { "Крепление полки", "Кол-во полок" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("Фасад", new[]
            {
                "№ схемы фасада",
                "Высота",
                "Ширина",
                "Тип фасада2",
                "Режим расчёта2",
                "Материал фасада2"
            }, true));
            view.ColumnGroups.Add(ColumnGroupsAdd("ПОСУДОСУШИЛКА", new[] { "ПОСУДОСУШИЛКА2" }));
            view.ColumnGroups.Add(ColumnGroupsAdd("Навесы на стену", new[] { "Навесы на стену2" }));


            return view;
        }

        private void Dgv_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "Задняя стенка2" ||
                e.Column.Name == "Тип фасада2")
            {
                _columnName = e.Column.Name;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement)
                    .SelectedIndexChanged -= Form1_SelectedIndexChanged;
                ((RadDropDownListEditorElement)((RadDropDownListEditor)e.ActiveEditor).EditorElement)
                    .SelectedIndexChanged += Form1_SelectedIndexChanged;
            }
        }

        private void Form1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            var editor = sender as RadDropDownListEditorElement;

            if (editor?.SelectedItem != null && editor.SelectedItem.Text == "что это?") ShowHelpForm(_columnName);
        }

        private void ShowHelpForm(string columnName)
        {
            var path = _resultTable.Rows[0][2].ToString();
            var parts = path.Split('_');
            string bigImagePath;

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
                if (e.CellElement.ColumnIndex == 3)
                    if (_resultTable.Rows[e.RowIndex]["Изображение"].ToString().Length != 0)
                    {
                        var pathToImage = Environment.CurrentDirectory + "\\" +
                                          _resultTable.Rows[e.RowIndex]["Изображение"];
                        e.CellElement.Image = Image.FromFile(pathToImage);
                    }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
