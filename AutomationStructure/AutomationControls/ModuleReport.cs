using System.Data;
using System.Windows.Forms;

namespace Automation.Controls
{
    public partial class ModuleReport : UserControl
    {
        public ModuleReport()
        {
            InitializeComponent();
        }

        public void BindData( DataTable ldspInfo, DataTable backWallInfo, DataTable furnitureInfo, DataTable facadeInfo)
        {
            LDSPDetails.DataSource = ldspInfo;
            BackWallDetails.DataSource = backWallInfo;
            FurnitureDetails.DataSource = furnitureInfo;
            FasadeDetails.DataSource = facadeInfo;
        }
    }
}
