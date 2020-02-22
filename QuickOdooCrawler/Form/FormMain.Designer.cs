namespace QuickOdooCrawler
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelWebBrowser = new System.Windows.Forms.Panel();
            this.richTextBoxInfoSearchMulti = new System.Windows.Forms.RichTextBox();
            this.richTextBoxInfoResultMulti = new System.Windows.Forms.RichTextBox();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRestart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.comboBoxInfoSearch = new System.Windows.Forms.ComboBox();
            this.checkBoxInfoAutoResetText = new System.Windows.Forms.CheckBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelInfoNote = new System.Windows.Forms.Label();
            this.toolStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWebBrowser
            // 
            this.panelWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWebBrowser.Location = new System.Drawing.Point(0, 488);
            this.panelWebBrowser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelWebBrowser.Name = "panelWebBrowser";
            this.panelWebBrowser.Size = new System.Drawing.Size(1068, 2);
            this.panelWebBrowser.TabIndex = 5;
            // 
            // richTextBoxInfoSearchMulti
            // 
            this.richTextBoxInfoSearchMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInfoSearchMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxInfoSearchMulti.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.richTextBoxInfoSearchMulti.HideSelection = false;
            this.richTextBoxInfoSearchMulti.Location = new System.Drawing.Point(4, 36);
            this.richTextBoxInfoSearchMulti.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBoxInfoSearchMulti.Name = "richTextBoxInfoSearchMulti";
            this.richTextBoxInfoSearchMulti.Size = new System.Drawing.Size(1056, 136);
            this.richTextBoxInfoSearchMulti.TabIndex = 0;
            this.richTextBoxInfoSearchMulti.Text = "";
            this.richTextBoxInfoSearchMulti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxInfoSearchMulti_KeyDown);
            // 
            // richTextBoxInfoResultMulti
            // 
            this.richTextBoxInfoResultMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInfoResultMulti.BackColor = System.Drawing.Color.White;
            this.richTextBoxInfoResultMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxInfoResultMulti.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.richTextBoxInfoResultMulti.HideSelection = false;
            this.richTextBoxInfoResultMulti.Location = new System.Drawing.Point(4, 200);
            this.richTextBoxInfoResultMulti.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBoxInfoResultMulti.Name = "richTextBoxInfoResultMulti";
            this.richTextBoxInfoResultMulti.ReadOnly = true;
            this.richTextBoxInfoResultMulti.Size = new System.Drawing.Size(1056, 238);
            this.richTextBoxInfoResultMulti.TabIndex = 1;
            this.richTextBoxInfoResultMulti.TabStop = false;
            this.richTextBoxInfoResultMulti.Text = "";
            this.richTextBoxInfoResultMulti.WordWrap = false;
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonEndTask,
            this.toolStripSeparator3,
            this.toolStripButtonNew,
            this.toolStripSeparator4,
            this.toolStripButtonRestart,
            this.toolStripSeparator2,
            this.toolStripLabelSetting,
            this.toolStripSeparator1,
            this.toolStripButtonHelp});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1072, 27);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonStart.Text = "开爬";
            this.toolStripButtonStart.Click += new System.EventHandler(this.buttonInfoSearchMulti_Click);
            // 
            // toolStripButtonEndTask
            // 
            this.toolStripButtonEndTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEndTask.Image")));
            this.toolStripButtonEndTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndTask.Name = "toolStripButtonEndTask";
            this.toolStripButtonEndTask.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonEndTask.Text = "中断";
            this.toolStripButtonEndTask.Visible = false;
            this.toolStripButtonEndTask.Click += new System.EventHandler(this.toolStripButtonEndTask_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonNew.Text = "新建";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButtonRestart
            // 
            this.toolStripButtonRestart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestart.Image")));
            this.toolStripButtonRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestart.Name = "toolStripButtonRestart";
            this.toolStripButtonRestart.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonRestart.Text = "重启";
            this.toolStripButtonRestart.Click += new System.EventHandler(this.toolStripButtonRestart_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabelSetting
            // 
            this.toolStripLabelSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabelSetting.Image")));
            this.toolStripLabelSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabelSetting.Name = "toolStripLabelSetting";
            this.toolStripLabelSetting.Size = new System.Drawing.Size(57, 24);
            this.toolStripLabelSetting.Text = "配置";
            this.toolStripLabelSetting.Click += new System.EventHandler(this.toolStripLabelSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHelp.Image")));
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonHelp.Text = "帮助";
            // 
            // comboBoxInfoSearch
            // 
            this.comboBoxInfoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInfoSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInfoSearch.FormattingEnabled = true;
            this.comboBoxInfoSearch.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxInfoSearch.ItemHeight = 13;
            this.comboBoxInfoSearch.Location = new System.Drawing.Point(4, 9);
            this.comboBoxInfoSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxInfoSearch.Name = "comboBoxInfoSearch";
            this.comboBoxInfoSearch.Size = new System.Drawing.Size(957, 21);
            this.comboBoxInfoSearch.TabIndex = 0;
            this.comboBoxInfoSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxInfo_SelectedIndexChanged);
            // 
            // checkBoxInfoAutoResetText
            // 
            this.checkBoxInfoAutoResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxInfoAutoResetText.AutoSize = true;
            this.checkBoxInfoAutoResetText.Checked = true;
            this.checkBoxInfoAutoResetText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInfoAutoResetText.Location = new System.Drawing.Point(970, 10);
            this.checkBoxInfoAutoResetText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxInfoAutoResetText.Name = "checkBoxInfoAutoResetText";
            this.checkBoxInfoAutoResetText.Size = new System.Drawing.Size(98, 17);
            this.checkBoxInfoAutoResetText.TabIndex = 6;
            this.checkBoxInfoAutoResetText.Text = "自动重设文本";
            this.checkBoxInfoAutoResetText.UseVisualStyleBackColor = true;
            this.checkBoxInfoAutoResetText.CheckedChanged += new System.EventHandler(this.checkBoxInfoAutoResetText_CheckedChanged);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Location = new System.Drawing.Point(0, 25);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1072, 468);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxInfoResultMulti);
            this.tabPage1.Controls.Add(this.labelInfoNote);
            this.tabPage1.Controls.Add(this.richTextBoxInfoSearchMulti);
            this.tabPage1.Controls.Add(this.checkBoxInfoAutoResetText);
            this.tabPage1.Controls.Add(this.comboBoxInfoSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1064, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "信息获取(模板1)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelInfoNote
            // 
            this.labelInfoNote.AutoSize = true;
            this.labelInfoNote.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfoNote.Location = new System.Drawing.Point(2, 179);
            this.labelInfoNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfoNote.Name = "labelInfoNote";
            this.labelInfoNote.Size = new System.Drawing.Size(221, 12);
            this.labelInfoNote.TabIndex = 7;
            this.labelInfoNote.Text = "说明: 按F1追加搜索标签, 按F3开始查询";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1072, 493);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.panelWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(379, 532);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ODOO爬虫 (请先下拉窗口确定已登入Odoo系统)";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelWebBrowser;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripLabelSetting;
        private System.Windows.Forms.RichTextBox richTextBoxInfoResultMulti;
        private System.Windows.Forms.RichTextBox richTextBoxInfoSearchMulti;
        private System.Windows.Forms.ComboBox comboBoxInfoSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestart;
        private System.Windows.Forms.CheckBox checkBoxInfoAutoResetText;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelInfoNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}