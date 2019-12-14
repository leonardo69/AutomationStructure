using Automation.Infrastructure.GlobalSettings;
using Telerik.WinControls.UI;

namespace Automation.View
{
    public partial class UpModuleDimensionVariables : RadForm
    {
        private readonly bool _isLoaded;
        public UpModuleDimensionVariables()
        {
            InitializeComponent();
            LoadFacadesValues();
            LoadShelfsValues();
            LoadBackWallValues();
            LoadMountValues();
            LoadBoxesValues();
            _isLoaded = true;
        }

        #region Facades

        private void LoadFacadesValues()
        {
            radDropDownList1.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            radDropDownList2.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            radDropDownList3.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            radDropDownList4.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            radDropDownList5.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            radDropDownList6.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();

            radDropDownList1.SelectedValue = UpModuleFacadesDimensionVariables.LowByHeight;
            radDropDownList2.SelectedValue = UpModuleFacadesDimensionVariables.LowByWidth;
            radDropDownList3.SelectedValue = UpModuleFacadesDimensionVariables.GapBetweenFacadesByHeight;
            radDropDownList4.SelectedValue = UpModuleFacadesDimensionVariables.GapBetweenFacadesByWidth;
            radDropDownList5.SelectedValue = UpModuleFacadesDimensionVariables.GapBetweenBoxesByHeight;
            radDropDownList6.SelectedValue = UpModuleFacadesDimensionVariables.GapBetweenBoxesByWidth;

        }

        private void fasades_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var variableName = (string)((RadDropDownList)sender).Tag;
            var value = (int)((RadDropDownList)sender).SelectedValue;
            UpModuleFacadesDimensionVariables.SetValue(variableName, value);
        }


        #endregion

        #region Shelfs

        private void LoadShelfsValues()
        {
            radDropDownList7.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();
            radDropDownList8.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();
            radDropDownList9.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();

            radDropDownList7.SelectedValue = UpModuleShelfsDimensionVariables.ShelfDepth;
            radDropDownList8.SelectedValue = UpModuleShelfsDimensionVariables.ShelfWidth;
            radDropDownList9.SelectedValue = UpModuleShelfsDimensionVariables.GlassShelfDepth;

        }

        private void shelfs_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var variableName = (string)((RadDropDownList)sender).Tag;
            var value = (int)((RadDropDownList)sender).SelectedValue;
            UpModuleShelfsDimensionVariables.SetValue(variableName, value);
        }


        #endregion

        #region BackWall

        private void LoadBackWallValues()
        {
            radDropDownList10.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();
            radDropDownList11.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();
            radDropDownList12.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();

            radDropDownList10.SelectedValue = UpModuleBackWallDimensionVariables.BackHeight;
            radDropDownList11.SelectedValue = UpModuleBackWallDimensionVariables.BackWidth;
            radDropDownList12.SelectedValue = UpModuleBackWallDimensionVariables.BackDishesHeight;

        }

        private void backwall_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var variableName = (string)((RadDropDownList)sender).Tag;
            var value = (int)((RadDropDownList)sender).SelectedValue;
            UpModuleBackWallDimensionVariables.SetValue(variableName, value);
        }


        #endregion

        #region Mount
        private void LoadMountValues()
        {
            radDropDownList13.DataSource = UpModuleMountDimensionVariables.MinMountPlankValues;
            radDropDownList14.DataSource = UpModuleMountDimensionVariables.ModuleDepthValues;
            radDropDownList15.DataSource = UpModuleMountDimensionVariables.MaxMountPlankValues;

            radDropDownList13.SelectedValue = UpModuleMountDimensionVariables.MinMountPlank;
            radDropDownList14.SelectedValue = UpModuleMountDimensionVariables.ModuleDepth;
            radDropDownList15.SelectedValue = UpModuleMountDimensionVariables.MaxMountPlank;

        }

        private void mount_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var variableName = (string)((RadDropDownList)sender).Tag;
            var value = (int)((RadDropDownList)sender).SelectedValue;
            UpModuleMountDimensionVariables.SetValue(variableName, value);
        }


        #endregion

        #region Boxes
        private void LoadBoxesValues()
        {
            radDropDownList16.DataSource = UpModuleBoxesDimensionVariables.DepthValues;

        }

        private void boxes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var variableName = (string)((RadDropDownList)sender).Tag;
            var value = (int)((RadDropDownList)sender).SelectedValue;
            UpModuleBoxesDimensionVariables.SetValue(variableName, value);
        }


        #endregion

    }
}
