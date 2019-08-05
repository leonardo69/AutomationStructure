using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Automation.View.Model
{
    public static class CustomerTable
    {
        private static Dictionary<string, int> PlateThickness { get; } = new Dictionary<string, int>
        {
            {"10 мм", 10},
            {"16 мм", 16},
            {"18 мм", 18},
            {"20 мм", 20},
            {"22 мм", 22}
        };

        public static Dictionary<string, double> KromkaThickness { get; } = new Dictionary<string, double>
        {
            {"нет", 0},
            {"0,4 (стандарт)", 0.4},
            {"1", 1},
            {"2", 2},
            {"0,4 (min)", 0.4},
            {"0,4 (max)", 0.4},
            {"0,4...2 (оптим.)", 2},
            {"опционально", 0}
        };

        private static Dictionary<string, double> BackPanelThickness { get; } = new Dictionary<string, double>
        {
            {"нет", 0},
            {"3,2 мм", 3.2},
            {"4 мм (станд.) ДВА, фанера", 4},
            {"4,2 мм ДВП импорт.", 4.2},
            {"6 мм", 6},
            {"8 мм", 8},
            {"10 мм", 10},
            {"12 мм", 12},
            {"16 мм", 16}
        };

        private static void CellRowsSet(DataGridViewComboBoxCell dataGridViewComboBoxCell, IEnumerable<string> rows)
        {
            dataGridViewComboBoxCell.Items.Clear();
            dataGridViewComboBoxCell.Value = null;
            SetCell(rows, dataGridViewComboBoxCell);
        }

        public static void InitCustomerTable(DataGridView dataGridView1)
        {
            for (int i = 1; i <= 4; i++)
                dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[0].Value = "ЛДСП";
            dataGridView1.Rows[1].Cells[0].Value = "Кромка для ЛДСП";
            dataGridView1.Rows[2].Cells[0].Value = "Задняя панель";
            dataGridView1.Rows[3].Cells[0].Value = "Фасад";

            CellRowsSet((DataGridViewComboBoxCell)dataGridView1.Rows[0].Cells[2], PlateThickness.Keys.ToArray());
            CellRowsSet((DataGridViewComboBoxCell)dataGridView1.Rows[1].Cells[2], KromkaThickness.Keys.ToArray());
            CellRowsSet((DataGridViewComboBoxCell)dataGridView1.Rows[2].Cells[2], BackPanelThickness.Keys.ToArray());


            dataGridView1.Rows[0].Cells[2].Value = "16 мм";
            dataGridView1.Rows[1].Cells[2].Value = "1";
            dataGridView1.Rows[2].Cells[2].Value = "4 мм (станд.) ДВА, фанера";

            var helpButton = (DataGridViewButtonColumn)dataGridView1.Columns[3];
            helpButton.UseColumnTextForButtonValue = true;
            helpButton.Text = "?";

        }

        private static void SetCell(IEnumerable<string> titles, DataGridViewComboBoxCell comboboxCell)
        {
            foreach (var title in titles)
            {
                comboboxCell.Items.Add(title);
            }
        }

        public static List<string[]> GetData(DataGridView dataGridView, string thickness)
        {
            List<string[]> customerInfo = new List<string[]>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string[] record = new string[3];

                for (int i = 0; i < 3; i++)
                {
                    var item = row.Cells[i].Value;
                    record[i] = item == null ? " " : ((string) item == "подробнее" ? thickness : (string) item);
                }

                customerInfo.Add(record);
            }
            return customerInfo;
        }

    }
}
