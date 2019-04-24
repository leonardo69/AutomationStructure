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
            {"0,4 (стандарт)", 0.01},
            {"0,5", 0.5},
            {"1", 1},
            {"2", 2},
            {"0,4 (min)", 0.01},
            {"0,4 (max)", 0.01},
            {"0,4...2 (оптим.)", 0.01},
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

        public static void InitCustomerTable(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 500;
            dataGridView1.Columns[2].Width = 200;
  
            dataGridView1.Rows[0].Cells[0].Value = "ЛДСП";
            dataGridView1.Rows[1].Cells[0].Value = "Кромка для ЛДСП";
            dataGridView1.Rows[2].Cells[0].Value = "Задняя панель";
            dataGridView1.Rows[3].Cells[0].Value = "Фасад";


            var comboboxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[0].Cells[2];
            comboboxCell.Items.Clear();
            comboboxCell.Value = null;

            SetCell(PlateThickness.Keys.ToList(), comboboxCell);

            var comboboxCell2 = (DataGridViewComboBoxCell)dataGridView1.Rows[1].Cells[2];
            comboboxCell2.Items.Clear();
            comboboxCell2.Value = null;

            SetCell(KromkaThickness.Keys.ToList(), comboboxCell2);

            var comboboxCell3 = (DataGridViewComboBoxCell)dataGridView1.Rows[2].Cells[2];
            comboboxCell3.Items.Clear();
            comboboxCell3.Value = null;

            SetCell(BackPanelThickness.Keys.ToList(), comboboxCell3);

            var helpButton = (DataGridViewButtonColumn) dataGridView1.Columns[3];
            helpButton.UseColumnTextForButtonValue = true;
            helpButton.Text = "?";

        }

        private static void SetCell(List<string> titles, DataGridViewComboBoxCell comboboxCell)
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
