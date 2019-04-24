namespace Automation.View
{
    partial class ModuleConfigurator
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
            this.label1 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.moduleNumberTxb = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.schemeTxb = new Telerik.WinControls.UI.RadTextBox();
            this.subSchemeTxb = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.selectorBtn = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleNumberTxb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemeTxb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subSchemeTxb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер модуля:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radListView1);
            this.radGroupBox1.HeaderText = "Форма модуля";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 122);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(668, 368);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "Форма модуля";
            // 
            // radListView1
            // 
            this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListView1.FullRowSelect = false;
            this.radListView1.ItemSize = new System.Drawing.Size(64, 64);
            this.radListView1.Location = new System.Drawing.Point(2, 18);
            this.radListView1.Name = "radListView1";
            this.radListView1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.radListView1.RootElement.ApplyShapeToControl = false;
            this.radListView1.Size = new System.Drawing.Size(664, 348);
            this.radListView1.TabIndex = 0;
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.IconsView;
            this.radListView1.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemMouseClick);
            this.radListView1.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemMouseDoubleClick);
            // 
            // moduleNumberTxb
            // 
            this.moduleNumberTxb.Location = new System.Drawing.Point(161, 21);
            this.moduleNumberTxb.Name = "moduleNumberTxb";
            this.moduleNumberTxb.Size = new System.Drawing.Size(244, 20);
            this.moduleNumberTxb.TabIndex = 9;
            this.moduleNumberTxb.Text = "1";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(590, 508);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(83, 33);
            this.radButton1.TabIndex = 10;
            this.radButton1.Text = "Применить";
            this.radButton1.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 57);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(85, 18);
            this.radLabel1.TabIndex = 12;
            this.radLabel1.Text = "Форма модуля:";
            // 
            // schemeTxb
            // 
            this.schemeTxb.Location = new System.Drawing.Point(161, 55);
            this.schemeTxb.Name = "schemeTxb";
            this.schemeTxb.Size = new System.Drawing.Size(244, 20);
            this.schemeTxb.TabIndex = 13;
            // 
            // subSchemeTxb
            // 
            this.subSchemeTxb.Location = new System.Drawing.Point(161, 88);
            this.subSchemeTxb.Name = "subSchemeTxb";
            this.subSchemeTxb.ReadOnly = true;
            this.subSchemeTxb.Size = new System.Drawing.Size(244, 20);
            this.subSchemeTxb.TabIndex = 14;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 89);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(129, 18);
            this.radLabel2.TabIndex = 15;
            this.radLabel2.Text = "Подтип формы модуля:";
            // 
            // selectorBtn
            // 
            this.selectorBtn.Location = new System.Drawing.Point(425, 85);
            this.selectorBtn.Name = "selectorBtn";
            this.selectorBtn.Size = new System.Drawing.Size(73, 27);
            this.selectorBtn.TabIndex = 11;
            this.selectorBtn.Text = "Выбрать";
            this.selectorBtn.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // ModuleConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 556);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.subSchemeTxb);
            this.Controls.Add(this.schemeTxb);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.selectorBtn);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.moduleNumberTxb);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleConfigurator";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурирование нового модуля";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleNumberTxb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemeTxb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subSchemeTxb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox moduleNumberTxb;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox schemeTxb;
        private Telerik.WinControls.UI.RadTextBox subSchemeTxb;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton selectorBtn;
    }
}