using Automation.Infrastructure.GlobalSettings;
using System;
using System.Windows.Forms;

namespace Automation.View.GlobalVariables
{
    public partial class UpModuleDimensionVariables : Form
    {
        private readonly bool _isLoaded;
        public UpModuleDimensionVariables()
        {
            InitializeComponent();
            LoadValues();
            _isLoaded = true;
        }


        private void LoadValues()
        {
            // Facades
            comboBox1.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            comboBox2.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            comboBox3.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            comboBox4.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            comboBox5.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();
            comboBox6.DataSource = UpModuleFacadesDimensionVariables.Values.Clone();

            comboBox1.SelectedItem = UpModuleFacadesDimensionVariables.LowByHeight;
            comboBox2.SelectedItem = UpModuleFacadesDimensionVariables.LowByWidth;
            comboBox3.SelectedItem = UpModuleFacadesDimensionVariables.GapBetweenFacadesByHeight;
            comboBox4.SelectedItem = UpModuleFacadesDimensionVariables.GapBetweenFacadesByWidth;
            comboBox5.SelectedItem = UpModuleFacadesDimensionVariables.GapBetweenBoxesByHeight;
            comboBox6.SelectedItem = UpModuleFacadesDimensionVariables.GapBetweenBoxesByWidth;

            //Shelfs
            comboBox7.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();
            comboBox8.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();
            comboBox9.DataSource = UpModuleShelfsDimensionVariables.Values.Clone();

            comboBox7.SelectedItem = UpModuleShelfsDimensionVariables.ShelfDepth;
            comboBox8.SelectedItem = UpModuleShelfsDimensionVariables.ShelfWidth;
            comboBox9.SelectedItem = UpModuleShelfsDimensionVariables.GlassShelfDepth;

            //BackWall
            comboBox10.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();
            comboBox11.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();
            comboBox12.DataSource = UpModuleBackWallDimensionVariables.Values.Clone();

            comboBox10.SelectedItem = UpModuleBackWallDimensionVariables.BackHeight;
            comboBox11.SelectedItem = UpModuleBackWallDimensionVariables.BackWidth;
            comboBox12.SelectedItem = UpModuleBackWallDimensionVariables.BackDishesHeight;

            //Mount
            comboBox13.DataSource = UpModuleMountDimensionVariables.MinMountPlankValues;
            comboBox14.DataSource = UpModuleMountDimensionVariables.ModuleDepthValues;
            comboBox15.DataSource = UpModuleMountDimensionVariables.MaxMountPlankValues;

            comboBox13.SelectedItem = UpModuleMountDimensionVariables.MinMountPlank;
            comboBox14.SelectedItem = UpModuleMountDimensionVariables.ModuleDepth;
            comboBox15.SelectedItem = UpModuleMountDimensionVariables.MaxMountPlank;

            //Boxes
            comboBox16.DataSource = UpModuleBoxesDimensionVariables.DepthValues;
        }

        private void simpleValueChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            var activaTab = tabControl1.SelectedTab;
            var variableType = (string) activaTab.Tag;
            var variableName = (string)((ComboBox)sender).Tag;
            var value = (int)((ComboBox)sender).SelectedValue;

            switch (variableType)
            {
                case "UpModuleFacadesDimensionVariables":
                    UpModuleFacadesDimensionVariables.SetValue(variableName, value);
                    break;
                case "UpModuleShelfsDimensionVariables":
                    UpModuleShelfsDimensionVariables.SetValue(variableName, value);
                    break;
                case "UpModuleBackWallDimensionVariables":
                    UpModuleBackWallDimensionVariables.SetValue(variableName, value);
                    break;
                case "UpModuleMountDimensionVariables":
                    UpModuleMountDimensionVariables.SetValue(variableName, value);
                    break;
                case "UpModuleBoxesDimensionVariables":
                    UpModuleBoxesDimensionVariables.SetValue(variableName, value);
                    break;
                default:
                    throw new Exception("Не выбран тип переменной");
            }
           
        }


    }
}
