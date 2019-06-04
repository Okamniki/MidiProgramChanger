namespace MidiProgramChanger
{
    partial class Setting
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageInst = new System.Windows.Forms.TabPage();
            this.DgInst = new System.Windows.Forms.DataGridView();
            this.trackNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channnelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programChangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabPageEnv = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabPageInst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabPageInst);
            this.tabControl1.Controls.Add(this.TabPageEnv);
            this.tabControl1.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 9F);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // TabPageInst
            // 
            this.TabPageInst.Controls.Add(this.DgInst);
            this.TabPageInst.Location = new System.Drawing.Point(4, 24);
            this.TabPageInst.Name = "TabPageInst";
            this.TabPageInst.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageInst.Size = new System.Drawing.Size(453, 417);
            this.TabPageInst.TabIndex = 0;
            this.TabPageInst.Text = "楽器リスト設定";
            this.TabPageInst.UseVisualStyleBackColor = true;
            // 
            // DgInst
            // 
            this.DgInst.AutoGenerateColumns = false;
            this.DgInst.BackgroundColor = System.Drawing.Color.White;
            this.DgInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgInst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trackNameDataGridViewTextBoxColumn,
            this.instrumentNameDataGridViewTextBoxColumn,
            this.channnelDataGridViewTextBoxColumn,
            this.programChangeDataGridViewTextBoxColumn});
            this.DgInst.DataSource = this.instrumentBindingSource;
            this.DgInst.Location = new System.Drawing.Point(3, 4);
            this.DgInst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgInst.Name = "DgInst";
            this.DgInst.RowTemplate.Height = 21;
            this.DgInst.Size = new System.Drawing.Size(447, 409);
            this.DgInst.TabIndex = 2;
            this.DgInst.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgInst_CellContentClick);
            this.DgInst.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgInst_DataError);
            // 
            // trackNameDataGridViewTextBoxColumn
            // 
            this.trackNameDataGridViewTextBoxColumn.DataPropertyName = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.HeaderText = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.Name = "trackNameDataGridViewTextBoxColumn";
            // 
            // instrumentNameDataGridViewTextBoxColumn
            // 
            this.instrumentNameDataGridViewTextBoxColumn.DataPropertyName = "InstrumentName";
            this.instrumentNameDataGridViewTextBoxColumn.HeaderText = "InstrumentName";
            this.instrumentNameDataGridViewTextBoxColumn.Name = "instrumentNameDataGridViewTextBoxColumn";
            // 
            // channnelDataGridViewTextBoxColumn
            // 
            this.channnelDataGridViewTextBoxColumn.DataPropertyName = "Channnel";
            this.channnelDataGridViewTextBoxColumn.HeaderText = "Channnel";
            this.channnelDataGridViewTextBoxColumn.Name = "channnelDataGridViewTextBoxColumn";
            // 
            // programChangeDataGridViewTextBoxColumn
            // 
            this.programChangeDataGridViewTextBoxColumn.DataPropertyName = "ProgramChange";
            this.programChangeDataGridViewTextBoxColumn.HeaderText = "ProgramChange";
            this.programChangeDataGridViewTextBoxColumn.Name = "programChangeDataGridViewTextBoxColumn";
            // 
            // instrumentBindingSource
            // 
            this.instrumentBindingSource.DataSource = typeof(Instrument);
            // 
            // TabPageEnv
            // 
            this.TabPageEnv.Location = new System.Drawing.Point(4, 24);
            this.TabPageEnv.Name = "TabPageEnv";
            this.TabPageEnv.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageEnv.Size = new System.Drawing.Size(453, 417);
            this.TabPageEnv.TabIndex = 1;
            this.TabPageEnv.Text = "環境設定";
            this.TabPageEnv.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 9F);
            this.btnOK.Location = new System.Drawing.Point(287, 458);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 29);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 9F);
            this.BtnCancel.Location = new System.Drawing.Point(380, 458);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(87, 29);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 494);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "Setting";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPageInst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageInst;
        private System.Windows.Forms.TabPage TabPageEnv;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.DataGridView DgInst;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn channnelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programChangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource instrumentBindingSource;
    }
}