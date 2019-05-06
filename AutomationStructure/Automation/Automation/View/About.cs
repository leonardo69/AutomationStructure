
using System;
using System.Reflection;

namespace Automation.View
{
    public partial class About : Telerik.WinControls.UI.RadForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            logoPictureBox.Image = Properties.Resources.About;
            lblProductName.Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            lblVersion.Text = $@"Версия {Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}";
            lblDevelopers.Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
            lblCopyright.Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        }
    }
}
