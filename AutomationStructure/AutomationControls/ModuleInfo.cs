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
    public partial class ModuleInfo: UserControl
    {
        public ModuleInfo()
        {
            InitializeComponent();
        }

        private string _moduleName;
        private string _imagePath;
        private DataTable _mainInfo;
        private DataTable _detailsInfo;
        private DataTable _loopsInfo;
        private DataTable _shelfInfo;
        private DataTable _furniture;



        public void BindData(string moduleName, string imagePath, DataTable dimensionsInfo, DataTable detailsInfo, DataTable shelfInfo, DataTable furnitureInfo, DataTable loopsInfo)
        {
            moduleNameLbl.Text =_moduleName = moduleName;
            modulePbx.Load(imagePath);
            _imagePath = imagePath;
            mainInfoDgv.DataSource = _mainInfo =  dimensionsInfo;
            detailsDgv.DataSource = _detailsInfo = detailsInfo;
            loopsInfoDgv.DataSource = _loopsInfo = loopsInfo;
            shelfInfoDgv.DataSource = _shelfInfo = shelfInfo;
            furnitureDgv.DataSource = _furniture = furnitureInfo;


        }

        public void SetViewDefinitions(ColumnGroupsViewDefinition dimensionsVd, ColumnGroupsViewDefinition detailsVd, ColumnGroupsViewDefinition furnitureVd)
        {
            mainInfoDgv.ViewDefinition = dimensionsVd;
            detailsDgv.ViewDefinition = detailsVd;
            furnitureDgv.DataSource = furnitureVd;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            new ReportWindow(_moduleName, _imagePath, _mainInfo,_detailsInfo,_loopsInfo, _shelfInfo,_furniture).Show();
            
        }
    }
}
