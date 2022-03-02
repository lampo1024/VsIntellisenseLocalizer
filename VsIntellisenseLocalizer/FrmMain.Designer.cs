namespace VsIntellisenseLocalizer
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.btnSelectDownloadFolder = new System.Windows.Forms.Button();
            this.lboxVersions = new System.Windows.Forms.ListBox();
            this.lvIntelliSenseFiles = new System.Windows.Forms.ListView();
            this.lang = new System.Windows.Forms.ColumnHeader();
            this.packageUrl = new System.Windows.Forms.ColumnHeader();
            this.btnInstallLocalizePackage = new System.Windows.Forms.Button();
            this.lbAvailableNetVersion = new System.Windows.Forms.Label();
            this.lbInstalledNetVersion = new System.Windows.Forms.Label();
            this.lboxInstalledVersions = new System.Windows.Forms.ListBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLeft});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLeft
            // 
            this.statusLeft.Name = "statusLeft";
            this.statusLeft.Size = new System.Drawing.Size(46, 17);
            this.statusLeft.Text = "已就绪";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(12, 28);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(550, 23);
            this.txtDownloadFolder.TabIndex = 2;
            // 
            // btnSelectDownloadFolder
            // 
            this.btnSelectDownloadFolder.Location = new System.Drawing.Point(566, 28);
            this.btnSelectDownloadFolder.Name = "btnSelectDownloadFolder";
            this.btnSelectDownloadFolder.Size = new System.Drawing.Size(75, 24);
            this.btnSelectDownloadFolder.TabIndex = 3;
            this.btnSelectDownloadFolder.Text = "选择目录";
            this.btnSelectDownloadFolder.UseVisualStyleBackColor = true;
            this.btnSelectDownloadFolder.Click += new System.EventHandler(this.btnSelectDownloadFolder_Click);
            // 
            // lboxVersions
            // 
            this.lboxVersions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxVersions.FormattingEnabled = true;
            this.lboxVersions.ItemHeight = 17;
            this.lboxVersions.Location = new System.Drawing.Point(11, 16);
            this.lboxVersions.Name = "lboxVersions";
            this.lboxVersions.Size = new System.Drawing.Size(146, 123);
            this.lboxVersions.TabIndex = 4;
            this.lboxVersions.SelectedValueChanged += new System.EventHandler(this.lboxVersions_SelectedValueChanged);
            // 
            // lvIntelliSenseFiles
            // 
            this.lvIntelliSenseFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lang,
            this.packageUrl});
            this.lvIntelliSenseFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvIntelliSenseFiles.FullRowSelect = true;
            this.lvIntelliSenseFiles.GridLines = true;
            this.lvIntelliSenseFiles.Location = new System.Drawing.Point(0, 0);
            this.lvIntelliSenseFiles.MultiSelect = false;
            this.lvIntelliSenseFiles.Name = "lvIntelliSenseFiles";
            this.lvIntelliSenseFiles.ShowGroups = false;
            this.lvIntelliSenseFiles.ShowItemToolTips = true;
            this.lvIntelliSenseFiles.Size = new System.Drawing.Size(466, 370);
            this.lvIntelliSenseFiles.TabIndex = 5;
            this.lvIntelliSenseFiles.UseCompatibleStateImageBehavior = false;
            this.lvIntelliSenseFiles.View = System.Windows.Forms.View.Details;
            this.lvIntelliSenseFiles.SelectedIndexChanged += new System.EventHandler(this.lvIntelliSenseFiles_SelectedIndexChanged);
            // 
            // lang
            // 
            this.lang.Text = "语言";
            this.lang.Width = 80;
            // 
            // packageUrl
            // 
            this.packageUrl.Text = "包地址";
            this.packageUrl.Width = 200;
            // 
            // btnInstallLocalizePackage
            // 
            this.btnInstallLocalizePackage.Location = new System.Drawing.Point(10, 328);
            this.btnInstallLocalizePackage.Name = "btnInstallLocalizePackage";
            this.btnInstallLocalizePackage.Size = new System.Drawing.Size(147, 43);
            this.btnInstallLocalizePackage.TabIndex = 6;
            this.btnInstallLocalizePackage.Text = "安装语言包";
            this.btnInstallLocalizePackage.UseVisualStyleBackColor = true;
            this.btnInstallLocalizePackage.Click += new System.EventHandler(this.btnInstallLocalizePackage_Click);
            // 
            // lbAvailableNetVersion
            // 
            this.lbAvailableNetVersion.AutoSize = true;
            this.lbAvailableNetVersion.Location = new System.Drawing.Point(8, 0);
            this.lbAvailableNetVersion.Name = "lbAvailableNetVersion";
            this.lbAvailableNetVersion.Size = new System.Drawing.Size(135, 15);
            this.lbAvailableNetVersion.TabIndex = 8;
            this.lbAvailableNetVersion.Text = "可用的.NET语言包版本";
            // 
            // lbInstalledNetVersion
            // 
            this.lbInstalledNetVersion.AutoSize = true;
            this.lbInstalledNetVersion.Location = new System.Drawing.Point(8, 157);
            this.lbInstalledNetVersion.Name = "lbInstalledNetVersion";
            this.lbInstalledNetVersion.Size = new System.Drawing.Size(135, 15);
            this.lbInstalledNetVersion.TabIndex = 9;
            this.lbInstalledNetVersion.Text = "需要本地化的.NET版本";
            // 
            // lboxInstalledVersions
            // 
            this.lboxInstalledVersions.Enabled = false;
            this.lboxInstalledVersions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lboxInstalledVersions.FormattingEnabled = true;
            this.lboxInstalledVersions.ItemHeight = 17;
            this.lboxInstalledVersions.Location = new System.Drawing.Point(11, 172);
            this.lboxInstalledVersions.Name = "lboxInstalledVersions";
            this.lboxInstalledVersions.Size = new System.Drawing.Size(146, 140);
            this.lboxInstalledVersions.TabIndex = 10;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSidebar.Controls.Add(this.lbAvailableNetVersion);
            this.panelSidebar.Controls.Add(this.lboxInstalledVersions);
            this.panelSidebar.Controls.Add(this.lboxVersions);
            this.panelSidebar.Controls.Add(this.lbInstalledNetVersion);
            this.panelSidebar.Controls.Add(this.btnInstallLocalizePackage);
            this.panelSidebar.Location = new System.Drawing.Point(0, 57);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(165, 371);
            this.panelSidebar.TabIndex = 11;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.lvIntelliSenseFiles);
            this.panelRight.Location = new System.Drawing.Point(175, 58);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(466, 370);
            this.panelRight.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 453);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.btnSelectDownloadFolder);
            this.Controls.Add(this.txtDownloadFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Visual Studio Intellisense Localizer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private TextBox txtDownloadFolder;
        private Button btnSelectDownloadFolder;
        private ListBox lboxVersions;
        private ListView lvIntelliSenseFiles;
        private ColumnHeader lang;
        private ColumnHeader packageUrl;
        private Button btnInstallLocalizePackage;
        private Label lbAvailableNetVersion;
        private Label lbInstalledNetVersion;
        private ToolStripStatusLabel statusLeft;
        private ListBox lboxInstalledVersions;
        private Panel panelSidebar;
        private Panel panelRight;
    }
}