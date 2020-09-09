using Automation.Infrastructure.GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation.View.GlobalVariables
{
    public partial class DownModuleDimensionVariables : Form
    {
        private readonly bool _isLoaded;
        public DownModuleDimensionVariables()
        {
            InitializeComponent();
            LoadValues();
            _isLoaded = true;
        }

        private void LoadValues()
        {
            // Facades
            comboBox1.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();
            comboBox2.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();
            comboBox3.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();
            comboBox4.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();
            comboBox5.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();
            comboBox6.DataSource = DownModuleFacadesDimensionVariables.Values.Clone();

            comboBox1.SelectedItem = DownModuleFacadesDimensionVariables.LowByHeight;
            comboBox2.SelectedItem = DownModuleFacadesDimensionVariables.LowByWidth;
            comboBox3.SelectedItem = DownModuleFacadesDimensionVariables.GapBetweenFacadesByHeight;
            comboBox4.SelectedItem = DownModuleFacadesDimensionVariables.GapBetweenFacadesByWidth;
            comboBox5.SelectedItem = DownModuleFacadesDimensionVariables.GapBetweenBoxesByHeight;
            comboBox6.SelectedItem = DownModuleFacadesDimensionVariables.GapBetweenBoxesByWidth;

            // Shelfs
            comboBox7.DataSource = DownModuleShelfsDimensionVariables.Values.Clone();
            comboBox8.DataSource = DownModuleShelfsDimensionVariables.Values.Clone();
            comboBox9.DataSource = DownModuleShelfsDimensionVariables.Values.Clone();

            comboBox7.SelectedItem = DownModuleShelfsDimensionVariables.ShelfDepth;
            comboBox8.SelectedItem = DownModuleShelfsDimensionVariables.ShelfWidth;
            comboBox9.SelectedItem = DownModuleShelfsDimensionVariables.GlassShelfDepth;

            // Backwall
            comboBox10.DataSource = DownModuleBackwallDimensionVariables.Values.Clone();
            comboBox11.DataSource = DownModuleBackwallDimensionVariables.Values.Clone();
            comboBox12.DataSource = DownModuleBackwallDimensionVariables.SlotValues.Clone();

            comboBox10.SelectedItem = DownModuleBackwallDimensionVariables.BackHeight;
            comboBox11.SelectedItem = DownModuleBackwallDimensionVariables.BackWidth;
            comboBox12.SelectedItem = DownModuleBackwallDimensionVariables.BackSlot;

            // Boxes
            comboBox13.DataSource = DownModuleBoxDimensionVariables.Values.Clone();
            comboBox14.DataSource = DownModuleBoxDimensionVariables.DepthValues.Clone();
            comboBox15.DataSource = DownModuleBoxDimensionVariables.BoolValues.Clone();
            comboBox16.DataSource = DownModuleBoxDimensionVariables.GapValues.Clone();
            comboBox17.DataSource = DownModuleBoxDimensionVariables.GapValues.Clone();
            comboBox18.DataSource = DownModuleBoxDimensionVariables.GapValues.Clone();
            comboBox19.DataSource = DownModuleBoxDimensionVariables.GapValues.Clone();

            comboBox13.SelectedItem = DownModuleBoxDimensionVariables.Depth;
            comboBox14.SelectedItem = DownModuleBoxDimensionVariables.DepthSpace;
            comboBox15.SelectedItem = DownModuleBoxDimensionVariables.FacaseOnBox;
            comboBox16.SelectedItem = DownModuleBoxDimensionVariables.GapUpBox;
            comboBox17.SelectedItem = DownModuleBoxDimensionVariables.GapDownBox;
            comboBox18.SelectedItem = DownModuleBoxDimensionVariables.GapForFacade;
            comboBox19.SelectedItem = DownModuleBoxDimensionVariables.GapDownBoxGuide;


            //Side
            comboBox20.DataSource = DownModuleSideDimensionVariables.Values.Clone();
            comboBox21.DataSource = DownModuleSideDimensionVariables.HorValues.Clone();
            comboBox22.DataSource = DownModuleSideDimensionVariables.VerValues.Clone();

            comboBox20.SelectedItem = DownModuleSideDimensionVariables.GapDownAndSide;
            comboBox21.SelectedItem = DownModuleSideDimensionVariables.PlinthHorSize;
            comboBox22.SelectedItem = DownModuleSideDimensionVariables.PlinthVertSize;

            //Up panel
            comboBox23.DataSource = DownModuleUpPanelDimensionVariables.Values.Clone();
            comboBox24.DataSource = DownModuleUpPanelDimensionVariables.Values.Clone();
            comboBox25.DataSource = DownModuleUpPanelDimensionVariables.PlankhValues.Clone();

            comboBox23.SelectedItem = DownModuleUpPanelDimensionVariables.MinWidth;
            comboBox24.SelectedItem = DownModuleUpPanelDimensionVariables.MinDepth;
            comboBox25.SelectedItem = DownModuleUpPanelDimensionVariables.PlankWidth;

            //Mount
            comboBox26.DataSource = DownModuleMountDimensionVariables.Values.Clone();
            comboBox27.DataSource = DownModuleMountDimensionVariables.DepthValues.Clone();
            comboBox28.DataSource = DownModuleMountDimensionVariables.PlankhValues.Clone();

            comboBox26.SelectedItem = DownModuleMountDimensionVariables.MinPlankMount;
            comboBox27.SelectedItem = DownModuleMountDimensionVariables.ModuleDepth;
            comboBox28.SelectedItem = DownModuleMountDimensionVariables.MaxPlankMount;

            //Cap
            comboBox29.DataSource = DownModuleCapDimensionVariables.Values.Clone();
            comboBox30.DataSource = DownModuleCapDimensionVariables.Values.Clone();

            comboBox29.SelectedItem = DownModuleCapDimensionVariables.UpPedestal;
            comboBox30.SelectedItem = DownModuleCapDimensionVariables.SidePedestal;
        }

        private void simpleValueChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;

            var activaTab = tabControl1.SelectedTab;
            var variableType = (string)activaTab.Tag;
            var variableName = (string)((ComboBox)sender).Tag;
            var value = (int)((ComboBox)sender).SelectedValue;

            switch (variableType)
            {
                case "DownModuleFacadesDimensionVariables":
                    DownModuleFacadesDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleShelfsDimensionVariables":
                    DownModuleShelfsDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleBackwallDimensionVariables":
                    DownModuleBackwallDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleBoxDimensionVariables":
                    DownModuleBoxDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleSideDimensionVariables":
                    DownModuleSideDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleUpPanelDimensionVariables":
                    DownModuleUpPanelDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleMountDimensionVariables":
                    DownModuleMountDimensionVariables.SetValue(variableName, value);
                    break;
                case "DownModuleCapDimensionVariables":
                    DownModuleCapDimensionVariables.SetValue(variableName, value);
                    break;
                default:
                    throw new Exception("Не выбран тип переменной");
            }

        }

    }
}
