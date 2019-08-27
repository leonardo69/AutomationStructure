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
            var categoryName = page.Title;
            var category= Presenter.GetCategoryByName(categoryName);
            var modules = category.GetAllModules();  
            
            var panel = flowLayoutPanel2; //get flow control from page
           
            
            foreach (var module in modules)
            {
                var moduleInfo = new ModuleInfo();
                var result = module.Calculate();
                moduleInfo.BindData(result.ModuleName, result.ImagePath, result.MainInfo, result.DetailsInfo, result.ShelfInfo,
                    result.FurnitureInfo, result.LoopsInfo);
                moduleInfo.Width = flowLayoutPanel2.Width - 25;
                moduleInfo.OnModuleExport += CreateModuleReport;
                panel.Controls.Add(moduleInfo);
            }

            panel.Resize += Panel_Resize;


        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            if (!(sender is FlowLayoutPanel panel)) return;

            foreach (var control in panel.Controls)
            {
                ((ModuleInfo) control).Width = panel.Width - 25;
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
            var ldspInfo = Presenter.GetCountGroupInfo("DetailsInfo");
            DataTable backWallInfo = Presenter.GetCountGroupInfo("ShelfInfo");
            DataTable furnitureInfo =  Presenter.GetCountGroupInfo("FurnitureInfo");
            DataTable facadeInfo = Presenter.GetCountGroupInfo("LoopsInfo");

            detailsCountGroupComponent.BindData(ldspInfo, backWallInfo, furnitureInfo, facadeInfo);
        }
        
        private void LoadAllDetailsGroupReport()
        {
            var ldspInfo = Presenter.GetAllDetailsGroupInfo("DetailsInfo");
            DataTable backWallInfo = Presenter.GetAllDetailsGroupInfo("ShelfInfo");
            DataTable furnitureInfo = Presenter.GetAllDetailsGroupInfo("FurnitureInfo");
            DataTable facadeInfo = Presenter.GetAllDetailsGroupInfo("LoopsInfo"); 

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
