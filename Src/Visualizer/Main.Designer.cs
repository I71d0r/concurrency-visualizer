using System.Threading.Tasks;

namespace Visualizer
{
    partial class Main
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
                executor?.CancelAsync().Wait();
                executor?.Dispose();
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
            this.goButton = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.workScopeGB = new System.Windows.Forms.GroupBox();
            this.itemGroupLabel = new System.Windows.Forms.Label();
            this.itemGroupCB = new System.Windows.Forms.ComboBox();
            this.processorTypeLabel = new System.Windows.Forms.Label();
            this.processorTypeCB = new System.Windows.Forms.ComboBox();
            this.generateWorkButton = new System.Windows.Forms.Button();
            this.itemTypeLabel = new System.Windows.Forms.Label();
            this.itemTypeCB = new System.Windows.Forms.ComboBox();
            this.maxSizeNDD = new System.Windows.Forms.NumericUpDown();
            this.maxSizeLabel = new System.Windows.Forms.Label();
            this.minSizeNDD = new System.Windows.Forms.NumericUpDown();
            this.minSizeLabel = new System.Windows.Forms.Label();
            this.itemCountNDD = new System.Windows.Forms.NumericUpDown();
            this.itemCountLabel = new System.Windows.Forms.Label();
            this.executionGB = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.cpuLoadLabel = new System.Windows.Forms.Label();
            this.cpuLoadChart = new Visualizer.Controls.CpuLoad();
            this.activeThreadLable = new System.Windows.Forms.Label();
            this.activeThreadChart = new Visualizer.Controls.Chart();
            this.workProgress = new Visualizer.Controls.WorkProgressControl();
            this.workScopeGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxSizeNDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSizeNDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountNDD)).BeginInit();
            this.executionGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.goButton.Location = new System.Drawing.Point(17, 19);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(256, 29);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Start";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // workScopeGB
            // 
            this.workScopeGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.workScopeGB.Controls.Add(this.itemGroupLabel);
            this.workScopeGB.Controls.Add(this.itemGroupCB);
            this.workScopeGB.Controls.Add(this.processorTypeLabel);
            this.workScopeGB.Controls.Add(this.processorTypeCB);
            this.workScopeGB.Controls.Add(this.generateWorkButton);
            this.workScopeGB.Controls.Add(this.itemTypeLabel);
            this.workScopeGB.Controls.Add(this.itemTypeCB);
            this.workScopeGB.Controls.Add(this.maxSizeNDD);
            this.workScopeGB.Controls.Add(this.maxSizeLabel);
            this.workScopeGB.Controls.Add(this.minSizeNDD);
            this.workScopeGB.Controls.Add(this.minSizeLabel);
            this.workScopeGB.Controls.Add(this.itemCountNDD);
            this.workScopeGB.Controls.Add(this.itemCountLabel);
            this.workScopeGB.ForeColor = System.Drawing.SystemColors.Control;
            this.workScopeGB.Location = new System.Drawing.Point(924, 12);
            this.workScopeGB.Name = "workScopeGB";
            this.workScopeGB.Size = new System.Drawing.Size(295, 355);
            this.workScopeGB.TabIndex = 2;
            this.workScopeGB.TabStop = false;
            this.workScopeGB.Text = " Work Scope ";
            // 
            // itemGroupLabel
            // 
            this.itemGroupLabel.AutoSize = true;
            this.itemGroupLabel.Location = new System.Drawing.Point(14, 150);
            this.itemGroupLabel.Name = "itemGroupLabel";
            this.itemGroupLabel.Size = new System.Drawing.Size(88, 13);
            this.itemGroupLabel.TabIndex = 14;
            this.itemGroupLabel.Text = "Work Item Group";
            // 
            // itemGroupCB
            // 
            this.itemGroupCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemGroupCB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.itemGroupCB.FormattingEnabled = true;
            this.itemGroupCB.Location = new System.Drawing.Point(17, 166);
            this.itemGroupCB.Name = "itemGroupCB";
            this.itemGroupCB.Size = new System.Drawing.Size(107, 21);
            this.itemGroupCB.TabIndex = 13;
            this.itemGroupCB.SelectedIndexChanged += new System.EventHandler(this.itemGroupCB_SelectedIndexChanged);
            // 
            // processorTypeLabel
            // 
            this.processorTypeLabel.AutoSize = true;
            this.processorTypeLabel.Location = new System.Drawing.Point(14, 254);
            this.processorTypeLabel.Name = "processorTypeLabel";
            this.processorTypeLabel.Size = new System.Drawing.Size(110, 13);
            this.processorTypeLabel.TabIndex = 12;
            this.processorTypeLabel.Text = "Work Processor Type";
            // 
            // processorTypeCB
            // 
            this.processorTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processorTypeCB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.processorTypeCB.FormattingEnabled = true;
            this.processorTypeCB.Location = new System.Drawing.Point(17, 270);
            this.processorTypeCB.Name = "processorTypeCB";
            this.processorTypeCB.Size = new System.Drawing.Size(256, 21);
            this.processorTypeCB.TabIndex = 11;
            this.processorTypeCB.SelectedIndexChanged += new System.EventHandler(this.processorTypeCB_SelectedIndexChanged);
            // 
            // generateWorkButton
            // 
            this.generateWorkButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.generateWorkButton.Location = new System.Drawing.Point(17, 315);
            this.generateWorkButton.Name = "generateWorkButton";
            this.generateWorkButton.Size = new System.Drawing.Size(256, 23);
            this.generateWorkButton.TabIndex = 10;
            this.generateWorkButton.Text = "Generate Work";
            this.generateWorkButton.UseVisualStyleBackColor = true;
            this.generateWorkButton.Click += new System.EventHandler(this.generateWorkButton_Click);
            // 
            // itemTypeLabel
            // 
            this.itemTypeLabel.AutoSize = true;
            this.itemTypeLabel.Location = new System.Drawing.Point(14, 202);
            this.itemTypeLabel.Name = "itemTypeLabel";
            this.itemTypeLabel.Size = new System.Drawing.Size(83, 13);
            this.itemTypeLabel.TabIndex = 9;
            this.itemTypeLabel.Text = "Work Item Type";
            // 
            // itemTypeCB
            // 
            this.itemTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemTypeCB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.itemTypeCB.FormattingEnabled = true;
            this.itemTypeCB.Location = new System.Drawing.Point(17, 218);
            this.itemTypeCB.Name = "itemTypeCB";
            this.itemTypeCB.Size = new System.Drawing.Size(256, 21);
            this.itemTypeCB.TabIndex = 8;
            this.itemTypeCB.SelectedIndexChanged += new System.EventHandler(this.itemTypeCB_SelectedIndexChanged);
            // 
            // maxSizeNDD
            // 
            this.maxSizeNDD.Location = new System.Drawing.Point(151, 101);
            this.maxSizeNDD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxSizeNDD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxSizeNDD.Name = "maxSizeNDD";
            this.maxSizeNDD.Size = new System.Drawing.Size(122, 20);
            this.maxSizeNDD.TabIndex = 6;
            this.maxSizeNDD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // maxSizeLabel
            // 
            this.maxSizeLabel.AutoSize = true;
            this.maxSizeLabel.Location = new System.Drawing.Point(148, 85);
            this.maxSizeLabel.Name = "maxSizeLabel";
            this.maxSizeLabel.Size = new System.Drawing.Size(73, 13);
            this.maxSizeLabel.TabIndex = 7;
            this.maxSizeLabel.Text = "Max Item Size";
            // 
            // minSizeNDD
            // 
            this.minSizeNDD.Location = new System.Drawing.Point(17, 101);
            this.minSizeNDD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minSizeNDD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minSizeNDD.Name = "minSizeNDD";
            this.minSizeNDD.Size = new System.Drawing.Size(107, 20);
            this.minSizeNDD.TabIndex = 4;
            this.minSizeNDD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // minSizeLabel
            // 
            this.minSizeLabel.AutoSize = true;
            this.minSizeLabel.Location = new System.Drawing.Point(14, 85);
            this.minSizeLabel.Name = "minSizeLabel";
            this.minSizeLabel.Size = new System.Drawing.Size(88, 13);
            this.minSizeLabel.TabIndex = 5;
            this.minSizeLabel.Text = "Minimal Item Size";
            // 
            // itemCountNDD
            // 
            this.itemCountNDD.Location = new System.Drawing.Point(17, 45);
            this.itemCountNDD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.itemCountNDD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemCountNDD.Name = "itemCountNDD";
            this.itemCountNDD.Size = new System.Drawing.Size(107, 20);
            this.itemCountNDD.TabIndex = 3;
            this.itemCountNDD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // itemCountLabel
            // 
            this.itemCountLabel.AutoSize = true;
            this.itemCountLabel.Location = new System.Drawing.Point(14, 29);
            this.itemCountLabel.Name = "itemCountLabel";
            this.itemCountLabel.Size = new System.Drawing.Size(58, 13);
            this.itemCountLabel.TabIndex = 3;
            this.itemCountLabel.Text = "Item Count";
            // 
            // executionGB
            // 
            this.executionGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.executionGB.Controls.Add(this.timeLabel);
            this.executionGB.Controls.Add(this.cpuLoadLabel);
            this.executionGB.Controls.Add(this.cpuLoadChart);
            this.executionGB.Controls.Add(this.activeThreadLable);
            this.executionGB.Controls.Add(this.activeThreadChart);
            this.executionGB.Controls.Add(this.goButton);
            this.executionGB.ForeColor = System.Drawing.SystemColors.Control;
            this.executionGB.Location = new System.Drawing.Point(924, 382);
            this.executionGB.Name = "executionGB";
            this.executionGB.Size = new System.Drawing.Size(295, 324);
            this.executionGB.TabIndex = 3;
            this.executionGB.TabStop = false;
            this.executionGB.Text = " Execution ";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.timeLabel.Location = new System.Drawing.Point(67, 51);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(154, 24);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "00:00:00.000";
            // 
            // cpuLoadLabel
            // 
            this.cpuLoadLabel.AutoSize = true;
            this.cpuLoadLabel.Location = new System.Drawing.Point(14, 200);
            this.cpuLoadLabel.Name = "cpuLoadLabel";
            this.cpuLoadLabel.Size = new System.Drawing.Size(67, 13);
            this.cpuLoadLabel.TabIndex = 10;
            this.cpuLoadLabel.Text = "CPU Load %";
            // 
            // cpuLoadChart
            // 
            this.cpuLoadChart.BackColor = System.Drawing.Color.Black;
            this.cpuLoadChart.ForeColor = System.Drawing.Color.Yellow;
            this.cpuLoadChart.Location = new System.Drawing.Point(17, 216);
            this.cpuLoadChart.MinimumSize = new System.Drawing.Size(32, 32);
            this.cpuLoadChart.Name = "cpuLoadChart";
            this.cpuLoadChart.ReadCpuLoad = false;
            this.cpuLoadChart.Size = new System.Drawing.Size(256, 91);
            this.cpuLoadChart.TabIndex = 9;
            // 
            // activeThreadLable
            // 
            this.activeThreadLable.AutoSize = true;
            this.activeThreadLable.Location = new System.Drawing.Point(14, 91);
            this.activeThreadLable.Name = "activeThreadLable";
            this.activeThreadLable.Size = new System.Drawing.Size(79, 13);
            this.activeThreadLable.TabIndex = 8;
            this.activeThreadLable.Text = "Active Threads";
            // 
            // activeThreadChart
            // 
            this.activeThreadChart.BackColor = System.Drawing.Color.Black;
            this.activeThreadChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeThreadChart.ForeColor = System.Drawing.Color.Lime;
            this.activeThreadChart.Location = new System.Drawing.Point(17, 107);
            this.activeThreadChart.MinimumSize = new System.Drawing.Size(32, 32);
            this.activeThreadChart.Name = "activeThreadChart";
            this.activeThreadChart.Size = new System.Drawing.Size(256, 81);
            this.activeThreadChart.TabIndex = 1;
            // 
            // workProgress
            // 
            this.workProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workProgress.Location = new System.Drawing.Point(12, 12);
            this.workProgress.Name = "workProgress";
            this.workProgress.Size = new System.Drawing.Size(906, 694);
            this.workProgress.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1231, 718);
            this.Controls.Add(this.executionGB);
            this.Controls.Add(this.workScopeGB);
            this.Controls.Add(this.workProgress);
            this.Name = "Main";
            this.Text = "Concurrency Visualizer";
            this.Resize += new System.EventHandler(this.main_Resize);
            this.workScopeGB.ResumeLayout(false);
            this.workScopeGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxSizeNDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSizeNDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountNDD)).EndInit();
            this.executionGB.ResumeLayout(false);
            this.executionGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private Controls.WorkProgressControl workProgress;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.GroupBox workScopeGB;
        private System.Windows.Forms.Button generateWorkButton;
        private System.Windows.Forms.Label itemTypeLabel;
        private System.Windows.Forms.ComboBox itemTypeCB;
        private System.Windows.Forms.NumericUpDown maxSizeNDD;
        private System.Windows.Forms.Label maxSizeLabel;
        private System.Windows.Forms.NumericUpDown minSizeNDD;
        private System.Windows.Forms.Label minSizeLabel;
        private System.Windows.Forms.NumericUpDown itemCountNDD;
        private System.Windows.Forms.Label itemCountLabel;
        private System.Windows.Forms.GroupBox executionGB;
        private System.Windows.Forms.ComboBox processorTypeCB;
        private System.Windows.Forms.Label processorTypeLabel;
        private System.Windows.Forms.Label itemGroupLabel;
        private System.Windows.Forms.ComboBox itemGroupCB;
        private Controls.Chart activeThreadChart;
        private System.Windows.Forms.Label activeThreadLable;
        private System.Windows.Forms.Label cpuLoadLabel;
        private Controls.CpuLoad cpuLoadChart;
        private System.Windows.Forms.Label timeLabel;
    }
}

