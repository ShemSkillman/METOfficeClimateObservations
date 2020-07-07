using System;
using System.Windows.Forms;
using System.IO;
using METOfficeClimateObservations.MVC;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace METOfficeClimateObservations
{
    public partial class frmMain : Form
    {
        ControllerMain cm;

        // Store temp search results
        List<int> locResults;
        int locCurrentSearchIndex = 0;
        List<int> yearResults;
        int yearCurrentSearchIndex = 0;

        public frmMain()
        {
            InitializeComponent();
            cm = new ControllerMain();

            lblFileDirectory.Text = "File Directory: " + cm.FileName;

            LoadData();
        }

        // Loads data read from file to display
        private void LoadData()
        {
            // Clear search labels
            lblYearSearchStatus.Text = "";
            lblLocationSearchStatus.Text = "";

            DisplayLocationDetails();
            GenerateMonthsDataGrid();

            // Selected first location
            if (cm.Locations != null) lstLocation.SelectedIndex = 0;
            else ClearAll();
        }

        // Lists location details
        private void DisplayLocationDetails()
        {
            lstLocation.Items.Clear();

            if (cm.Locations == null) return;
            lstLocation.Items.AddRange(cm.LocationDetails);          
        }

        private void lstLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLocDisplayForSelectedLoc();
        }

        // Updates display when location selected
        private void UpdateLocDisplayForSelectedLoc()
        {
            AutofillLocationTextBoxes();
            DisplayYearDetails();

            // Check locations available
            if (lstLocation.SelectedIndex != -1)
            {
                // Enables save edits, delete location, and displays year details 
                btnSaveLocationChanges.Enabled = true;
                btnDeleteLocation.Enabled = true;
                ChangeYearAccessibility(true);

                UpdateYearDisplayForSelectedLocation();
            }
            // Otherwise can only create location
            else
            {
                ClearLocationFields();
                btnSaveLocationChanges.Enabled = false;
                btnDeleteLocation.Enabled = false;
                ChangeMonthlyObservationAccessiblity(false);
                ClearYearFields();
                ClearDataGrid();
                ChangeYearAccessibility(false);
            }
        }

        // Updates display based on year data for selected location
        private void UpdateYearDisplayForSelectedLocation()
        {            
            // Check years available
            if (cm.Locations[lstLocation.SelectedIndex].Years != null &&
                cm.Locations[lstLocation.SelectedIndex].Years.Count > 0)
            {
                // Select first year
                lstYear.SelectedIndex = 0;

                // Enable search
                txtSearchYear.Enabled = true;
                btnClearYearSearch.Enabled = true;
            }
            else
            {
                // Disable search
                btnSaveYearChanges.Enabled = false;
                btnDeleteYear.Enabled = false;

                ClearYearFields();
                ClearDataGrid();

                // Disable month obs panel
                ChangeMonthlyObservationAccessiblity(false);

                // Disable search
                txtSearchYear.Enabled = false;
                btnClearYearSearch.Enabled = false;
            }
        }

        // Displays selected location details 
        private void AutofillLocationTextBoxes()
        {
            if (lstLocation.SelectedIndex > -1)
            {
                Location temp = cm.Locations[lstLocation.SelectedIndex];

                txtLocationName.Text = temp.LocationName;
                txtStreetNumAndName.Text = temp.StreetNumAndName;
                txtCounty.Text = temp.County;
                txtPostCode.Text = temp.PostCode;
                txtLatitude.Text = temp.Latitude.ToString();
                txtLongitude.Text = temp.Longitude.ToString();
            }
        }

        private void btnClearLocationFields_Click(object sender, EventArgs e)
        {
            ClearLocationFields();
        }

        private void ClearLocationFields()
        {
            txtLocationName.Text = "";
            txtStreetNumAndName.Text = "";
            txtCounty.Text = "";
            txtPostCode.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
        }

        private void btnSaveLocationChanges_Click(object sender, EventArgs e)
        {
            if (lstLocation.SelectedIndex < 0) return;

            // Check all location fields contain input
            if (string.IsNullOrWhiteSpace(txtLocationName.Text) || string.IsNullOrWhiteSpace(txtStreetNumAndName.Text) || string.IsNullOrWhiteSpace(txtCounty.Text)
            || string.IsNullOrWhiteSpace(txtPostCode.Text) || string.IsNullOrWhiteSpace(txtLatitude.Text) || string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                MessageBox.Show("Please fill in all text boxes to edit the location");
                return;
            }

            try
            {
                cm.EditExistingLocation(lstLocation.SelectedIndex, txtLocationName.Text, txtStreetNumAndName.Text, txtCounty.Text, txtPostCode.Text,
                    txtLatitude.Text, txtLongitude.Text);           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nNo changes to " + txtLocationName.Text + " were saved!");
                return;
            }

            // Maintain user selection
            int locIndex = lstLocation.SelectedIndex;
            int yearIndex = lstYear.SelectedIndex;

            UpdateListsAndClearSearch();

            lstLocation.SelectedIndex = locIndex;
            lstYear.SelectedIndex = yearIndex;

            MessageBox.Show("All changes to " + txtLocationName.Text + " successfully saved!");
        }

        private void DisplayYearDetails()
        {
            lstYear.Items.Clear();

            // Check years available
            if (lstLocation.SelectedIndex > -1 && cm.Locations[lstLocation.SelectedIndex].Years != null)
            {
                Location selectedLoc = cm.Locations[lstLocation.SelectedIndex];

                //gets year details of each year and displays it on the list to the user
                foreach (Year theYear in selectedLoc.Years)
                {
                    lstYear.Items.Add(string.Format("{0} Description: {1}",
                        theYear.YearDate, theYear.YearDesc));
                }           
            }                  
        }

        // Display selected year details
        private void AutofillYearTextBoxes()
        {
            if (lstYear.SelectedIndex > -1)
            {
                Year selectedYear = cm.Locations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];

                txtYearDate.Text = selectedYear.YearDate.ToString();
                txtYearDescription.Text = selectedYear.YearDesc;
            }            
        }

        private void lstYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplayForSelectedYear();
        }

        // Updates display based on whether year is selected
        private void UpdateDisplayForSelectedYear()
        {
            AutofillYearTextBoxes();
            DisplayMonthlyObservationDetails();

            // Check year selected
            if (lstYear.SelectedIndex != -1)
            {
                // Can edit, delete years, view monthly obs
                btnSaveYearChanges.Enabled = true;
                btnDeleteYear.Enabled = true; 
                ChangeMonthlyObservationAccessiblity(true);

                // Disable graphs if no months data
                if (cm.Locations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].MonthObs == null)
                    btnMonthGraphs.Enabled = false;


            }
            // Otherwise can only add new years
            else
            {
                btnSaveYearChanges.Enabled = false;
                btnDeleteYear.Enabled = false;
                ClearYearFields();
                ClearDataGrid();
                ChangeMonthlyObservationAccessiblity(false);
            }
        }

        private void btnClearYearFields_Click(object sender, EventArgs e)
        {
            ClearYearFields();
        }

        private void ClearYearFields()
        {
            txtYearDate.Text = "";
            txtYearDescription.Text = "";
        }        

        private void btnAddNewLocation_Click(object sender, EventArgs e)
        {
            AddNewLocation();
        }

        private void AddNewLocation()
        {
            if (string.IsNullOrWhiteSpace(txtLocationName.Text) || string.IsNullOrWhiteSpace(txtStreetNumAndName.Text) || string.IsNullOrWhiteSpace(txtCounty.Text)
                               || string.IsNullOrWhiteSpace(txtPostCode.Text) || string.IsNullOrWhiteSpace(txtLatitude.Text) || string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                MessageBox.Show("Please fill in all the text boxes to create a new location");
                return;
            }

            try
            {
                cm.SaveNewLocation(txtLocationName.Text, txtStreetNumAndName.Text, txtCounty.Text, txtPostCode.Text,
                    txtLatitude.Text, txtLongitude.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("New location " + txtLocationName.Text + " successfully created!");

            UpdateListsAndClearSearch();

            // Selected created location
            lstLocation.SelectedIndex = lstLocation.Items.Count - 1;
        }

        private void btnAddNewYear_Click(object sender, EventArgs e)
        {
            AddNewYear();
        }

        private void AddNewYear()
        {
            if (string.IsNullOrWhiteSpace(txtYearDate.Text) || string.IsNullOrWhiteSpace(txtYearDescription.Text))
            {
                MessageBox.Show("Please fill in all text boxes to create a new year");
                return;
            }

            try
            {
                cm.SaveNewYear(lstLocation.SelectedIndex, txtYearDate.Text, txtYearDescription.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Maintain location selection
            int locIndex = lstLocation.SelectedIndex;

            UpdateListsAndClearSearch();

            lstLocation.SelectedIndex = locIndex;

            // Selects new year
            lstYear.SelectedIndex = lstYear.Items.Count - 1;

            MessageBox.Show("New year " + txtYearDate.Text + " successfully created!");
        }

        private void btnSaveYearChanges_Click(object sender, EventArgs e)
        {
            EditSelectedYear();
        }

        private void EditSelectedYear()
        {
            if (lstYear.SelectedIndex < 0) return;
            if (string.IsNullOrWhiteSpace(txtYearDate.Text) || string.IsNullOrWhiteSpace(txtYearDescription.Text))
            {
                MessageBox.Show("Please fill in all text boxes to edit the year");
                return;
            }

            try
            {
                cm.EditExistingYear(lstLocation.SelectedIndex, lstYear.SelectedIndex, txtYearDate.Text, txtYearDescription.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nNo changes were saved!");
                return;
            }

            // Maintain user selection
            int locIndex = lstLocation.SelectedIndex;
            int yearIndex = lstYear.SelectedIndex;

            UpdateListsAndClearSearch();

            lstLocation.SelectedIndex = locIndex;
            lstYear.SelectedIndex = yearIndex;

            MessageBox.Show("All changes to year " + txtYearDate.Text + " successfully saved!");
        }

        // Display monthly obs data of selected year
        private void DisplayMonthlyObservationDetails()
        {
            if (lstYear.SelectedIndex < 0) return;
            
            Year selectedYear = cm.Locations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];
            Month[] monthsOfYear = selectedYear.MonthObs;

            // Check year has monthly obs
            if (monthsOfYear != null)
            {
                for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
                {
                    dgdMonthObs[0, i].Value = monthsOfYear[i].MonthID;
                    dgdMonthObs[1, i].Value = monthsOfYear[i].MaxTemp;
                    dgdMonthObs[2, i].Value = monthsOfYear[i].MinTemp;
                    dgdMonthObs[3, i].Value = monthsOfYear[i].NumDaysAirFrost;
                    dgdMonthObs[4, i].Value = monthsOfYear[i].MillimetresRainfall;
                    dgdMonthObs[5, i].Value = monthsOfYear[i].NumHoursSunshine;
                }
            }
            // Display no mothly obs
            else
            {
                ClearDataGrid();
            }            
        }

        private void UpdateListsAndClearSearch()
        {
            DisplayYearDetails();
            DisplayLocationDetails();

            txtSearchLocation.Text = "";
            txtSearchYear.Text = "";
        }

        private void GenerateMonthsDataGrid()
        {
            dgdMonthObs.RowCount = cm.MonthNames.Length;
            dgdMonthObs.ColumnCount = cm.MonthData.Length;

            for (int i = 0; i < dgdMonthObs.Columns.Count; i++)
            {
                dgdMonthObs.Columns[i].HeaderText = cm.MonthData[i];
            }

            for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
            {
                dgdMonthObs.Rows[i].HeaderCell.Value = cm.MonthNames[i];
            }
        }

        private void btnClearMonthFields_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void ClearDataGrid()
        {
            for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
            {
                for (int j = 0; j < dgdMonthObs.Columns.Count; j++)
                {
                    dgdMonthObs[j, i].Value = "";
                }
            }
        }

        private void btnSaveMonthChanges_Click(object sender, EventArgs e)
        {
            SaveMonthChanges();
        }

        // Save all data in monthly obs grid 
        private void SaveMonthChanges()
        {
            for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
            {
                for (int j = 0; j < dgdMonthObs.Columns.Count; j++)
                {
                    if (dgdMonthObs[j, i].Value == null || dgdMonthObs[j, i].Value.ToString() == "")
                    {
                        MessageBox.Show("Please fill in all blank spaces in the Monthly Observations data grid.");
                        return;
                    }
                }
            }

            Month[] allMonths = new Month[dgdMonthObs.Rows.Count];

            try
            {
                for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
                {
                    string monthID = dgdMonthObs[0, i].Value.ToString();
                    string maxTemp = dgdMonthObs[1, i].Value.ToString();
                    string minTemp = dgdMonthObs[2, i].Value.ToString();
                    string numDaysAirFrost = dgdMonthObs[3, i].Value.ToString();
                    string millimetresOfRainfall = dgdMonthObs[4, i].Value.ToString();
                    string numHoursOfSunshine = dgdMonthObs[5, i].Value.ToString();

                    allMonths[i] = new Month(monthID, maxTemp, minTemp, numDaysAirFrost, millimetresOfRainfall, numHoursOfSunshine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nNo changes to monthly observations were saved!");
                return;
            }

            cm.SaveMonths(lstLocation.SelectedIndex, lstYear.SelectedIndex, allMonths);

            ChangeMonthlyObservationAccessiblity(true);

            MessageBox.Show("All changes to Monthly Observations successfully saved!");
        }

        private void btnPopulateFields_Click(object sender, EventArgs e)
        {
            GenerateMonthData();
        }

        // Generated data is purely random for testing purposes
        private void GenerateMonthData()
        {
            Random rand = new Random();

            for (int i = 0; i < dgdMonthObs.Rows.Count; i++)
            {
                dgdMonthObs[0, i].Value = i + 1;
                dgdMonthObs[1, i].Value = rand.Next(10, 24);
                dgdMonthObs[2, i].Value = rand.Next(-5, 9);
                dgdMonthObs[3, i].Value = rand.Next(0, 20);
                dgdMonthObs[4, i].Value = rand.Next(0, 200);
                dgdMonthObs[5, i].Value = rand.Next(0, 300);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Changes user ability to interact with year section of the form
        private void ChangeYearAccessibility(bool isEnabled)
        {
            gboxYearDetails.Enabled = isEnabled;
            lstYear.Enabled = isEnabled;
            txtSearchYear.Enabled = isEnabled;
            btnClearYearSearch.Enabled = isEnabled;
        }

        // Changes user ability to interact with monthly observations section of the form
        private void ChangeMonthlyObservationAccessiblity(bool isEnabled)
        {
            btnMonthGraphs.Enabled = isEnabled;
            gboxMonth.Enabled = isEnabled;
            dgdMonthObs.Enabled = isEnabled;            
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            DeleteSelectedLocation();
        }

        private void DeleteSelectedLocation()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete " + cm.Locations[lstLocation.SelectedIndex].LocationName + "?", "Warning!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                cm.DeleteLocation(lstLocation.SelectedIndex);

                lstLocation.SelectedIndex = -1;

                UpdateListsAndClearSearch();
            }
        }

        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            DeleteSelectedYear();
        }

        private void DeleteSelectedYear()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete year " +
                            cm.Locations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].YearDate + "?", "Warning!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                cm.DeleteYear(lstLocation.SelectedIndex, lstYear.SelectedIndex);

                // Maintain location selection
                int currentLocationIndex = lstLocation.SelectedIndex;

                UpdateListsAndClearSearch();

                lstLocation.SelectedIndex = currentLocationIndex;

                lstYear.SelectedIndex = -1;
            }
        }

        private void btnSaveAllChangesToFile_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            try
            {
                cm.WriteFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Saved to file successfully!");
        }

        private void txtSearchLocation_TextChanged(object sender, EventArgs e)
        {
            SearchLocation();
        }

        // Searches for location when user types into search bar
        private void SearchLocation()
        {
            string search = txtSearchLocation.Text.ToUpper();

            // Check for input
            if (search == "")
            {
                lblLocationSearchStatus.Text = "";
                btnNextFoundLocation.Enabled = false;
                return;
            }

            locResults = cm.SearchLocation(search);
            locCurrentSearchIndex = 0;

            // Check results
            if (locResults.Count > 0)
            {
                lstLocation.SelectedIndex = locResults[0];
                lblLocationSearchStatus.Text = string.Format("({0}) results found!", locResults.Count);
                btnNextFoundLocation.Enabled = true;
            }
            // No results
            else
            {
                lstLocation.SelectedIndex = -1;
                lblLocationSearchStatus.Text = "No results!";
                btnNextFoundLocation.Enabled = false;
            }
        }

        private void btnNextFoundLocation_Click(object sender, EventArgs e)
        {
            GoToNextFoundLocation();
        }

        // Iterates to next location result found from search
        private void GoToNextFoundLocation()
        {
            try
            {
                lstLocation.SelectedIndex = locResults[++locCurrentSearchIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                locCurrentSearchIndex = 0;
                lstLocation.SelectedIndex = locResults[locCurrentSearchIndex];
            }
        }

        private void btnNextFoundYear_Click(object sender, EventArgs e)
        {
            GoToNextFoundYear();
        }

        // Iterates to next year result found from search
        private void GoToNextFoundYear()
        {
            try
            {
                lstYear.SelectedIndex = yearResults[++yearCurrentSearchIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                yearCurrentSearchIndex = 0;
                lstYear.SelectedIndex = yearResults[yearCurrentSearchIndex];
            }
        }

        private void txtSearchYear_TextChanged(object sender, EventArgs e)
        {
            SearchYear();
        }

        // Searches for year when user types into search bar
        private void SearchYear()
        {
            string search = txtSearchYear.Text.ToUpper();

            yearResults = cm.SearchYear(lstLocation.SelectedIndex, search);
            yearCurrentSearchIndex = 0;

            if (search == "")
            {
                lblYearSearchStatus.Text = "";
                btnNextFoundYear.Enabled = false;
                return;
            }

            if (yearResults.Count > 0)
            {
                lstYear.SelectedIndex = yearResults[yearCurrentSearchIndex];
                lblYearSearchStatus.Text = string.Format("({0}) results found!", yearResults.Count);
                btnNextFoundYear.Enabled = true;
            }
            else
            {
                lstYear.SelectedIndex = -1;
                lblYearSearchStatus.Text = "No results!";
                btnNextFoundYear.Enabled = false;
            }
        }

        private void btnClearLocationSearch_Click(object sender, EventArgs e)
        {
            txtSearchLocation.Text = "";
        }

        private void btnClearYearSearch_Click(object sender, EventArgs e)
        {
            txtSearchYear.Text = "";
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadFromOtherFile();
        }

        private void LoadFromOtherFile()
        {
            try
            {
                cm.FileName = GetFileDirectory();
                cm.ReadFile();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LoadData();
                return;
            }
        }

        private void btnChangeSaveFileDirectory_Click(object sender, EventArgs e)
        {
            SaveToOtherFile();
        }

        private void SaveToOtherFile()
        {
            try
            {
                cm.FileName = GetFileDirectory();
                cm.WriteFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nCould not save to new file!");
                return;
            }

            MessageBox.Show("Saved to file " + cm.FileName);
        }

        // Opens dialog box for user to select file directory
        private string GetFileDirectory()
        {
            try
            {
                openFileDialog.Title = "Please select .txt file";
                openFileDialog.ShowDialog();

                lblFileDirectory.Text = "File Directory: " + openFileDialog.FileName;
                return openFileDialog.FileName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void btnMonthGraphs_Click(object sender, EventArgs e)
        {
            ShowMonthlyObsGraphs();
        }

        // Opens seperate window
        private void ShowMonthlyObsGraphs()
        {
            Location location = cm.Locations[lstLocation.SelectedIndex];
            int currentYearIndex = lstYear.SelectedIndex;
            ViewGraphs tempFrmGraphs = new ViewGraphs(location, currentYearIndex, cm.MonthNames);
            tempFrmGraphs.Show();
        }

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            //Clears data in data class and clears all displays
            cm.ClearData();
            ClearDataGrid();
            ClearLocationFields();
            lstLocation.Items.Clear();
            lstYear.Items.Clear();
            ClearYearFields();

            //user can only add a location
            btnSaveLocationChanges.Enabled = false;
            btnDeleteLocation.Enabled = false;
            ChangeYearAccessibility(false);
            ChangeMonthlyObservationAccessiblity(false);
        }
    }
}
