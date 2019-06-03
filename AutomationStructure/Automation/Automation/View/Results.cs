using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Automation.Controls;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class Results : RadForm
    {
        private Presenter Presenter { get; }


        public Results(Presenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            HideAllPages();
            LoadProducts();
            LoadGroupReport();
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
                infoModule.OnModuleExport += CreateModuleReport;
                panel.Controls.Add(infoModule);
            }
            
        }


        private void LoadGroupReport()
        {
            LoadAllDetailsGroupReport();
            LoadDetailsCountGroupReport();
            //radPageViewPage3.Visible = Visible;
            // reportModule.BindData(Report.GetLdspInfo(), Report.GetBackPanelAssemblyInfo(), Report.GetFurnitureInfo(), Report.GetFasadeInfo());
        }

        private void LoadDetailsCountGroupReport()
        {
        
        }
        
        private void LoadAllDetailsGroupReport()
        {
            DataTable ldspInfo = Presenter.GetLdspAllDetailsGroupInfo();
            DataTable backWallInfo = null;// Presenter.GetBackWallAllDetailsGroupInfo();
            DataTable furnitureInfo = null;//= Presenter.GetFurnitureAllDetailsGroupInfo();
            DataTable facadeInfo = null;// Presenter.GetFacadeAllDetailsGroupInfo();

            allDetailsGroupComponent.BindData(ldspInfo, backWallInfo, furnitureInfo, facadeInfo);
        }

        private void CreateModuleReport(object sender, EventArgs e)
        {
            var moduleName = ((ModuleInfo) sender).ModuleName;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = @"Сохранение отчёта по модулю", Filter = @"Docx | *.docx", FileName = moduleName+".docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = saveFileDialog.FileName;
                    Presenter.CreateModuleReport(moduleName, fileName);
                    MessageBox.Show(@"Отчёт по модулю создан");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка создания отчёта по модулю");
                }
               
            }
        }

        private void CommandBarButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = @"Сохранение отчёта по модулям",
                Filter = @"Docx | *.docx",
                FileName = "отчёт.docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = saveFileDialog.FileName;
                    Presenter.CreateAllModulesReport(fileName);
                    MessageBox.Show(@"Отчёт по модулям создан");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Ошибка создания отчёта по модулям");
                }

            }
        }
    }
}
