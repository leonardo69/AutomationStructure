using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Automation.Controls
{
    public partial class ReportWindow : Form
    {
        private DataTable _detailsInfo;
        private DataTable _furniture;
        private string _imagePath;
        private DataTable _loopsInfo;
        private DataTable _mainInfo;
        private string _moduleName;
        private DataTable _shelfInfo;

        public ReportWindow()
        {
            InitializeComponent();
        }

        public ReportWindow(string moduleName, string imagePath, 
            DataTable mainInfo, DataTable detailsInfo, 
            DataTable loopsInfo, DataTable shelfInfo, DataTable furniture)
        {
            _moduleName = moduleName;
            _imagePath = imagePath;
            _mainInfo = mainInfo;
            _detailsInfo = detailsInfo;
            _loopsInfo = loopsInfo;
            _shelfInfo = shelfInfo;
            _furniture = furniture;
            Test();
        }

        private void Test()
        {
        

            //ReportDataSet ds = new ReportDataSet();
            ReportDataSource firstDs = new ReportDataSource
            {
                Name = "main",
                Value = _mainInfo
            };

            reportViewer1.LocalReport.DataSources.Add(firstDs);
            reportViewer1.RefreshReport();
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {
       
        }
    }
}
