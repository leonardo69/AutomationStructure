namespace Automation.View
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblProductName = new Telerik.WinControls.UI.RadLabel();
            this.lblCopyright = new Telerik.WinControls.UI.RadLabel();
            this.lblDevelopers = new Telerik.WinControls.UI.RadLabel();
            this.lblVersion = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDevelopers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblCopyright, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.lblDevelopers, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblVersion, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(617, 163);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 4);
            this.logoPictureBox.Size = new System.Drawing.Size(197, 157);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = false;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.lblProductName.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProductName.Location = new System.Drawing.Point(209, 64);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblProductName.Name = "lblProductName";
            // 
            // 
            // 
            this.lblProductName.RootElement.MaxSize = new System.Drawing.Size(0, 17);
            this.lblProductName.Size = new System.Drawing.Size(405, 17);
            this.lblProductName.TabIndex = 19;
            this.lblProductName.Text = "Category Name";
            this.lblProductName.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = false;
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCopyright.Location = new System.Drawing.Point(209, 145);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblCopyright.Name = "lblCopyright";
            // 
            // 
            // 
            this.lblCopyright.RootElement.MaxSize = new System.Drawing.Size(0, 17);
            this.lblCopyright.Size = new System.Drawing.Size(405, 17);
            this.lblCopyright.TabIndex = 21;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDevelopers
            // 
            this.lblDevelopers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDevelopers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDevelopers.Location = new System.Drawing.Point(209, 127);
            this.lblDevelopers.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblDevelopers.MaximumSize = new System.Drawing.Size(0, 35);
            this.lblDevelopers.Name = "lblDevelopers";
            // 
            // 
            // 
            this.lblDevelopers.RootElement.MaxSize = new System.Drawing.Size(0, 35);
            this.lblDevelopers.ShowItemToolTips = false;
            this.lblDevelopers.Size = new System.Drawing.Size(405, 18);
            this.lblDevelopers.TabIndex = 22;
            this.lblDevelopers.Text = "Developers";
            this.lblDevelopers.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.Location = new System.Drawing.Point(570, 81);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.lblVersion.Name = "lblVersion";
            // 
            // 
            // 
            this.lblVersion.RootElement.MaxSize = new System.Drawing.Size(0, 17);
            this.lblVersion.Size = new System.Drawing.Size(44, 17);
            this.lblVersion.TabIndex = 23;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 163);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.About_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDevelopers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private Telerik.WinControls.UI.RadLabel lblProductName;
        private Telerik.WinControls.UI.RadLabel lblCopyright;
        private Telerik.WinControls.UI.RadLabel lblDevelopers;
        private Telerik.WinControls.UI.RadLabel lblVersion;
    }
}