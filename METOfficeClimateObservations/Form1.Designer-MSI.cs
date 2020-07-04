namespace METOfficeClimateObservations
{
    partial class frmMain
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
            this.lblLocationYears = new System.Windows.Forms.Label();
            this.lblLocations = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lstLocation = new System.Windows.Forms.ListBox();
            this.lstYear = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveLocationChanges = new System.Windows.Forms.Button();
            this.btnAddNewLocation = new System.Windows.Forms.Button();
            this.btnSaveYearChanges = new System.Windows.Forms.Button();
            this.btnAddNewYear = new System.Windows.Forms.Button();
            this.btnClearYearFields = new System.Windows.Forms.Button();
            this.dgridMonthlyObservations = new System.Windows.Forms.DataGridView();
            this.btnPopulateFields = new System.Windows.Forms.Button();
            this.gboxLocation = new System.Windows.Forms.GroupBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtStreetNumAndName = new System.Windows.Forms.TextBox();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.btnClearLocationFields = new System.Windows.Forms.Button();
            this.lblStreetNumAndName = new System.Windows.Forms.Label();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.TextBox();
            this.lblSearchLocation = new System.Windows.Forms.Label();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.lblSearchYear = new System.Windows.Forms.Label();
            this.txtSearchYear = new System.Windows.Forms.TextBox();
            this.gboxYearDetails = new System.Windows.Forms.GroupBox();
            this.txtYearDescription = new System.Windows.Forms.TextBox();
            this.txtYearDate = new System.Windows.Forms.TextBox();
            this.lblYearDescription = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnDeleteYear = new System.Windows.Forms.Button();
            this.btnClearMonthFields = new System.Windows.Forms.Button();
            this.btnSaveMonthChanges = new System.Windows.Forms.Button();
            this.gboxAdminControls = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShowData = new System.Windows.Forms.Button();
            this.btnClearAllFields = new System.Windows.Forms.Button();
            this.btnSaveAllChangesToFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridMonthlyObservations)).BeginInit();
            this.gboxLocation.SuspendLayout();
            this.gboxYearDetails.SuspendLayout();
            this.gboxAdminControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLocationYears
            // 
            this.lblLocationYears.AutoSize = true;
            this.lblLocationYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationYears.Location = new System.Drawing.Point(37, 420);
            this.lblLocationYears.Name = "lblLocationYears";
            this.lblLocationYears.Size = new System.Drawing.Size(168, 17);
            this.lblLocationYears.TabIndex = 0;
            this.lblLocationYears.Text = "Years Stored in Location:";
            // 
            // lblLocations
            // 
            this.lblLocations.AutoSize = true;
            this.lblLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocations.Location = new System.Drawing.Point(37, 134);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Size = new System.Drawing.Size(138, 17);
            this.lblLocations.TabIndex = 1;
            this.lblLocations.Text = "All Stored Locations:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(694, 421);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(149, 17);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "Monthly Observations:";
            // 
            // lstLocation
            // 
            this.lstLocation.FormattingEnabled = true;
            this.lstLocation.Location = new System.Drawing.Point(40, 154);
            this.lstLocation.Name = "lstLocation";
            this.lstLocation.Size = new System.Drawing.Size(638, 212);
            this.lstLocation.TabIndex = 3;
            this.lstLocation.SelectedIndexChanged += new System.EventHandler(this.lstLocation_SelectedIndexChanged);
            // 
            // lstYear
            // 
            this.lstYear.FormattingEnabled = true;
            this.lstYear.Location = new System.Drawing.Point(40, 440);
            this.lstYear.Name = "lstYear";
            this.lstYear.Size = new System.Drawing.Size(588, 329);
            this.lstYear.TabIndex = 4;
            this.lstYear.SelectedIndexChanged += new System.EventHandler(this.lstYear_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::METOfficeClimateObservations.Properties.Resources.Weather_Banner__1_;
            this.pictureBox1.Location = new System.Drawing.Point(40, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(762, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveLocationChanges
            // 
            this.btnSaveLocationChanges.Location = new System.Drawing.Point(697, 349);
            this.btnSaveLocationChanges.Name = "btnSaveLocationChanges";
            this.btnSaveLocationChanges.Size = new System.Drawing.Size(122, 49);
            this.btnSaveLocationChanges.TabIndex = 7;
            this.btnSaveLocationChanges.Text = "Save Changes to Location";
            this.btnSaveLocationChanges.UseVisualStyleBackColor = true;
            this.btnSaveLocationChanges.Click += new System.EventHandler(this.btnSaveLocationChanges_Click);
            // 
            // btnAddNewLocation
            // 
            this.btnAddNewLocation.Location = new System.Drawing.Point(825, 349);
            this.btnAddNewLocation.Name = "btnAddNewLocation";
            this.btnAddNewLocation.Size = new System.Drawing.Size(122, 49);
            this.btnAddNewLocation.TabIndex = 8;
            this.btnAddNewLocation.Text = "Save as New Location";
            this.btnAddNewLocation.UseVisualStyleBackColor = true;
            this.btnAddNewLocation.Click += new System.EventHandler(this.btnAddNewLocation_Click);
            // 
            // btnSaveYearChanges
            // 
            this.btnSaveYearChanges.Location = new System.Drawing.Point(168, 911);
            this.btnSaveYearChanges.Name = "btnSaveYearChanges";
            this.btnSaveYearChanges.Size = new System.Drawing.Size(122, 49);
            this.btnSaveYearChanges.TabIndex = 9;
            this.btnSaveYearChanges.Text = "Save Changes to Year";
            this.btnSaveYearChanges.UseVisualStyleBackColor = true;
            this.btnSaveYearChanges.Click += new System.EventHandler(this.btnSaveYearChanges_Click);
            // 
            // btnAddNewYear
            // 
            this.btnAddNewYear.Location = new System.Drawing.Point(40, 911);
            this.btnAddNewYear.Name = "btnAddNewYear";
            this.btnAddNewYear.Size = new System.Drawing.Size(122, 49);
            this.btnAddNewYear.TabIndex = 10;
            this.btnAddNewYear.Text = "Save as New Year";
            this.btnAddNewYear.UseVisualStyleBackColor = true;
            this.btnAddNewYear.Click += new System.EventHandler(this.btnAddNewYear_Click);
            // 
            // btnClearYearFields
            // 
            this.btnClearYearFields.Location = new System.Drawing.Point(460, 51);
            this.btnClearYearFields.Name = "btnClearYearFields";
            this.btnClearYearFields.Size = new System.Drawing.Size(122, 31);
            this.btnClearYearFields.TabIndex = 11;
            this.btnClearYearFields.Text = "Clear Year Fields";
            this.btnClearYearFields.UseVisualStyleBackColor = true;
            this.btnClearYearFields.Click += new System.EventHandler(this.btnClearYearFields_Click);
            // 
            // dgridMonthlyObservations
            // 
            this.dgridMonthlyObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridMonthlyObservations.Location = new System.Drawing.Point(697, 440);
            this.dgridMonthlyObservations.Name = "dgridMonthlyObservations";
            this.dgridMonthlyObservations.Size = new System.Drawing.Size(638, 466);
            this.dgridMonthlyObservations.TabIndex = 12;
            // 
            // btnPopulateFields
            // 
            this.btnPopulateFields.Location = new System.Drawing.Point(697, 912);
            this.btnPopulateFields.Name = "btnPopulateFields";
            this.btnPopulateFields.Size = new System.Drawing.Size(122, 49);
            this.btnPopulateFields.TabIndex = 13;
            this.btnPopulateFields.Text = "Populate Fields in Monthly Observations";
            this.btnPopulateFields.UseVisualStyleBackColor = true;
            // 
            // gboxLocation
            // 
            this.gboxLocation.Controls.Add(this.txtLongitude);
            this.gboxLocation.Controls.Add(this.txtLatitude);
            this.gboxLocation.Controls.Add(this.txtPostCode);
            this.gboxLocation.Controls.Add(this.txtCounty);
            this.gboxLocation.Controls.Add(this.txtStreetNumAndName);
            this.gboxLocation.Controls.Add(this.txtLocationName);
            this.gboxLocation.Controls.Add(this.lblLongitude);
            this.gboxLocation.Controls.Add(this.lblLatitude);
            this.gboxLocation.Controls.Add(this.lblPostCode);
            this.gboxLocation.Controls.Add(this.lblCounty);
            this.gboxLocation.Controls.Add(this.btnClearLocationFields);
            this.gboxLocation.Controls.Add(this.lblStreetNumAndName);
            this.gboxLocation.Controls.Add(this.lblLocationName);
            this.gboxLocation.Location = new System.Drawing.Point(697, 154);
            this.gboxLocation.Name = "gboxLocation";
            this.gboxLocation.Size = new System.Drawing.Size(638, 189);
            this.gboxLocation.TabIndex = 14;
            this.gboxLocation.TabStop = false;
            this.gboxLocation.Text = "Location details";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(146, 153);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 20);
            this.txtLongitude.TabIndex = 11;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(146, 127);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 20);
            this.txtLatitude.TabIndex = 10;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(146, 101);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtPostCode.TabIndex = 9;
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(146, 75);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(163, 20);
            this.txtCounty.TabIndex = 8;
            // 
            // txtStreetNumAndName
            // 
            this.txtStreetNumAndName.Location = new System.Drawing.Point(146, 49);
            this.txtStreetNumAndName.Name = "txtStreetNumAndName";
            this.txtStreetNumAndName.Size = new System.Drawing.Size(297, 20);
            this.txtStreetNumAndName.TabIndex = 7;
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(146, 24);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(215, 20);
            this.txtLocationName.TabIndex = 6;
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(10, 156);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(57, 13);
            this.lblLongitude.TabIndex = 5;
            this.lblLongitude.Text = "Longitude:";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(10, 130);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(48, 13);
            this.lblLatitude.TabIndex = 4;
            this.lblLatitude.Text = "Latitude:";
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(10, 104);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(55, 13);
            this.lblPostCode.TabIndex = 3;
            this.lblPostCode.Text = "Postcode:";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Location = new System.Drawing.Point(10, 78);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(43, 13);
            this.lblCounty.TabIndex = 2;
            this.lblCounty.Text = "County:";
            // 
            // btnClearLocationFields
            // 
            this.btnClearLocationFields.Location = new System.Drawing.Point(510, 152);
            this.btnClearLocationFields.Name = "btnClearLocationFields";
            this.btnClearLocationFields.Size = new System.Drawing.Size(122, 31);
            this.btnClearLocationFields.TabIndex = 15;
            this.btnClearLocationFields.Text = "Clear Location Fields";
            this.btnClearLocationFields.UseVisualStyleBackColor = true;
            this.btnClearLocationFields.Click += new System.EventHandler(this.btnClearLocationFields_Click);
            // 
            // lblStreetNumAndName
            // 
            this.lblStreetNumAndName.AutoSize = true;
            this.lblStreetNumAndName.Location = new System.Drawing.Point(10, 52);
            this.lblStreetNumAndName.Name = "lblStreetNumAndName";
            this.lblStreetNumAndName.Size = new System.Drawing.Size(130, 13);
            this.lblStreetNumAndName.TabIndex = 1;
            this.lblStreetNumAndName.Text = "Street Number and Name:";
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Location = new System.Drawing.Point(10, 27);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(82, 13);
            this.lblLocationName.TabIndex = 0;
            this.lblLocationName.Text = "Location Name:";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(186, 372);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(215, 20);
            this.Search.TabIndex = 16;
            // 
            // lblSearchLocation
            // 
            this.lblSearchLocation.AutoSize = true;
            this.lblSearchLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchLocation.Location = new System.Drawing.Point(37, 373);
            this.lblSearchLocation.Name = "lblSearchLocation";
            this.lblSearchLocation.Size = new System.Drawing.Size(115, 17);
            this.lblSearchLocation.TabIndex = 17;
            this.lblSearchLocation.Text = "Search Location:";
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(1213, 349);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(122, 49);
            this.btnDeleteLocation.TabIndex = 18;
            this.btnDeleteLocation.Text = "Delete Location";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            // 
            // lblSearchYear
            // 
            this.lblSearchYear.AutoSize = true;
            this.lblSearchYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchYear.Location = new System.Drawing.Point(37, 776);
            this.lblSearchYear.Name = "lblSearchYear";
            this.lblSearchYear.Size = new System.Drawing.Size(91, 17);
            this.lblSearchYear.TabIndex = 19;
            this.lblSearchYear.Text = "Search Year:";
            // 
            // txtSearchYear
            // 
            this.txtSearchYear.Location = new System.Drawing.Point(141, 775);
            this.txtSearchYear.Name = "txtSearchYear";
            this.txtSearchYear.Size = new System.Drawing.Size(100, 20);
            this.txtSearchYear.TabIndex = 20;
            // 
            // gboxYearDetails
            // 
            this.gboxYearDetails.Controls.Add(this.txtYearDescription);
            this.gboxYearDetails.Controls.Add(this.txtYearDate);
            this.gboxYearDetails.Controls.Add(this.lblYearDescription);
            this.gboxYearDetails.Controls.Add(this.lblYear);
            this.gboxYearDetails.Controls.Add(this.btnClearYearFields);
            this.gboxYearDetails.Location = new System.Drawing.Point(40, 816);
            this.gboxYearDetails.Name = "gboxYearDetails";
            this.gboxYearDetails.Size = new System.Drawing.Size(588, 88);
            this.gboxYearDetails.TabIndex = 21;
            this.gboxYearDetails.TabStop = false;
            this.gboxYearDetails.Text = "Year details";
            // 
            // txtYearDescription
            // 
            this.txtYearDescription.Location = new System.Drawing.Point(101, 46);
            this.txtYearDescription.Name = "txtYearDescription";
            this.txtYearDescription.Size = new System.Drawing.Size(329, 20);
            this.txtYearDescription.TabIndex = 3;
            // 
            // txtYearDate
            // 
            this.txtYearDate.Location = new System.Drawing.Point(101, 21);
            this.txtYearDate.Name = "txtYearDate";
            this.txtYearDate.Size = new System.Drawing.Size(100, 20);
            this.txtYearDate.TabIndex = 2;
            // 
            // lblYearDescription
            // 
            this.lblYearDescription.AutoSize = true;
            this.lblYearDescription.Location = new System.Drawing.Point(7, 49);
            this.lblYearDescription.Name = "lblYearDescription";
            this.lblYearDescription.Size = new System.Drawing.Size(88, 13);
            this.lblYearDescription.TabIndex = 1;
            this.lblYearDescription.Text = "Year Description:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(6, 24);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Year:";
            // 
            // btnDeleteYear
            // 
            this.btnDeleteYear.Location = new System.Drawing.Point(506, 911);
            this.btnDeleteYear.Name = "btnDeleteYear";
            this.btnDeleteYear.Size = new System.Drawing.Size(122, 49);
            this.btnDeleteYear.TabIndex = 22;
            this.btnDeleteYear.Text = "Delete Year";
            this.btnDeleteYear.UseVisualStyleBackColor = true;
            // 
            // btnClearMonthFields
            // 
            this.btnClearMonthFields.Location = new System.Drawing.Point(1226, 913);
            this.btnClearMonthFields.Name = "btnClearMonthFields";
            this.btnClearMonthFields.Size = new System.Drawing.Size(109, 48);
            this.btnClearMonthFields.TabIndex = 23;
            this.btnClearMonthFields.Text = "Clear Monthly Observation Fields";
            this.btnClearMonthFields.UseVisualStyleBackColor = true;
            // 
            // btnSaveMonthChanges
            // 
            this.btnSaveMonthChanges.Location = new System.Drawing.Point(825, 911);
            this.btnSaveMonthChanges.Name = "btnSaveMonthChanges";
            this.btnSaveMonthChanges.Size = new System.Drawing.Size(109, 48);
            this.btnSaveMonthChanges.TabIndex = 24;
            this.btnSaveMonthChanges.Text = "Save Changes to Monthly Observations";
            this.btnSaveMonthChanges.UseVisualStyleBackColor = true;
            // 
            // gboxAdminControls
            // 
            this.gboxAdminControls.Controls.Add(this.btnExit);
            this.gboxAdminControls.Controls.Add(this.btnShowData);
            this.gboxAdminControls.Controls.Add(this.btnClearAllFields);
            this.gboxAdminControls.Controls.Add(this.btnSaveAllChangesToFile);
            this.gboxAdminControls.Location = new System.Drawing.Point(1374, 281);
            this.gboxAdminControls.Name = "gboxAdminControls";
            this.gboxAdminControls.Size = new System.Drawing.Size(153, 271);
            this.gboxAdminControls.TabIndex = 25;
            this.gboxAdminControls.TabStop = false;
            this.gboxAdminControls.Text = "Admin Controls";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(16, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnShowData
            // 
            this.btnShowData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowData.Location = new System.Drawing.Point(16, 24);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(122, 50);
            this.btnShowData.TabIndex = 2;
            this.btnShowData.Text = "Show All Data in File";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click_1);
            // 
            // btnClearAllFields
            // 
            this.btnClearAllFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAllFields.Location = new System.Drawing.Point(16, 152);
            this.btnClearAllFields.Name = "btnClearAllFields";
            this.btnClearAllFields.Size = new System.Drawing.Size(122, 50);
            this.btnClearAllFields.TabIndex = 1;
            this.btnClearAllFields.Text = "Clear All Text Fields";
            this.btnClearAllFields.UseVisualStyleBackColor = true;
            this.btnClearAllFields.Click += new System.EventHandler(this.btnClearAllFields_Click);
            // 
            // btnSaveAllChangesToFile
            // 
            this.btnSaveAllChangesToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAllChangesToFile.Location = new System.Drawing.Point(16, 80);
            this.btnSaveAllChangesToFile.Name = "btnSaveAllChangesToFile";
            this.btnSaveAllChangesToFile.Size = new System.Drawing.Size(122, 50);
            this.btnSaveAllChangesToFile.TabIndex = 0;
            this.btnSaveAllChangesToFile.Text = "Save All Changes to File";
            this.btnSaveAllChangesToFile.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 1008);
            this.Controls.Add(this.gboxAdminControls);
            this.Controls.Add(this.btnSaveMonthChanges);
            this.Controls.Add(this.btnClearMonthFields);
            this.Controls.Add(this.btnDeleteYear);
            this.Controls.Add(this.gboxYearDetails);
            this.Controls.Add(this.txtSearchYear);
            this.Controls.Add(this.lblSearchYear);
            this.Controls.Add(this.btnDeleteLocation);
            this.Controls.Add(this.lblSearchLocation);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.gboxLocation);
            this.Controls.Add(this.btnPopulateFields);
            this.Controls.Add(this.dgridMonthlyObservations);
            this.Controls.Add(this.btnAddNewYear);
            this.Controls.Add(this.btnSaveYearChanges);
            this.Controls.Add(this.btnAddNewLocation);
            this.Controls.Add(this.btnSaveLocationChanges);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstYear);
            this.Controls.Add(this.lstLocation);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblLocations);
            this.Controls.Add(this.lblLocationYears);
            this.Name = "frmMain";
            this.Text = "MET Office Climate Observations";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridMonthlyObservations)).EndInit();
            this.gboxLocation.ResumeLayout(false);
            this.gboxLocation.PerformLayout();
            this.gboxYearDetails.ResumeLayout(false);
            this.gboxYearDetails.PerformLayout();
            this.gboxAdminControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocationYears;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ListBox lstLocation;
        private System.Windows.Forms.ListBox lstYear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveLocationChanges;
        private System.Windows.Forms.Button btnAddNewLocation;
        private System.Windows.Forms.Button btnSaveYearChanges;
        private System.Windows.Forms.Button btnAddNewYear;
        private System.Windows.Forms.Button btnClearYearFields;
        private System.Windows.Forms.DataGridView dgridMonthlyObservations;
        private System.Windows.Forms.Button btnPopulateFields;
        private System.Windows.Forms.GroupBox gboxLocation;
        private System.Windows.Forms.Label lblStreetNumAndName;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtStreetNumAndName;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Button btnClearLocationFields;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label lblSearchLocation;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Label lblSearchYear;
        private System.Windows.Forms.TextBox txtSearchYear;
        private System.Windows.Forms.GroupBox gboxYearDetails;
        private System.Windows.Forms.TextBox txtYearDescription;
        private System.Windows.Forms.TextBox txtYearDate;
        private System.Windows.Forms.Label lblYearDescription;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnDeleteYear;
        private System.Windows.Forms.Button btnClearMonthFields;
        private System.Windows.Forms.Button btnSaveMonthChanges;
        private System.Windows.Forms.GroupBox gboxAdminControls;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.Button btnClearAllFields;
        private System.Windows.Forms.Button btnSaveAllChangesToFile;
        private System.Windows.Forms.Button btnExit;
    }
}

