namespace L2CapstoneProject
{
    partial class frmBeamformerPavtController
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
            this.lsvOffsets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddOffset = new System.Windows.Forms.Button();
            this.btnEditOffset = new System.Windows.Forms.Button();
            this.configurationGroupBox = new System.Windows.Forms.GroupBox();
            this.measurementLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.frequencyNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.measurementOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.powerLevelNumeric = new System.Windows.Forms.NumericUpDown();
            this.powerLevelLabel = new System.Windows.Forms.Label();
            this.btnDeleteOffset = new System.Windows.Forms.Button();
            this.resourceNameLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.rfsgNameComboBox = new System.Windows.Forms.ComboBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rfsaNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvResults = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RFsgTimer = new System.Windows.Forms.Timer(this.components);
            this.configurationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measurementLengthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerLevelNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvOffsets
            // 
            this.lsvOffsets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvOffsets.FullRowSelect = true;
            this.lsvOffsets.GridLines = true;
            this.lsvOffsets.HideSelection = false;
            this.lsvOffsets.Location = new System.Drawing.Point(13, 28);
            this.lsvOffsets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsvOffsets.Name = "lsvOffsets";
            this.lsvOffsets.Size = new System.Drawing.Size(237, 162);
            this.lsvOffsets.TabIndex = 1;
            this.lsvOffsets.UseCompatibleStateImageBehavior = false;
            this.lsvOffsets.View = System.Windows.Forms.View.Details;
            this.lsvOffsets.SelectedIndexChanged += new System.EventHandler(this.lsvOffsets_SelectedIndexChanged);
            this.lsvOffsets.DoubleClick += new System.EventHandler(this.EditListViewItem);
            this.lsvOffsets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvOffsets_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Phase (°)";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amplitude (dB)";
            this.columnHeader2.Width = 169;
            // 
            // btnAddOffset
            // 
            this.btnAddOffset.Location = new System.Drawing.Point(13, 195);
            this.btnAddOffset.Name = "btnAddOffset";
            this.btnAddOffset.Size = new System.Drawing.Size(75, 23);
            this.btnAddOffset.TabIndex = 2;
            this.btnAddOffset.Text = "&Add";
            this.btnAddOffset.UseVisualStyleBackColor = true;
            this.btnAddOffset.Click += new System.EventHandler(this.btnAddOffset_Click);
            // 
            // btnEditOffset
            // 
            this.btnEditOffset.Enabled = false;
            this.btnEditOffset.Location = new System.Drawing.Point(94, 195);
            this.btnEditOffset.Name = "btnEditOffset";
            this.btnEditOffset.Size = new System.Drawing.Size(75, 23);
            this.btnEditOffset.TabIndex = 2;
            this.btnEditOffset.Text = "&Edit";
            this.btnEditOffset.UseVisualStyleBackColor = true;
            this.btnEditOffset.Click += new System.EventHandler(this.EditListViewItem);
            // 
            // configurationGroupBox
            // 
            this.configurationGroupBox.Controls.Add(this.measurementLengthNumeric);
            this.configurationGroupBox.Controls.Add(this.frequencyNumeric);
            this.configurationGroupBox.Controls.Add(this.label4);
            this.configurationGroupBox.Controls.Add(this.label3);
            this.configurationGroupBox.Controls.Add(this.frequencyLabel);
            this.configurationGroupBox.Controls.Add(this.measurementOffsetNumeric);
            this.configurationGroupBox.Controls.Add(this.powerLevelNumeric);
            this.configurationGroupBox.Controls.Add(this.powerLevelLabel);
            this.configurationGroupBox.Location = new System.Drawing.Point(28, 73);
            this.configurationGroupBox.Name = "configurationGroupBox";
            this.configurationGroupBox.Size = new System.Drawing.Size(298, 124);
            this.configurationGroupBox.TabIndex = 13;
            this.configurationGroupBox.TabStop = false;
            this.configurationGroupBox.Text = "Configuration";
            // 
            // measurementLengthNumeric
            // 
            this.measurementLengthNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.measurementLengthNumeric.Location = new System.Drawing.Point(159, 39);
            this.measurementLengthNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.measurementLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.measurementLengthNumeric.Name = "measurementLengthNumeric";
            this.measurementLengthNumeric.Size = new System.Drawing.Size(96, 20);
            this.measurementLengthNumeric.TabIndex = 1;
            this.measurementLengthNumeric.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // frequencyNumeric
            // 
            this.frequencyNumeric.DecimalPlaces = 2;
            this.frequencyNumeric.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.frequencyNumeric.Location = new System.Drawing.Point(13, 39);
            this.frequencyNumeric.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.frequencyNumeric.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.frequencyNumeric.Name = "frequencyNumeric";
            this.frequencyNumeric.Size = new System.Drawing.Size(96, 20);
            this.frequencyNumeric.TabIndex = 1;
            this.frequencyNumeric.Value = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Measurement Offset (us)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Measurement Length (us)";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(13, 23);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(127, 15);
            this.frequencyLabel.TabIndex = 1;
            this.frequencyLabel.Text = "Center Frequency [Hz]";
            // 
            // measurementOffsetNumeric
            // 
            this.measurementOffsetNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.measurementOffsetNumeric.Location = new System.Drawing.Point(159, 87);
            this.measurementOffsetNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.measurementOffsetNumeric.Name = "measurementOffsetNumeric";
            this.measurementOffsetNumeric.Size = new System.Drawing.Size(96, 20);
            this.measurementOffsetNumeric.TabIndex = 2;
            this.measurementOffsetNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // powerLevelNumeric
            // 
            this.powerLevelNumeric.DecimalPlaces = 2;
            this.powerLevelNumeric.Location = new System.Drawing.Point(13, 87);
            this.powerLevelNumeric.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.powerLevelNumeric.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.powerLevelNumeric.Name = "powerLevelNumeric";
            this.powerLevelNumeric.Size = new System.Drawing.Size(96, 20);
            this.powerLevelNumeric.TabIndex = 2;
            this.powerLevelNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            // 
            // powerLevelLabel
            // 
            this.powerLevelLabel.AutoSize = true;
            this.powerLevelLabel.Location = new System.Drawing.Point(13, 72);
            this.powerLevelLabel.Name = "powerLevelLabel";
            this.powerLevelLabel.Size = new System.Drawing.Size(109, 15);
            this.powerLevelLabel.TabIndex = 2;
            this.powerLevelLabel.Text = "Power Level [dBm]";
            // 
            // btnDeleteOffset
            // 
            this.btnDeleteOffset.Enabled = false;
            this.btnDeleteOffset.Location = new System.Drawing.Point(175, 195);
            this.btnDeleteOffset.Name = "btnDeleteOffset";
            this.btnDeleteOffset.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOffset.TabIndex = 2;
            this.btnDeleteOffset.Text = "&Delete";
            this.btnDeleteOffset.UseVisualStyleBackColor = true;
            this.btnDeleteOffset.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // resourceNameLabel
            // 
            this.resourceNameLabel.AutoSize = true;
            this.resourceNameLabel.Location = new System.Drawing.Point(26, 16);
            this.resourceNameLabel.Name = "resourceNameLabel";
            this.resourceNameLabel.Size = new System.Drawing.Size(155, 15);
            this.resourceNameLabel.TabIndex = 11;
            this.resourceNameLabel.Text = "Generator Resource Name";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(25, 446);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(87, 15);
            this.errorLabel.TabIndex = 15;
            this.errorLabel.Text = "Current Status:";
            // 
            // rfsgNameComboBox
            // 
            this.rfsgNameComboBox.Location = new System.Drawing.Point(28, 32);
            this.rfsgNameComboBox.Name = "rfsgNameComboBox";
            this.rfsgNameComboBox.Size = new System.Drawing.Size(120, 21);
            this.rfsgNameComboBox.TabIndex = 12;
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(28, 462);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorTextBox.Size = new System.Drawing.Size(560, 60);
            this.errorTextBox.TabIndex = 17;
            this.errorTextBox.TabStop = false;
            this.errorTextBox.Text = "No error.";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(380, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvOffsets);
            this.groupBox1.Controls.Add(this.btnEditOffset);
            this.groupBox1.Controls.Add(this.btnDeleteOffset);
            this.groupBox1.Controls.Add(this.btnAddOffset);
            this.groupBox1.Location = new System.Drawing.Point(28, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 230);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phase and Amplitude Offsets";
            // 
            // rfsaNameComboBox
            // 
            this.rfsaNameComboBox.Location = new System.Drawing.Point(172, 32);
            this.rfsaNameComboBox.Name = "rfsaNameComboBox";
            this.rfsaNameComboBox.Size = new System.Drawing.Size(120, 21);
            this.rfsaNameComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Analyzer Resource Name";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(461, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "St&op";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lsvResults);
            this.groupBox2.Location = new System.Drawing.Point(342, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(246, 359);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Relative Results";
            // 
            // lsvResults
            // 
            this.lsvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.lsvResults.FullRowSelect = true;
            this.lsvResults.GridLines = true;
            this.lsvResults.HideSelection = false;
            this.lsvResults.Location = new System.Drawing.Point(11, 38);
            this.lsvResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsvResults.Name = "lsvResults";
            this.lsvResults.Size = new System.Drawing.Size(221, 281);
            this.lsvResults.TabIndex = 0;
            this.lsvResults.UseCompatibleStateImageBehavior = false;
            this.lsvResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Index";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Phase (°)";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Amplitude (dB)";
            this.columnHeader6.Width = 188;
            // 
            // RFsgTimer
            // 
            this.RFsgTimer.Tick += new System.EventHandler(this.RFsgTimer_Tick);
            // 
            // frmBeamformerPavtController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 543);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.configurationGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resourceNameLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.rfsaNameComboBox);
            this.Controls.Add(this.rfsgNameComboBox);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBeamformerPavtController";
            this.Text = "Beamformer PAVT Measurement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBeamformerPavtController_FormClosing);
            this.configurationGroupBox.ResumeLayout(false);
            this.configurationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measurementLengthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerLevelNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvOffsets;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnAddOffset;
        private System.Windows.Forms.Button btnEditOffset;
        private System.Windows.Forms.GroupBox configurationGroupBox;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Label powerLevelLabel;
        private System.Windows.Forms.Button btnDeleteOffset;
        private System.Windows.Forms.Label resourceNameLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox rfsaNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvResults;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown measurementLengthNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown measurementOffsetNumeric;
        public System.Windows.Forms.ComboBox rfsgNameComboBox;
        public System.Windows.Forms.NumericUpDown frequencyNumeric;
        public System.Windows.Forms.NumericUpDown powerLevelNumeric;
        public System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer RFsgTimer;
    }
}

