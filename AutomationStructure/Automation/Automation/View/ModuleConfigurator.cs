using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class ModuleConfigurator : RadForm
    {
        //private XDocument _doc;

        private string _imageSubSchemePath;

        public ModuleConfigurator(string productName)
        {
            InitializeComponent();
            ProductName = productName;
            var t = Automation.KitchenUpLib.Properties.Resources.kitchen_up_one_fasade_left;
            
            // LoadSchemeImages(productName);
            // SetupFirstModule();

            // radListView1.AllowRemove = false;
            // radListView1.AllowEdit = false;
        }


        private new string ProductName { get; }

        public event EventHandler<ConfiguratorArgs> OnApply;

        private void SetupFirstModule()
        {
            if (radListView1.Items.Count != 0) schemeTxb.Text = radListView1.SelectedItem.Text;
        }

        private void LoadSchemeImages(string productName)
        {
            //var pathToInfoFile = Environment.CurrentDirectory + "\\" + productName + "\\info.xml";

            //_doc = XDocument.Load(pathToInfoFile);

            //if (_doc.Root == null) return;
            //var schemeModules = _doc.Root.Elements("type").Select(t => new ModuleItem
            //{
            //    Name = t.Attribute("name")?.Value,
            //    Folder = t.Attribute("folder")?.Value,
            //    ImagePath = t.Attribute("imagePath")?.Value
            //});

            var schemeModules = KitchenUpLib.Properties.Resources.ResourceManager
                .GetResourceSet(CultureInfo.CurrentCulture, true, true)
                .Cast<DictionaryEntry>()
                .Select(x => new
                {
                    Name = x.Key.ToString(),
                    Image = x.Value
                }).ToList();



            var moduleItems = schemeModules.ToList();
            if (moduleItems.Count == 0) return;
            radListView1.ItemSize = new Size(200, 200);
            radListView1.ItemSpacing = 10;

            foreach (var scheme in moduleItems)
            {
                var item = new ListViewDataItem(scheme.Name)
                {
                    BackColor = Color.WhiteSmoke,
                    Image = Image.FromFile(Environment.CurrentDirectory + "\\" + productName + "\\" +
                                           scheme.Folder + "\\" + scheme.ImagePath),
                    Text = scheme.Name,
                    NumberOfColors = 2,
                    ImageAlignment = ContentAlignment.MiddleCenter,
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    TextAlignment = ContentAlignment.BottomCenter
                };
                radListView1.Items.Add(item);
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if ((moduleNumberTxb.Text.Length == 0) | (schemeTxb.Text.Length == 0) | (subSchemeTxb.Text.Length == 0))
            {
                MessageBox.Show(@"Введите номер нового модуля и выберите форму и подтип формы модуля");
                return;
            }

            var moduleNumber = moduleNumberTxb.Text;
            var moduleSchemeName = schemeTxb.Text;
            var moduleSubSchemeName = subSchemeTxb.Text;
            var args = new ConfiguratorArgs
            {
                Number = moduleNumber,
                SchemeName = moduleSchemeName,
                SubSchemeName = moduleSubSchemeName,
                PathToImageSubScheme = _imageSubSchemePath
            };

            OnApply?.Invoke(this, args);
            Close();
        }


        private void RadListView1_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            OpenSubSchemeSelector();
        }

        private void OpenSubSchemeSelector()
        {
            if (_doc.Root == null) return;
            var typeNode = _doc.Root.Elements("type").First(t => t.Attribute("name")?.Value == schemeTxb.Text);
            var items =
                typeNode.Elements("subType")
                    .Select(
                        t =>
                            new ModuleItem
                            {
                                Name = t.Attribute("name")?.Value,
                                Folder = t.Attribute("folder")?.Value,
                                ImagePath = t.Attribute("imagePath")?.Value
                            })
                    .ToList();
            var subSchemeSelector = new SubSchemeModule(items, ProductName);
            subSchemeSelector.onTypeChanged += SetSubSchemeType;
            subSchemeSelector.Show();
        }

        private void SetSubSchemeType(object sender, SchemeArgs e)
        {
            subSchemeTxb.Text = e.SubSchemeName;
            _imageSubSchemePath = e.SubSchemePath;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (schemeTxb.Text != string.Empty)
                OpenSubSchemeSelector();
            else MessageBox.Show(@"Сначала выберите форму модуля");
        }

        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            schemeTxb.Text = radListView1.SelectedItem.Text;
        }
    }

    public class ModuleItem
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string ImagePath { get; set; }
    }


    public class ConfiguratorArgs : EventArgs
    {
        public string Number { get; set; }
        public string SchemeName { get; set; }
        public string SubSchemeName { get; set; }
        public string PathToImageSubScheme { get; set; }
    }
}