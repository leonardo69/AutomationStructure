using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Automation.Controls;
using Automation.Infrastructure;
using Automation.Model;
using Automation.View.ModuleViewGenerator;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class Results : Telerik.WinControls.UI.RadForm
    {
        private Presenter Presenter { get; set; }


        public Results(Presenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            HideAllPages();
            LoadProducts();
            LoadReport();
        }

        private void HideAllPages()
        {
            foreach (var page in radPageView1.Pages)
            {
                page.Item.Visibility = ElementVisibility.Collapsed;
            }
           
            
        }

        private void LoadProducts()
        {
            var products = Presenter.GetAllProducts().Select(x=>x.Type.ToString()).ToList();
            foreach (var page in radPageView1.Pages)
            {
                if (products.Contains(page.Title))
                {
                    LoadModules(page);
                    page.Item.Visibility = ElementVisibility.Visible;
                }
            }
        }

        private void LoadReport()
        {
           radPageViewPage3.Visible = Visible;
           reportModule.BindData(Report.GetLdspInfo(), Report.GetBackPanelAssemblyInfo(), Report.GetFurnitureInfo(), Report.GetFasadeInfo());
        }

        private void LoadModules(RadPageViewPage page)
        {
            var productName = page.Title;
            var product= Presenter.GetProductByName(productName);
            var modules = product.GetAllModules();  
            

            FlowLayoutPanel panel = flowLayoutPanel2; //get flow control from page
         

            foreach (var module in modules)
            {
                ModuleInfo infoModule = new ModuleInfo();
                var result = module.Calculate();
                infoModule.BindData(result.ModuleName, result.ImagePath, result.MainInfo, result.DetailsInfo, result.ShelfInfo,
                    result.FurnitureInfo, result.LoopsInfo);
                infoModule.Width = flowLayoutPanel2.Width - 3;
                panel.Controls.Add(infoModule);
            }
            
        }
    }
}
