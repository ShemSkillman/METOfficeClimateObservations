namespace METOfficeClimateObservations
{
    partial class ViewGraphs
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
            this.cboxMonthDataTypes = new System.Windows.Forms.ComboBox();
            this.lblDataDisplay = new System.Windows.Forms.Label();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboxMonthDataTypes
            // 
            this.cboxMonthDataTypes.FormattingEnabled = true;
            this.cboxMonthDataTypes.Location = new System.Drawing.Point(126, 8);
            this.cboxMonthDataTypes.Name = "cboxMonthDataTypes";
            this.cboxMonthDataTypes.Size = new System.Drawing.Size(244, 21);
            this.cboxMonthDataTypes.TabIndex = 1;
            this.cboxMonthDataTypes.SelectedIndexChanged += new System.EventHandler(this.cboxMonthDataTypes_SelectedIndexChanged);
            // 
            // lblDataDisplay
            // 
            this.lblDataDisplay.AutoSize = true;
            this.lblDataDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDisplay.Location = new System.Drawing.Point(12, 9);
            this.lblDataDisplay.Name = "lblDataDisplay";
            this.lblDataDisplay.Size = new System.Drawing.Size(108, 17);
            this.lblDataDisplay.TabIndex = 2;
            this.lblDataDisplay.Text = "Data to Display:";
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.Color.White;
            this.DrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DrawingPanel.Location = new System.Drawing.Point(15, 35);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(1200, 800);
            this.DrawingPanel.TabIndex = 4;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            // 
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Location = new System.Drawing.Point(388, 12);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(88, 17);
            this.chkShowValues.TabIndex = 5;
            this.chkShowValues.Text = "Show Values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            this.chkShowValues.CheckedChanged += new System.EventHandler(this.chkShowValues_CheckedChanged);
            // 
            // frmGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1225, 847);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.DrawingPanel);
            this.Controls.Add(this.lblDataDisplay);
            this.Controls.Add(this.cboxMonthDataTypes);
            this.Name = "frmGraphs";
            this.Text = "Monthly Observations Data Graphs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxMonthDataTypes;
        private System.Windows.Forms.Label lblDataDisplay;
        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.CheckBox chkShowValues;
    }
}