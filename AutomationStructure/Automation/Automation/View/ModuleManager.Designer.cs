namespace Automation.View
{
    partial class ModuleManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.allModulesInformationDgv = new Telerik.WinControls.UI.RadGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteFacadeBtn = new Telerik.WinControls.UI.RadButton();
            this.AddFacadeBtn = new Telerik.WinControls.UI.RadButton();
            this.selectedModuleInformationDgv = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.modulesLbx = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFacadeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddFacadeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.allModulesInformationDgv);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 338);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация обо всех модулях";
            // 
            // allModulesInformationDgv
            // 
            this.allModulesInformationDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allModulesInformationDgv.Location = new System.Drawing.Point(3, 18);
            // 
            // 
            // 
            this.allModulesInformationDgv.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.allModulesInformationDgv.Name = "allModulesInformationDgv";
            this.allModulesInformationDgv.ReadOnly = true;
            this.allModulesInformationDgv.Size = new System.Drawing.Size(710, 317);
            this.allModulesInformationDgv.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeleteFacadeBtn);
            this.groupBox3.Controls.Add(this.AddFacadeBtn);
            this.groupBox3.Controls.Add(this.selectedModuleInformationDgv);
            this.groupBox3.Controls.Add(this.radButton1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(815, 199);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка выбранного модуля";
            // 
            // DeleteFacadeBtn
            // 
            this.DeleteFacadeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteFacadeBtn.Location = new System.Drawing.Point(719, 96);
            this.DeleteFacadeBtn.Name = "DeleteFacadeBtn";
            this.DeleteFacadeBtn.Size = new System.Drawing.Size(90, 29);
            this.DeleteFacadeBtn.TabIndex = 4;
            this.DeleteFacadeBtn.Text = "Удалить фасад";
            this.DeleteFacadeBtn.Click += new System.EventHandler(this.DeleteFacadeBtn_Click);
            // 
            // AddFacadeBtn
            // 
            this.AddFacadeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFacadeBtn.Location = new System.Drawing.Point(719, 61);
            this.AddFacadeBtn.Name = "AddFacadeBtn";
            this.AddFacadeBtn.Size = new System.Drawing.Size(90, 29);
            this.AddFacadeBtn.TabIndex = 3;
            this.AddFacadeBtn.Text = "Добавить фасад";
            this.AddFacadeBtn.Click += new System.EventHandler(this.AddFacadeBtn_Click);
            // 
            // selectedModuleInformationDgv
            // 
            this.selectedModuleInformationDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedModuleInformationDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.selectedModuleInformationDgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectedModuleInformationDgv.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.selectedModuleInformationDgv.ForeColor = System.Drawing.Color.Black;
            this.selectedModuleInformationDgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectedModuleInformationDgv.Location = new System.Drawing.Point(3, 21);
            // 
            // 
            // 
            this.selectedModuleInformationDgv.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.selectedModuleInformationDgv.Name = "selectedModuleInformationDgv";
            this.selectedModuleInformationDgv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectedModuleInformationDgv.Size = new System.Drawing.Size(710, 172);
            this.selectedModuleInformationDgv.TabIndex = 3;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Location = new System.Drawing.Point(719, 26);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(90, 29);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Обновить";
            this.radButton1.Click += new System.EventHandler(this.UpdateModuleInfoBtn);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radButton4);
            this.groupBox1.Controls.Add(this.radButton3);
            this.groupBox1.Controls.Add(this.radButton2);
            this.groupBox1.Controls.Add(this.modulesLbx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(719, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 317);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список модулей";
            // 
            // radButton4
            // 
            this.radButton4.Location = new System.Drawing.Point(6, 128);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(75, 34);
            this.radButton4.TabIndex = 3;
            this.radButton4.Text = "Удалить";
            this.radButton4.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(6, 82);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(75, 35);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "Добавить предыдущий";
            this.radButton3.TextWrap = true;
            this.radButton3.Click += new System.EventHandler(this.addSimilarBtn_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(6, 35);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(75, 35);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Добавить";
            this.radButton2.Click += new System.EventHandler(this.add_Click);
            // 
            // modulesLbx
            // 
            this.modulesLbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.modulesLbx.FormattingEnabled = true;
            this.modulesLbx.Location = new System.Drawing.Point(8, 168);
            this.modulesLbx.Name = "modulesLbx";
            this.modulesLbx.Size = new System.Drawing.Size(75, 147);
            this.modulesLbx.TabIndex = 0;
            this.modulesLbx.SelectedIndexChanged += new System.EventHandler(this.modulesLbx_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 549);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // ModuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(829, 529);
            this.Name = "ModuleManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка модулей ";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allModulesInformationDgv)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFacadeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddFacadeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedModuleInformationDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadButton DeleteFacadeBtn;
        private Telerik.WinControls.UI.RadButton AddFacadeBtn;
        private Telerik.WinControls.UI.RadGridView selectedModuleInformationDgv;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.Windows.Forms.ListBox modulesLbx;
        private Telerik.WinControls.UI.RadGridView allModulesInformationDgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}