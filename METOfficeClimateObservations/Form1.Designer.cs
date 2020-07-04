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
            this.btnSaveLocationChanges = new System.Windows.Forms.Button();
            this.btnAddNewLocation = new System.Windows.Forms.Button();
            this.btnSaveYearChanges = new System.Windows.Forms.Button();
            this.btnAddNewYear = new System.Windows.Forms.Button();
            this.btnClearYearFields = new System.Windows.Forms.Button();
            this.dgdMonthlyObservations = new System.Windows.Forms.DataGridView();
            this.btnPopulateCells = new System.Windows.Forms.Button();
            this.gboxLocation = new System.Windows.Forms.GroupBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.txtStreetNumAndName = new System.Windows.Forms.TextBox();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.btnClearLocationFields = new System.Windows.Forms.Button();
            this.lblStreetNumAndName = new System.Windows.Forms.Label();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.lblSearchLocation = new System.Windows.Forms.Label();
            this.lblSearchYear = new System.Windows.Forms.Label();
            this.txtSearchYear = new System.Windows.Forms.TextBox();
            this.gboxYearDetails = new System.Windows.Forms.GroupBox();
            this.txtYearDescription = new System.Windows.Forms.TextBox();
            this.btnDeleteYear = new System.Windows.Forms.Button();
            this.txtYearDate = new System.Windows.Forms.TextBox();
            this.lblYearDescription = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnClearMonthFields = new System.Windows.Forms.Button();
            this.btnSaveMonthChanges = new System.Windows.Forms.Button();
            this.gboxAdminControls = new System.Windows.Forms.GroupBox();
            this.btnClearAllData = new System.Windows.Forms.Button();
            this.lblFileDirectory = new System.Windows.Forms.Label();
            this.btnSaveToNewFile = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveAllChangesToFile = new System.Windows.Forms.Button();
            this.gboxMonth = new System.Windows.Forms.GroupBox();
            this.btnMonthGraphs = new System.Windows.Forms.Button();
            this.txtSearchLocation = new System.Windows.Forms.TextBox();
            this.lblLocationSearchStatus = new System.Windows.Forms.Label();
            this.btnNextFoundLocation = new System.Windows.Forms.Button();
            this.btnClearLocationSearch = new System.Windows.Forms.Button();
            this.btnClearYearSearch = new System.Windows.Forms.Button();
            this.btnNextFoundYear = new System.Windows.Forms.Button();
            this.lblYearSearchStatus = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgdMonthlyObservations)).BeginInit();
            this.gboxLocation.SuspendLayout();
            this.gboxYearDetails.SuspendLayout();
            this.gboxAdminControls.SuspendLayout();
            this.gboxMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLocationYears
            // 
            this.lblLocationYears.AutoSize = true;
            this.lblLocationYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationYears.Location = new System.Drawing.Point(9, 296);
            this.lblLocationYears.Name = "lblLocationYears";
            this.lblLocationYears.Size = new System.Drawing.Size(168, 17);
            this.lblLocationYears.TabIndex = 0;
            this.lblLocationYears.Text = "Years Stored in Location:";
            // 
            // lblLocations
            // 
            this.lblLocations.AutoSize = true;
            this.lblLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocations.Location = new System.Drawing.Point(9, 10);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Size = new System.Drawing.Size(138, 17);
            this.lblLocations.TabIndex = 1;
            this.lblLocations.Text = "All Stored Locations:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(666, 297);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(149, 17);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "Monthly Observations:";
            // 
            // lstLocation
            // 
            this.lstLocation.FormattingEnabled = true;
            this.lstLocation.Location = new System.Drawing.Point(12, 30);
            this.lstLocation.Name = "lstLocation";
            this.lstLocation.Size = new System.Drawing.Size(638, 212);
            this.lstLocation.TabIndex = 3;
            this.lstLocation.SelectedIndexChanged += new System.EventHandler(this.lstLocation_SelectedIndexChanged);
            // 
            // lstYear
            // 
            this.lstYear.FormattingEnabled = true;
            this.lstYear.Location = new System.Drawing.Point(12, 316);
            this.lstYear.Name = "lstYear";
            this.lstYear.Size = new System.Drawing.Size(638, 329);
            this.lstYear.TabIndex = 4;
            this.lstYear.SelectedIndexChanged += new System.EventHandler(this.lstYear_SelectedIndexChanged);
            // 
            // btnSaveLocationChanges
            // 
            this.btnSaveLocationChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveLocationChanges.Location = new System.Drawing.Point(121, 193);
            this.btnSaveLocationChanges.Name = "btnSaveLocationChanges";
            this.btnSaveLocationChanges.Size = new System.Drawing.Size(109, 48);
            this.btnSaveLocationChanges.TabIndex = 7;
            this.btnSaveLocationChanges.Text = "Save Changes to Location";
            this.btnSaveLocationChanges.UseVisualStyleBackColor = false;
            this.btnSaveLocationChanges.Click += new System.EventHandler(this.btnSaveLocationChanges_Click);
            // 
            // btnAddNewLocation
            // 
            this.btnAddNewLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddNewLocation.Location = new System.Drawing.Point(6, 193);
            this.btnAddNewLocation.Name = "btnAddNewLocation";
            this.btnAddNewLocation.Size = new System.Drawing.Size(109, 48);
            this.btnAddNewLocation.TabIndex = 8;
            this.btnAddNewLocation.Text = "Save as New Location";
            this.btnAddNewLocation.UseVisualStyleBackColor = false;
            this.btnAddNewLocation.Click += new System.EventHandler(this.btnAddNewLocation_Click);
            // 
            // btnSaveYearChanges
            // 
            this.btnSaveYearChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveYearChanges.Location = new System.Drawing.Point(121, 98);
            this.btnSaveYearChanges.Name = "btnSaveYearChanges";
            this.btnSaveYearChanges.Size = new System.Drawing.Size(109, 48);
            this.btnSaveYearChanges.TabIndex = 9;
            this.btnSaveYearChanges.Text = "Save Changes to Year";
            this.btnSaveYearChanges.UseVisualStyleBackColor = false;
            this.btnSaveYearChanges.Click += new System.EventHandler(this.btnSaveYearChanges_Click);
            // 
            // btnAddNewYear
            // 
            this.btnAddNewYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddNewYear.Location = new System.Drawing.Point(6, 98);
            this.btnAddNewYear.Name = "btnAddNewYear";
            this.btnAddNewYear.Size = new System.Drawing.Size(109, 48);
            this.btnAddNewYear.TabIndex = 10;
            this.btnAddNewYear.Text = "Save as New Year";
            this.btnAddNewYear.UseVisualStyleBackColor = false;
            this.btnAddNewYear.Click += new System.EventHandler(this.btnAddNewYear_Click);
            // 
            // btnClearYearFields
            // 
            this.btnClearYearFields.Location = new System.Drawing.Point(510, 113);
            this.btnClearYearFields.Name = "btnClearYearFields";
            this.btnClearYearFields.Size = new System.Drawing.Size(122, 31);
            this.btnClearYearFields.TabIndex = 11;
            this.btnClearYearFields.Text = "Clear Year Fields";
            this.btnClearYearFields.UseVisualStyleBackColor = true;
            this.btnClearYearFields.Click += new System.EventHandler(this.btnClearYearFields_Click);
            // 
            // dgdMonthlyObservations
            // 
            this.dgdMonthlyObservations.AllowUserToAddRows = false;
            this.dgdMonthlyObservations.AllowUserToDeleteRows = false;
            this.dgdMonthlyObservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgdMonthlyObservations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgdMonthlyObservations.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgdMonthlyObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdMonthlyObservations.Location = new System.Drawing.Point(669, 316);
            this.dgdMonthlyObservations.Name = "dgdMonthlyObservations";
            this.dgdMonthlyObservations.RowHeadersWidth = 100;
            this.dgdMonthlyObservations.Size = new System.Drawing.Size(638, 289);
            this.dgdMonthlyObservations.TabIndex = 12;
            // 
            // btnPopulateCells
            // 
            this.btnPopulateCells.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPopulateCells.Location = new System.Drawing.Point(6, 25);
            this.btnPopulateCells.Name = "btnPopulateCells";
            this.btnPopulateCells.Size = new System.Drawing.Size(109, 48);
            this.btnPopulateCells.TabIndex = 13;
            this.btnPopulateCells.Text = "Populate Cells in Monthly Observations";
            this.btnPopulateCells.UseVisualStyleBackColor = true;
            this.btnPopulateCells.Click += new System.EventHandler(this.btnPopulateFields_Click);
            // 
            // gboxLocation
            // 
            this.gboxLocation.Controls.Add(this.txtLongitude);
            this.gboxLocation.Controls.Add(this.txtLatitude);
            this.gboxLocation.Controls.Add(this.txtPostCode);
            this.gboxLocation.Controls.Add(this.txtCounty);
            this.gboxLocation.Controls.Add(this.txtStreetNumAndName);
            this.gboxLocation.Controls.Add(this.btnDeleteLocation);
            this.gboxLocation.Controls.Add(this.txtLocationName);
            this.gboxLocation.Controls.Add(this.lblLongitude);
            this.gboxLocation.Controls.Add(this.lblLatitude);
            this.gboxLocation.Controls.Add(this.lblPostCode);
            this.gboxLocation.Controls.Add(this.lblCounty);
            this.gboxLocation.Controls.Add(this.btnClearLocationFields);
            this.gboxLocation.Controls.Add(this.lblStreetNumAndName);
            this.gboxLocation.Controls.Add(this.lblLocationName);
            this.gboxLocation.Controls.Add(this.btnSaveLocationChanges);
            this.gboxLocation.Controls.Add(this.btnAddNewLocation);
            this.gboxLocation.Location = new System.Drawing.Point(669, 30);
            this.gboxLocation.Name = "gboxLocation";
            this.gboxLocation.Size = new System.Drawing.Size(638, 248);
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
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteLocation.Location = new System.Drawing.Point(236, 193);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(109, 48);
            this.btnDeleteLocation.TabIndex = 18;
            this.btnDeleteLocation.Text = "Delete Location";
            this.btnDeleteLocation.UseVisualStyleBackColor = false;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
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
            this.lblLongitude.Location = new System.Drawing.Point(3, 156);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(57, 13);
            this.lblLongitude.TabIndex = 5;
            this.lblLongitude.Text = "Longitude:";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(3, 130);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(48, 13);
            this.lblLatitude.TabIndex = 4;
            this.lblLatitude.Text = "Latitude:";
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(3, 104);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(55, 13);
            this.lblPostCode.TabIndex = 3;
            this.lblPostCode.Text = "Postcode:";
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Location = new System.Drawing.Point(3, 78);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(43, 13);
            this.lblCounty.TabIndex = 2;
            this.lblCounty.Text = "County:";
            // 
            // btnClearLocationFields
            // 
            this.btnClearLocationFields.Location = new System.Drawing.Point(510, 209);
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
            this.lblStreetNumAndName.Location = new System.Drawing.Point(3, 52);
            this.lblStreetNumAndName.Name = "lblStreetNumAndName";
            this.lblStreetNumAndName.Size = new System.Drawing.Size(130, 13);
            this.lblStreetNumAndName.TabIndex = 1;
            this.lblStreetNumAndName.Text = "Street Number and Name:";
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Location = new System.Drawing.Point(3, 27);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(82, 13);
            this.lblLocationName.TabIndex = 0;
            this.lblLocationName.Text = "Location Name:";
            // 
            // lblSearchLocation
            // 
            this.lblSearchLocation.AutoSize = true;
            this.lblSearchLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchLocation.Location = new System.Drawing.Point(9, 253);
            this.lblSearchLocation.Name = "lblSearchLocation";
            this.lblSearchLocation.Size = new System.Drawing.Size(115, 17);
            this.lblSearchLocation.TabIndex = 17;
            this.lblSearchLocation.Text = "Search Location:";
            // 
            // lblSearchYear
            // 
            this.lblSearchYear.AutoSize = true;
            this.lblSearchYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchYear.Location = new System.Drawing.Point(12, 654);
            this.lblSearchYear.Name = "lblSearchYear";
            this.lblSearchYear.Size = new System.Drawing.Size(91, 17);
            this.lblSearchYear.TabIndex = 19;
            this.lblSearchYear.Text = "Search Year:";
            // 
            // txtSearchYear
            // 
            this.txtSearchYear.Location = new System.Drawing.Point(113, 654);
            this.txtSearchYear.Name = "txtSearchYear";
            this.txtSearchYear.Size = new System.Drawing.Size(100, 20);
            this.txtSearchYear.TabIndex = 20;
            this.txtSearchYear.TextChanged += new System.EventHandler(this.txtSearchYear_TextChanged);
            // 
            // gboxYearDetails
            // 
            this.gboxYearDetails.Controls.Add(this.txtYearDescription);
            this.gboxYearDetails.Controls.Add(this.btnDeleteYear);
            this.gboxYearDetails.Controls.Add(this.txtYearDate);
            this.gboxYearDetails.Controls.Add(this.lblYearDescription);
            this.gboxYearDetails.Controls.Add(this.lblYear);
            this.gboxYearDetails.Controls.Add(this.btnClearYearFields);
            this.gboxYearDetails.Controls.Add(this.btnSaveYearChanges);
            this.gboxYearDetails.Controls.Add(this.btnAddNewYear);
            this.gboxYearDetails.Location = new System.Drawing.Point(12, 692);
            this.gboxYearDetails.Name = "gboxYearDetails";
            this.gboxYearDetails.Size = new System.Drawing.Size(638, 152);
            this.gboxYearDetails.TabIndex = 21;
            this.gboxYearDetails.TabStop = false;
            this.gboxYearDetails.Text = "Year details";
            // 
            // txtYearDescription
            // 
            this.txtYearDescription.Location = new System.Drawing.Point(101, 46);
            this.txtYearDescription.Name = "txtYearDescription";
            this.txtYearDescription.Size = new System.Drawing.Size(369, 20);
            this.txtYearDescription.TabIndex = 3;
            // 
            // btnDeleteYear
            // 
            this.btnDeleteYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteYear.Location = new System.Drawing.Point(236, 98);
            this.btnDeleteYear.Name = "btnDeleteYear";
            this.btnDeleteYear.Size = new System.Drawing.Size(109, 48);
            this.btnDeleteYear.TabIndex = 22;
            this.btnDeleteYear.Text = "Delete Year";
            this.btnDeleteYear.UseVisualStyleBackColor = false;
            this.btnDeleteYear.Click += new System.EventHandler(this.btnDeleteYear_Click);
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
            // btnClearMonthFields
            // 
            this.btnClearMonthFields.Location = new System.Drawing.Point(518, 25);
            this.btnClearMonthFields.Name = "btnClearMonthFields";
            this.btnClearMonthFields.Size = new System.Drawing.Size(109, 48);
            this.btnClearMonthFields.TabIndex = 23;
            this.btnClearMonthFields.Text = "Clear Monthly Observation Fields";
            this.btnClearMonthFields.UseVisualStyleBackColor = true;
            this.btnClearMonthFields.Click += new System.EventHandler(this.btnClearMonthFields_Click);
            // 
            // btnSaveMonthChanges
            // 
            this.btnSaveMonthChanges.Location = new System.Drawing.Point(121, 25);
            this.btnSaveMonthChanges.Name = "btnSaveMonthChanges";
            this.btnSaveMonthChanges.Size = new System.Drawing.Size(109, 48);
            this.btnSaveMonthChanges.TabIndex = 24;
            this.btnSaveMonthChanges.Text = "Save Changes to Monthly Observations";
            this.btnSaveMonthChanges.UseVisualStyleBackColor = true;
            this.btnSaveMonthChanges.Click += new System.EventHandler(this.btnSaveMonthChanges_Click);
            // 
            // gboxAdminControls
            // 
            this.gboxAdminControls.Controls.Add(this.btnClearAllData);
            this.gboxAdminControls.Controls.Add(this.lblFileDirectory);
            this.gboxAdminControls.Controls.Add(this.btnSaveToNewFile);
            this.gboxAdminControls.Controls.Add(this.btnLoadData);
            this.gboxAdminControls.Controls.Add(this.btnExit);
            this.gboxAdminControls.Controls.Add(this.btnSaveAllChangesToFile);
            this.gboxAdminControls.Location = new System.Drawing.Point(669, 716);
            this.gboxAdminControls.Name = "gboxAdminControls";
            this.gboxAdminControls.Size = new System.Drawing.Size(638, 128);
            this.gboxAdminControls.TabIndex = 25;
            this.gboxAdminControls.TabStop = false;
            this.gboxAdminControls.Text = "Admin Controls";
            // 
            // btnClearAllData
            // 
            this.btnClearAllData.Location = new System.Drawing.Point(351, 72);
            this.btnClearAllData.Name = "btnClearAllData";
            this.btnClearAllData.Size = new System.Drawing.Size(109, 48);
            this.btnClearAllData.TabIndex = 7;
            this.btnClearAllData.Text = "Clear All Data";
            this.btnClearAllData.UseVisualStyleBackColor = true;
            this.btnClearAllData.Click += new System.EventHandler(this.btnClearAllData_Click);
            // 
            // lblFileDirectory
            // 
            this.lblFileDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileDirectory.Location = new System.Drawing.Point(6, 26);
            this.lblFileDirectory.Name = "lblFileDirectory";
            this.lblFileDirectory.Size = new System.Drawing.Size(621, 31);
            this.lblFileDirectory.TabIndex = 6;
            this.lblFileDirectory.Text = "File Directory: none";
            // 
            // btnSaveToNewFile
            // 
            this.btnSaveToNewFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToNewFile.Location = new System.Drawing.Point(236, 72);
            this.btnSaveToNewFile.Name = "btnSaveToNewFile";
            this.btnSaveToNewFile.Size = new System.Drawing.Size(109, 48);
            this.btnSaveToNewFile.TabIndex = 5;
            this.btnSaveToNewFile.Text = "Save to New File";
            this.btnSaveToNewFile.UseVisualStyleBackColor = true;
            this.btnSaveToNewFile.Click += new System.EventHandler(this.btnChangeSaveFileDirectory_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(6, 72);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(109, 48);
            this.btnLoadData.TabIndex = 4;
            this.btnLoadData.Text = "Load Data From File";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(523, 72);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 48);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveAllChangesToFile
            // 
            this.btnSaveAllChangesToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAllChangesToFile.Location = new System.Drawing.Point(121, 72);
            this.btnSaveAllChangesToFile.Name = "btnSaveAllChangesToFile";
            this.btnSaveAllChangesToFile.Size = new System.Drawing.Size(109, 48);
            this.btnSaveAllChangesToFile.TabIndex = 0;
            this.btnSaveAllChangesToFile.Text = "Save All Changes to File";
            this.btnSaveAllChangesToFile.UseVisualStyleBackColor = true;
            this.btnSaveAllChangesToFile.Click += new System.EventHandler(this.btnSaveAllChangesToFile_Click);
            // 
            // gboxMonth
            // 
            this.gboxMonth.Controls.Add(this.btnMonthGraphs);
            this.gboxMonth.Controls.Add(this.btnPopulateCells);
            this.gboxMonth.Controls.Add(this.btnClearMonthFields);
            this.gboxMonth.Controls.Add(this.btnSaveMonthChanges);
            this.gboxMonth.Location = new System.Drawing.Point(669, 612);
            this.gboxMonth.Name = "gboxMonth";
            this.gboxMonth.Size = new System.Drawing.Size(638, 89);
            this.gboxMonth.TabIndex = 26;
            this.gboxMonth.TabStop = false;
            this.gboxMonth.Text = "Monthly Observation Controls";
            // 
            // btnMonthGraphs
            // 
            this.btnMonthGraphs.Location = new System.Drawing.Point(236, 25);
            this.btnMonthGraphs.Name = "btnMonthGraphs";
            this.btnMonthGraphs.Size = new System.Drawing.Size(109, 48);
            this.btnMonthGraphs.TabIndex = 25;
            this.btnMonthGraphs.Text = "Monthly Observations Graphical Analysis";
            this.btnMonthGraphs.UseVisualStyleBackColor = true;
            this.btnMonthGraphs.Click += new System.EventHandler(this.btnMonthGraphs_Click);
            // 
            // txtSearchLocation
            // 
            this.txtSearchLocation.Location = new System.Drawing.Point(130, 251);
            this.txtSearchLocation.Name = "txtSearchLocation";
            this.txtSearchLocation.Size = new System.Drawing.Size(234, 20);
            this.txtSearchLocation.TabIndex = 27;
            this.txtSearchLocation.TextChanged += new System.EventHandler(this.txtSearchLocation_TextChanged);
            // 
            // lblLocationSearchStatus
            // 
            this.lblLocationSearchStatus.AutoSize = true;
            this.lblLocationSearchStatus.Location = new System.Drawing.Point(370, 254);
            this.lblLocationSearchStatus.Name = "lblLocationSearchStatus";
            this.lblLocationSearchStatus.Size = new System.Drawing.Size(49, 13);
            this.lblLocationSearchStatus.TabIndex = 28;
            this.lblLocationSearchStatus.Text = "<Result>";
            // 
            // btnNextFoundLocation
            // 
            this.btnNextFoundLocation.Enabled = false;
            this.btnNextFoundLocation.Location = new System.Drawing.Point(482, 248);
            this.btnNextFoundLocation.Name = "btnNextFoundLocation";
            this.btnNextFoundLocation.Size = new System.Drawing.Size(81, 23);
            this.btnNextFoundLocation.TabIndex = 29;
            this.btnNextFoundLocation.Text = "Next Result";
            this.btnNextFoundLocation.UseVisualStyleBackColor = true;
            this.btnNextFoundLocation.Click += new System.EventHandler(this.btnNextFoundLocation_Click);
            // 
            // btnClearLocationSearch
            // 
            this.btnClearLocationSearch.Location = new System.Drawing.Point(569, 248);
            this.btnClearLocationSearch.Name = "btnClearLocationSearch";
            this.btnClearLocationSearch.Size = new System.Drawing.Size(81, 23);
            this.btnClearLocationSearch.TabIndex = 30;
            this.btnClearLocationSearch.Text = "Clear Search";
            this.btnClearLocationSearch.UseVisualStyleBackColor = true;
            this.btnClearLocationSearch.Click += new System.EventHandler(this.btnClearLocationSearch_Click);
            // 
            // btnClearYearSearch
            // 
            this.btnClearYearSearch.Location = new System.Drawing.Point(569, 651);
            this.btnClearYearSearch.Name = "btnClearYearSearch";
            this.btnClearYearSearch.Size = new System.Drawing.Size(81, 23);
            this.btnClearYearSearch.TabIndex = 32;
            this.btnClearYearSearch.Text = "Clear Search";
            this.btnClearYearSearch.UseVisualStyleBackColor = true;
            this.btnClearYearSearch.Click += new System.EventHandler(this.btnClearYearSearch_Click);
            // 
            // btnNextFoundYear
            // 
            this.btnNextFoundYear.Enabled = false;
            this.btnNextFoundYear.Location = new System.Drawing.Point(482, 651);
            this.btnNextFoundYear.Name = "btnNextFoundYear";
            this.btnNextFoundYear.Size = new System.Drawing.Size(81, 23);
            this.btnNextFoundYear.TabIndex = 31;
            this.btnNextFoundYear.Text = "Next Result";
            this.btnNextFoundYear.UseVisualStyleBackColor = true;
            this.btnNextFoundYear.Click += new System.EventHandler(this.btnNextFoundYear_Click);
            // 
            // lblYearSearchStatus
            // 
            this.lblYearSearchStatus.AutoSize = true;
            this.lblYearSearchStatus.Location = new System.Drawing.Point(219, 658);
            this.lblYearSearchStatus.Name = "lblYearSearchStatus";
            this.lblYearSearchStatus.Size = new System.Drawing.Size(49, 13);
            this.lblYearSearchStatus.TabIndex = 33;
            this.lblYearSearchStatus.Text = "<Result>";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 855);
            this.Controls.Add(this.lblYearSearchStatus);
            this.Controls.Add(this.btnClearYearSearch);
            this.Controls.Add(this.btnNextFoundYear);
            this.Controls.Add(this.btnClearLocationSearch);
            this.Controls.Add(this.btnNextFoundLocation);
            this.Controls.Add(this.lblLocationSearchStatus);
            this.Controls.Add(this.txtSearchLocation);
            this.Controls.Add(this.gboxAdminControls);
            this.Controls.Add(this.gboxYearDetails);
            this.Controls.Add(this.txtSearchYear);
            this.Controls.Add(this.lblSearchYear);
            this.Controls.Add(this.lblSearchLocation);
            this.Controls.Add(this.gboxLocation);
            this.Controls.Add(this.dgdMonthlyObservations);
            this.Controls.Add(this.lstYear);
            this.Controls.Add(this.lstLocation);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblLocations);
            this.Controls.Add(this.lblLocationYears);
            this.Controls.Add(this.gboxMonth);
            this.Name = "frmMain";
            this.Text = "MET Office Climate Observations";
            ((System.ComponentModel.ISupportInitialize)(this.dgdMonthlyObservations)).EndInit();
            this.gboxLocation.ResumeLayout(false);
            this.gboxLocation.PerformLayout();
            this.gboxYearDetails.ResumeLayout(false);
            this.gboxYearDetails.PerformLayout();
            this.gboxAdminControls.ResumeLayout(false);
            this.gboxMonth.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocationYears;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ListBox lstLocation;
        private System.Windows.Forms.ListBox lstYear;
        private System.Windows.Forms.Button btnSaveLocationChanges;
        private System.Windows.Forms.Button btnAddNewLocation;
        private System.Windows.Forms.Button btnSaveYearChanges;
        private System.Windows.Forms.Button btnAddNewYear;
        private System.Windows.Forms.Button btnClearYearFields;
        private System.Windows.Forms.DataGridView dgdMonthlyObservations;
        private System.Windows.Forms.Button btnPopulateCells;
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
        private System.Windows.Forms.Button btnSaveAllChangesToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gboxMonth;
        private System.Windows.Forms.TextBox txtSearchLocation;
        private System.Windows.Forms.Label lblLocationSearchStatus;
        private System.Windows.Forms.Button btnNextFoundLocation;
        private System.Windows.Forms.Button btnClearLocationSearch;
        private System.Windows.Forms.Button btnClearYearSearch;
        private System.Windows.Forms.Button btnNextFoundYear;
        private System.Windows.Forms.Label lblYearSearchStatus;
        private System.Windows.Forms.Button btnSaveToNewFile;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label lblFileDirectory;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearAllData;
        private System.Windows.Forms.Button btnMonthGraphs;
    }
}

