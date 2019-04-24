using System.Data;
using Telerik.WinControls.UI;

namespace Automation.View.ModuleViewGenerator
{
    public abstract class ViewGenerator
    {
        public abstract void SetupView(RadGridView dgv, DataTable table);
    }
}
