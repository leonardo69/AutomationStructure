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
    public partial class GeneralGlobalDimensionVariables : Form
    {
        private readonly bool _isLoaded;
        public GeneralGlobalDimensionVariables()
        {
            InitializeComponent();
            LoadValues();
            _isLoaded = true;
        }

        private void LoadValues()
        {
            //Furniture
            comboBox1.DataSource = GeneralFurnitureDimensionVariables.Values.Clone();
            comboBox2.DataSource = GeneralFurnitureDimensionVariables.Values.Clone();
            comboBox3.DataSource = GeneralFurnitureDimensionVariables.Values.Clone();
            comboBox4.DataSource = GeneralFurnitureDimensionVariables.Values.Clone();

            comboBox1.SelectedItem = GeneralFurnitureDimensionVariables.ExtraKant;
            comboBox2.SelectedItem = GeneralFurnitureDimensionVariables.HingeCount;
            comboBox3.SelectedItem = GeneralFurnitureDimensionVariables.ShelfHolderCount;
            comboBox4.SelectedItem = GeneralFurnitureDimensionVariables.ShelfSkrewCount;

            //Cut
            comboBox5.DataSource = GeneralCutDimensionVariables.Values.Clone();
            comboBox6.DataSource = GeneralCutDimensionVariables.WidthValues.Clone();
            comboBox7.DataSource = GeneralCutDimensionVariables.GrooveValues.Clone();
            comboBox8.DataSource = GeneralCutDimensionVariables.UpmValues.Clone();
            comboBox9.DataSource = GeneralCutDimensionVariables.CutUpValues.Clone();
            comboBox10.DataSource = GeneralCutDimensionVariables.CutSideValues.Clone();

            comboBox5.SelectedItem = GeneralCutDimensionVariables.BackPanelGrooveDepth;
            comboBox6.SelectedItem = GeneralCutDimensionVariables.BackPanelGrooveWidth;
            comboBox7.SelectedItem = GeneralCutDimensionVariables.BackPanelGrooveEdgeIndent;
            comboBox8.SelectedItem = GeneralCutDimensionVariables.SlotSpaceUpmBackSlot;
            comboBox9.SelectedItem = GeneralCutDimensionVariables.HolderCutUp;
            comboBox10.SelectedItem = GeneralCutDimensionVariables.HolderCutSide;

            //Material
            comboBox11.DataSource = GeneralMaterialDimensionVariables.SawValues.Clone();
            comboBox12.DataSource = GeneralMaterialDimensionVariables.CutValues.Clone();
            comboBox13.DataSource = GeneralMaterialDimensionVariables.CutLeavingValues.Clone();

            comboBox11.SelectedItem = GeneralMaterialDimensionVariables.SawThick;
            comboBox12.SelectedItem = GeneralMaterialDimensionVariables.DspCut;
            comboBox13.SelectedItem = GeneralMaterialDimensionVariables.DspCutLeavingsDspCut;

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
                case "GeneralFurnitureDimensionVariables":
                    GeneralFurnitureDimensionVariables.SetValue(variableName, value);
                    break;
                case "GeneralCutDimensionVariables":
                    GeneralCutDimensionVariables.SetValue(variableName, value);
                    break;
                case "GeneralMaterialDimensionVariables":
                    GeneralMaterialDimensionVariables.SetValue(variableName, value);
                    break;
                default:
                    throw new Exception("Не выбран тип переменной");
            }

        }
    }
}
