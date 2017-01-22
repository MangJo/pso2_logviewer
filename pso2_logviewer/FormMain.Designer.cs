namespace pso2_logviewer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageChat = new System.Windows.Forms.TabPage();
            this.grpBox_Contents = new System.Windows.Forms.GroupBox();
            this.comBox_ColNames = new System.Windows.Forms.ComboBox();
            this.txtBox_ContentsFilter = new System.Windows.Forms.TextBox();
            this.cb_Chat = new System.Windows.Forms.CheckBox();
            this.cb_PCName = new System.Windows.Forms.CheckBox();
            this.cb_playerID = new System.Windows.Forms.CheckBox();
            this.cb_chatType = new System.Windows.Forms.CheckBox();
            this.cb_lineNo = new System.Windows.Forms.CheckBox();
            this.cb_Date = new System.Windows.Forms.CheckBox();
            this.dgv_logContents = new System.Windows.Forms.DataGridView();
            this.grpBox_txtFileList = new System.Windows.Forms.GroupBox();
            this.dgv_textList = new System.Windows.Forms.DataGridView();
            this.txtBox_TxtFileListFilter = new System.Windows.Forms.TextBox();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.labelCurrentFolder = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_totalFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.link_About = new System.Windows.Forms.LinkLabel();
            this.img_About = new System.Windows.Forms.PictureBox();
            this.tss_stopwatch = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPageChat.SuspendLayout();
            this.grpBox_Contents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logContents)).BeginInit();
            this.grpBox_txtFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_textList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_About)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageChat);
            this.tabControl1.Location = new System.Drawing.Point(12, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(987, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageChat
            // 
            this.tabPageChat.Controls.Add(this.grpBox_Contents);
            this.tabPageChat.Controls.Add(this.grpBox_txtFileList);
            this.tabPageChat.Location = new System.Drawing.Point(4, 22);
            this.tabPageChat.Name = "tabPageChat";
            this.tabPageChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChat.Size = new System.Drawing.Size(979, 408);
            this.tabPageChat.TabIndex = 0;
            this.tabPageChat.Text = "Chat Log";
            this.tabPageChat.UseVisualStyleBackColor = true;
            // 
            // grpBox_Contents
            // 
            this.grpBox_Contents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox_Contents.Controls.Add(this.comBox_ColNames);
            this.grpBox_Contents.Controls.Add(this.txtBox_ContentsFilter);
            this.grpBox_Contents.Controls.Add(this.cb_Chat);
            this.grpBox_Contents.Controls.Add(this.cb_PCName);
            this.grpBox_Contents.Controls.Add(this.cb_playerID);
            this.grpBox_Contents.Controls.Add(this.cb_chatType);
            this.grpBox_Contents.Controls.Add(this.cb_lineNo);
            this.grpBox_Contents.Controls.Add(this.cb_Date);
            this.grpBox_Contents.Controls.Add(this.dgv_logContents);
            this.grpBox_Contents.Location = new System.Drawing.Point(195, 6);
            this.grpBox_Contents.Name = "grpBox_Contents";
            this.grpBox_Contents.Size = new System.Drawing.Size(778, 396);
            this.grpBox_Contents.TabIndex = 1;
            this.grpBox_Contents.TabStop = false;
            this.grpBox_Contents.Text = "Contents";
            // 
            // comBox_ColNames
            // 
            this.comBox_ColNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comBox_ColNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_ColNames.FormattingEnabled = true;
            this.comBox_ColNames.Location = new System.Drawing.Point(632, 17);
            this.comBox_ColNames.Name = "comBox_ColNames";
            this.comBox_ColNames.Size = new System.Drawing.Size(140, 21);
            this.comBox_ColNames.TabIndex = 8;
            // 
            // txtBox_ContentsFilter
            // 
            this.txtBox_ContentsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_ContentsFilter.Location = new System.Drawing.Point(405, 17);
            this.txtBox_ContentsFilter.MaxLength = 100;
            this.txtBox_ContentsFilter.Name = "txtBox_ContentsFilter";
            this.txtBox_ContentsFilter.Size = new System.Drawing.Size(221, 20);
            this.txtBox_ContentsFilter.TabIndex = 7;
            this.txtBox_ContentsFilter.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtBox_ContentsFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // cb_Chat
            // 
            this.cb_Chat.AutoSize = true;
            this.cb_Chat.Checked = true;
            this.cb_Chat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Chat.Location = new System.Drawing.Point(350, 17);
            this.cb_Chat.Name = "cb_Chat";
            this.cb_Chat.Size = new System.Drawing.Size(48, 17);
            this.cb_Chat.TabIndex = 6;
            this.cb_Chat.Text = "Chat";
            this.cb_Chat.UseVisualStyleBackColor = true;
            this.cb_Chat.CheckedChanged += new System.EventHandler(this.cb_Chat_CheckedChanged);
            // 
            // cb_PCName
            // 
            this.cb_PCName.AutoSize = true;
            this.cb_PCName.Checked = true;
            this.cb_PCName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PCName.Location = new System.Drawing.Point(290, 17);
            this.cb_PCName.Name = "cb_PCName";
            this.cb_PCName.Size = new System.Drawing.Size(54, 17);
            this.cb_PCName.TabIndex = 5;
            this.cb_PCName.Text = "Name";
            this.cb_PCName.UseVisualStyleBackColor = true;
            this.cb_PCName.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // cb_playerID
            // 
            this.cb_playerID.AutoSize = true;
            this.cb_playerID.Checked = true;
            this.cb_playerID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_playerID.Location = new System.Drawing.Point(215, 17);
            this.cb_playerID.Name = "cb_playerID";
            this.cb_playerID.Size = new System.Drawing.Size(69, 17);
            this.cb_playerID.TabIndex = 4;
            this.cb_playerID.Text = "Player ID";
            this.cb_playerID.UseVisualStyleBackColor = true;
            this.cb_playerID.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // cb_chatType
            // 
            this.cb_chatType.AutoSize = true;
            this.cb_chatType.Checked = true;
            this.cb_chatType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_chatType.Location = new System.Drawing.Point(134, 17);
            this.cb_chatType.Name = "cb_chatType";
            this.cb_chatType.Size = new System.Drawing.Size(75, 17);
            this.cb_chatType.TabIndex = 3;
            this.cb_chatType.Text = "Chat Type";
            this.cb_chatType.UseVisualStyleBackColor = true;
            this.cb_chatType.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // cb_lineNo
            // 
            this.cb_lineNo.AutoSize = true;
            this.cb_lineNo.Checked = true;
            this.cb_lineNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lineNo.Location = new System.Drawing.Point(62, 17);
            this.cb_lineNo.Name = "cb_lineNo";
            this.cb_lineNo.Size = new System.Drawing.Size(66, 17);
            this.cb_lineNo.TabIndex = 2;
            this.cb_lineNo.Text = "Line No.";
            this.cb_lineNo.UseVisualStyleBackColor = true;
            this.cb_lineNo.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cb_Date
            // 
            this.cb_Date.AutoSize = true;
            this.cb_Date.Checked = true;
            this.cb_Date.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Date.Location = new System.Drawing.Point(7, 17);
            this.cb_Date.Name = "cb_Date";
            this.cb_Date.Size = new System.Drawing.Size(49, 17);
            this.cb_Date.TabIndex = 1;
            this.cb_Date.Text = "Date";
            this.cb_Date.UseVisualStyleBackColor = true;
            this.cb_Date.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dgv_logContents
            // 
            this.dgv_logContents.AllowUserToAddRows = false;
            this.dgv_logContents.AllowUserToDeleteRows = false;
            this.dgv_logContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_logContents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_logContents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_logContents.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_logContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_logContents.GridColor = System.Drawing.Color.Black;
            this.dgv_logContents.Location = new System.Drawing.Point(7, 47);
            this.dgv_logContents.Name = "dgv_logContents";
            this.dgv_logContents.ReadOnly = true;
            this.dgv_logContents.RowHeadersVisible = false;
            this.dgv_logContents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_logContents.Size = new System.Drawing.Size(765, 342);
            this.dgv_logContents.TabIndex = 0;
            this.dgv_logContents.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            // 
            // grpBox_txtFileList
            // 
            this.grpBox_txtFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBox_txtFileList.Controls.Add(this.dgv_textList);
            this.grpBox_txtFileList.Controls.Add(this.txtBox_TxtFileListFilter);
            this.grpBox_txtFileList.Location = new System.Drawing.Point(6, 6);
            this.grpBox_txtFileList.Name = "grpBox_txtFileList";
            this.grpBox_txtFileList.Size = new System.Drawing.Size(183, 396);
            this.grpBox_txtFileList.TabIndex = 0;
            this.grpBox_txtFileList.TabStop = false;
            this.grpBox_txtFileList.Text = "Text Files List";
            // 
            // dgv_textList
            // 
            this.dgv_textList.AllowUserToAddRows = false;
            this.dgv_textList.AllowUserToDeleteRows = false;
            this.dgv_textList.AllowUserToResizeColumns = false;
            this.dgv_textList.AllowUserToResizeRows = false;
            this.dgv_textList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_textList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_textList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_textList.Location = new System.Drawing.Point(7, 47);
            this.dgv_textList.MultiSelect = false;
            this.dgv_textList.Name = "dgv_textList";
            this.dgv_textList.ReadOnly = true;
            this.dgv_textList.RowHeadersVisible = false;
            this.dgv_textList.Size = new System.Drawing.Size(166, 342);
            this.dgv_textList.TabIndex = 3;
            this.dgv_textList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtBox_TxtFileListFilter
            // 
            this.txtBox_TxtFileListFilter.Location = new System.Drawing.Point(7, 20);
            this.txtBox_TxtFileListFilter.MaxLength = 32;
            this.txtBox_TxtFileListFilter.Name = "txtBox_TxtFileListFilter";
            this.txtBox_TxtFileListFilter.Size = new System.Drawing.Size(166, 20);
            this.txtBox_TxtFileListFilter.TabIndex = 0;
            this.txtBox_TxtFileListFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Location = new System.Drawing.Point(12, 12);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(96, 23);
            this.btnChangeFolder.TabIndex = 1;
            this.btnChangeFolder.Text = "&Change Folder";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // labelCurrentFolder
            // 
            this.labelCurrentFolder.AutoSize = true;
            this.labelCurrentFolder.Location = new System.Drawing.Point(114, 17);
            this.labelCurrentFolder.Name = "labelCurrentFolder";
            this.labelCurrentFolder.Size = new System.Drawing.Size(109, 13);
            this.labelCurrentFolder.TabIndex = 2;
            this.labelCurrentFolder.Text = "CURRENT FOLDER:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_totalFiles,
            this.tss_stopwatch});
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_totalFiles
            // 
            this.tss_totalFiles.Name = "tss_totalFiles";
            this.tss_totalFiles.Size = new System.Drawing.Size(152, 17);
            this.tss_totalFiles.Text = "Please locate the log folder.";
            // 
            // link_About
            // 
            this.link_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_About.AutoSize = true;
            this.link_About.Location = new System.Drawing.Point(948, 45);
            this.link_About.Name = "link_About";
            this.link_About.Size = new System.Drawing.Size(44, 13);
            this.link_About.TabIndex = 4;
            this.link_About.TabStop = true;
            this.link_About.Text = "ABOUT";
            this.link_About.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_About_LinkClicked);
            // 
            // img_About
            // 
            this.img_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_About.BackColor = System.Drawing.Color.Transparent;
            this.img_About.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_About.Image = global::pso2_logviewer.Properties.Resources.pso2_chat_img;
            this.img_About.Location = new System.Drawing.Point(945, 7);
            this.img_About.Name = "img_About";
            this.img_About.Size = new System.Drawing.Size(48, 48);
            this.img_About.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_About.TabIndex = 5;
            this.img_About.TabStop = false;
            this.img_About.Click += new System.EventHandler(this.img_About_Click);
            // 
            // tss_stopwatch
            // 
            this.tss_stopwatch.Name = "tss_stopwatch";
            this.tss_stopwatch.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 521);
            this.Controls.Add(this.link_About);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelCurrentFolder);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.img_About);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 480);
            this.Name = "FormMain";
            this.Text = "PSO2 Log Viewer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageChat.ResumeLayout(false);
            this.grpBox_Contents.ResumeLayout(false);
            this.grpBox_Contents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logContents)).EndInit();
            this.grpBox_txtFileList.ResumeLayout(false);
            this.grpBox_txtFileList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_textList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_About)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageChat;
        private System.Windows.Forms.GroupBox grpBox_Contents;
        private System.Windows.Forms.GroupBox grpBox_txtFileList;
        private System.Windows.Forms.TextBox txtBox_TxtFileListFilter;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.Label labelCurrentFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tss_totalFiles;
        private System.Windows.Forms.DataGridView dgv_textList;
        private System.Windows.Forms.DataGridView dgv_logContents;
        private System.Windows.Forms.CheckBox cb_Chat;
        private System.Windows.Forms.CheckBox cb_PCName;
        private System.Windows.Forms.CheckBox cb_playerID;
        private System.Windows.Forms.CheckBox cb_chatType;
        private System.Windows.Forms.CheckBox cb_lineNo;
        private System.Windows.Forms.CheckBox cb_Date;
        private System.Windows.Forms.TextBox txtBox_ContentsFilter;
        private System.Windows.Forms.ComboBox comBox_ColNames;
        private System.Windows.Forms.LinkLabel link_About;
        private System.Windows.Forms.PictureBox img_About;
        private System.Windows.Forms.ToolStripStatusLabel tss_stopwatch;
    }
}

