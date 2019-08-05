using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.View.Model
{
    public static class ThicknessMapping
    {
        public static IDictionary<string, object> DctMaping { get; set; }

        static ThicknessMapping()
        {
            DctMaping = new Dictionary<string, object>();
        }

        public static void GridSave(DataGridView dataGridView, int intColumnIndex)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                if (!DctMaping.ContainsKey($"{dataGridView.Name}.{row.Index.ToString()}"))
                  DctMaping.Add($"{dataGridView.Name}.{row.Index.ToString()}", row.Cells[intColumnIndex].Value);
        }

        public static void GridLoad(DataGridView grdData, int intColumnIndex)
        {
            foreach (DataGridViewRow row in grdData.Rows)
            {
                if (DctMaping.TryGetValue($"{grdData.Name}.{row.Index.ToString()}", out object objTemp))
                    row.Cells[intColumnIndex].Value = objTemp;
            }

        }
    }
}
