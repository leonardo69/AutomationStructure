using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Automation.Infrastructure.GlobalSettings;
using Telerik.WinControls;

namespace Automation.View
{
    public partial class GlobalVariables : Telerik.WinControls.UI.RadForm
    {
        private readonly bool _isLoaded;
        public GlobalVariables()
        {
            InitializeComponent();
            InitExtraCantValues();
            _isLoaded = true;
        }

        private void InitExtraCantValues()
        {
            //extra_cant.DataSource = GeneralGlobalVariables.extra_kant_values;
            //extra_cant.SelectedValue = GeneralGlobalVariables.extra_kant;
        }

        private void extra_cant_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isLoaded)
            {
                //GeneralGlobalVariables.extra_kant = (int) extra_cant.SelectedValue;
            }
        }
    }
}
