using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class SubSchemeModule : Telerik.WinControls.UI.RadForm
    {
        public event EventHandler<SchemeArgs> onTypeChanged; 

        public SubSchemeModule(List<ModuleItem> items, string productName)
        {
            InitializeComponent();
            LoadImages(items,productName);
        }

        public void LoadImages(List<ModuleItem> items , string productName)
        {
            if (items.Count!=0)
            {
                radListView1.ItemSize = new Size(200, 200);
                radListView1.ItemSpacing = 10;

                foreach (var scheme in items)
                {
                    ListViewDataItem item = new ListViewDataItem(scheme.Name)
                    {
                        BackColor = Color.WhiteSmoke,
                        Image = Image.FromFile(Environment.CurrentDirectory + "\\" + productName + "\\" + scheme.Folder + "\\" + scheme.ImagePath),
                        Text = scheme.Name,
                        NumberOfColors = 2,
                        ImageAlignment = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        TextAlignment = ContentAlignment.BottomCenter,
                        Tag =  productName + "\\" + scheme.Folder + "\\" + scheme.ImagePath

                    };
                    radListView1.Items.Add(item);
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            SelectSubSchemeType();
        }

        private void SelectSubSchemeType()
        {
            if (radListView1.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите подтип схемы модуля!");
            }

            var subSchemeName = radListView1.SelectedItem.Text;
            var subSchemePath = radListView1.SelectedItem.Tag.ToString();
            onTypeChanged(this, new SchemeArgs {SubSchemeName = subSchemeName, SubSchemePath = subSchemePath});
            Close();
        }

        private void radListView1_ItemMouseDoubleClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            SelectSubSchemeType();
        }
    }

    public class SchemeArgs : EventArgs
    {
        public string SubSchemeName { get; set; }
        public string SubSchemePath { get; set; }
    }
}
