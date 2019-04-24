using System;
using System.Windows.Forms;

namespace Automation.View
{
    public partial class SimilarModule : Telerik.WinControls.UI.RadForm
    {
        public SimilarModule()
        {
            InitializeComponent();
        }

        public event EventHandler<SimilarEventArgs> OnApply;

        private void button1_Click(object sender,EventArgs e)
        {
            if (radTextBox1.Text.Length != 0)
            {
                SimilarEventArgs ea = new SimilarEventArgs();
                ea.SimilarName = radTextBox1.Text;
                OnApply(sender, ea);
                Close();
            }
            else
                MessageBox.Show("Введите новое название модуля");
        }
    }

    public class SimilarEventArgs : EventArgs
    {
        public string SimilarName { get; set; }
    }
}
