using System.Windows.Forms;

namespace Automation.View.Model
{
   public static class CategoriesUtilsTable
    {
       public static void AddProductRowDgv(DataGridView dataGridView, string moduleName)
       {
           object[] row = {moduleName, "0"};
           dataGridView.Rows.Add(row);
       }

       public static void AddCategoryRow(DataGridView dataGridView, string moduleName, string modulesCount)
       {
           object[] row = { moduleName, modulesCount };
           dataGridView.Rows.Add(row);
       }



    }
}
