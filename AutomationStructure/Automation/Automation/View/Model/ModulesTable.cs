using System.Windows.Forms;

namespace Automation.View.Model
{
   public static class ModulesTable
    {
       public static void AddProductRowDgv(DataGridView dataGridView, string moduleName)
       {
           object[] row = {moduleName, "0"};
           dataGridView.Rows.Add(row);
       }

    }
}
