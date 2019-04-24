using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

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

        public void SetViewDefinitions(ColumnGroupsViewDefinition dimensionsVd, ColumnGroupsViewDefinition detailsVd, ColumnGroupsViewDefinition furnitureVd)
        {
            
        }
    }
}
