﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Automation.Controls
{
    public partial class ModuleInfo: UserControl
    {
        public ModuleInfo()
        {
            InitializeComponent();
        }

        public EventHandler OnModuleExport;
        public string ModuleName { get; set;}

        public void BindData(string moduleName, Image image, DataTable dimensionsInfo, DataTable detailsInfo, DataTable shelfInfo, DataTable furnitureInfo, DataTable loopsInfo)
        {
            ModuleName = moduleName;
            moduleNameLbl.Text = moduleName;
            modulePbx.Image = image;
            mainInfoDgv.DataSource = dimensionsInfo;
            detailsDgv.DataSource = detailsInfo;
            // loopsInfoDgv.DataSource = loopsInfo;
            // shelfInfoDgv.DataSource = shelfInfo;
            furnitureDgv.DataSource = furnitureInfo;
        }

        private void moduleReportBtn_Click(object sender, EventArgs e)
        {
            OnModuleExport?.Invoke(this, e);
        }
    }
}
