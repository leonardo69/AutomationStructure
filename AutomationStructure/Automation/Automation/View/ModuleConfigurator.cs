using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Automation.Infrastructure;
using Automation.Infrastructure.CreateRequest;
using Automation.Infrastructure.Utils;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleConfigurator : RadForm
    {
        public string CategoryName { get; }

        public ModuleConfigurator(CategoryType categoryType)
        {
            InitializeComponent();
            CategoryName = CategoryTypeInfo.Name(categoryType);
            
            LoadSchemeImages(categoryType);
            SetupFirstModule();

            radListView1.AllowRemove = false;
            radListView1.AllowEdit = false;
        }


        public event EventHandler<ConfiguratorArgs> OnApply;

        private void SetupFirstModule()
        {
            if (radListView1.Items.Count != 0) schemeTxb.Text = radListView1.SelectedItem.Text;
        }

        private void LoadSchemeImages(CategoryType categoryType)
        {

            var modulesFromLib = new List<LibItem>();

            switch (categoryType)
            {
                case CategoryType.KitchenUp:
                    modulesFromLib = KitchenUpLib.KitchenUpLib.GetAllModules();
                    break;
                case CategoryType.KitchenDown:
                    modulesFromLib = KitchenDownLib.KitchenDownLib.GetAllModules();
                    break;
            }

            radListView1.ItemSize = new Size(200, 200);
            radListView1.ItemSpacing = 10;

            foreach (var module in modulesFromLib)
            {
                var item = new ListViewDataItem(module.Name)
                {
                    BackColor = Color.WhiteSmoke,
                    Image = module.Image,
                    Text = module.Name,
                    NumberOfColors = 2,
                    Tag = module.ModuleInfo,
                    ImageAlignment = ContentAlignment.MiddleCenter,
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    TextAlignment = ContentAlignment.BottomCenter
                };
                radListView1.Items.Add(item);
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if ((moduleNumberTxb.Text.Length == 0) | (schemeTxb.Text.Length == 0))
            {
                MessageBox.Show(@"Введите номер нового модуля и выберите форму и подтип формы модуля");
                return;
            }

            var item = radListView1.SelectedItem;
            if (item == null)
            {
                MessageBox.Show(@"Сначала выберите модуль");
                return;
            }

            var info = (LibModuleInfo) item.Tag;

            var moduleNumber = moduleNumberTxb.Text;

            var args = new ConfiguratorArgs
            {
                Number = moduleNumber,
                Info = info
            };

            OnApply?.Invoke(this, args);
            Close();
        }



        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            schemeTxb.Text = radListView1.SelectedItem.Text;
        }
    }


    public class ConfiguratorArgs : EventArgs
    {
        public string Number { get; set; }
        public LibModuleInfo Info { get; set; }
    }
}