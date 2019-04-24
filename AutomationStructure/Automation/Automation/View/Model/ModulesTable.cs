using System.Windows.Forms;

namespace Automation.View.Model
{
   public static class ModulesTable
    {
       public static void AddProductRowDgv(DataGridView datagrid, string moduleName)
       {
           string[] row = {moduleName, "0"};
           datagrid.Rows.Add(row);
       }

    }
}
