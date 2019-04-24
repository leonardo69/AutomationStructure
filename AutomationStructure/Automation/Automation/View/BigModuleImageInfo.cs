using System;
using System.IO;
using System.Windows.Forms;

namespace Automation.View.ModuleViewGenerator
{
    public partial class BigModuleImageInfo : Telerik.WinControls.UI.RadForm
    {
        public BigModuleImageInfo(string pathImage)
        {
            InitializeComponent();
            LoadImage(pathImage);
        }

        private void LoadImage(string pathImage)
        {
            if (pathImage!=null)
            {
                var fullPath = Environment.CurrentDirectory + "\\" + pathImage;
                if (File.Exists(fullPath))
                {
                    pictureBox1.Load(fullPath);
                }
               
            }
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
