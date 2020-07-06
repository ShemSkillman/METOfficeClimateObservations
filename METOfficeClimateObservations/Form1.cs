using System;
using System.Windows.Forms;
using System.IO;

namespace METOfficeClimateObservations
{
    public partial class frmMain : Form
    {
        //Month observations grid dimensions
        const int numOfRows = 12, numOfCols = 6;
        
        //Store temp search results
        int[] locResults;
        int locCurrentSearchIndex = 0;
        int[] yearResults;
        int yearCurrentSearchIndex = 0;

        Random rand;

        //Located in \Debug\bin
        string fileName = "inputEXTENDED.txt";        
        
        public frmMain()
        {
            InitializeComponent();
            rand = new Random();

            //Clear search labels
            lblYearSearchStatus.Text = "";
            lblLocationSearchStatus.Text = "";

            GenerateMonthsDataGrid();
            LoadData();
        }

        private void LoadData()
        {
            //if the file name is null then the file cannot be found and therefore it is not loaded into the program
            if (fileName != null)
            {
                ReadFile();
                //displays current file name diretory to the user
                lblFileDirectory.Text = "File Directory: " + fileName;

                //Displays locations read from the file and any other year or monthly observation data 
                DisplayLocationDetails();
            }

            //if there are locations read from the file then the first one can be automatically selected on the list
            if (Data.storedLocations != null)
            {
                lstLocation.SelectedIndex = 0;
            }
            else
            {
                //if there are no locations then most controls on the form as disabled except for adding a new location
                ClearAll();
            }
        }

        private void ReadFile()
        {
            //Variables to be filled when the file is read line by line
            string locationName, streetNumAndName, county, postCode, latitude, longitude;
            string yearDescription, year;
            string monthID, maxTemp, minTemp, numDaysAirFrost, monthRainfallMillimetres, monthHoursSunshine;

            //Number of locations and number of years within each location stored to determine number of for loop cycles
            int numYears, numLocations, numMonths = 12;

            try
            {
                //Input stream created to get information from file to the application
                StreamReader inputStream = new StreamReader(fileName);

                //Number of locations read at the top of the file
                numLocations = Convert.ToInt32(inputStream.ReadLine());

                //Array of locations in Data class created if 1 or more locations in the file
                if (numLocations > 0)
                {
                    Data.storedLocations = new Location[1];
                }
                else
                {
                    //if the number of locations is 0 then the file is not loaded and the user is notified
                    MessageBox.Show("There are no locations in the file " + fileName);
                    inputStream.Close();
                    Data.storedLocations = null;
                    return;
                }

                //for loop cycles through every location in the file
                for (int i = 0; i < numLocations; i++)
                {
                    //All location details collected temporarily in variables
                    locationName = inputStream.ReadLine();
                    streetNumAndName = inputStream.ReadLine();
                    county = inputStream.ReadLine();
                    postCode = inputStream.ReadLine();
                    latitude = inputStream.ReadLine();
                    longitude = inputStream.ReadLine();

                    //Number of years read from file
                    numYears = Convert.ToInt32(inputStream.ReadLine());

                    //Location object created and location details set by inputing the variables as arguments in the constructor
                    Location newLocation = new Location(locationName, streetNumAndName, county, postCode, latitude, longitude);

                    //Years array initialised and created 
                    Year[] years = new Year[1];

                    //for loop cycles through every year of the location in the file
                    for (int j = 0; j < numYears; j++)
                    {
                        //All year details collected temporarily in variables
                        yearDescription = inputStream.ReadLine();
                        year = inputStream.ReadLine();

                        //Year object created and year details set
                        Year newYear = new Year(year, yearDescription);

                        //Months array initialised and created
                        Month[] months = new Month[1];
                        
                        //for loop cycles through every month in the year of the location in the file
                        for (int k = 0; k < numMonths; k++)
                        {
                            //All month details collected temporarily in variables
                            monthID = inputStream.ReadLine();
                            maxTemp = inputStream.ReadLine();
                            minTemp = inputStream.ReadLine();
                            numDaysAirFrost = inputStream.ReadLine(); 
                            monthRainfallMillimetres = inputStream.ReadLine(); 
                            monthHoursSunshine = inputStream.ReadLine();

                            //Last month (month ID = 12) in the file does not have year assigned to it so skip reading the year
                            if (k != numMonths - 1)
                            {
                                year = inputStream.ReadLine();
                            }                            

                            //Month object created and month details set
                            Month newMonth = new Month(monthID, maxTemp, minTemp, numDaysAirFrost, monthRainfallMillimetres, monthHoursSunshine);
                            
                            //Months array length increased by one so that another month can be added in the next iteration
                            Array.Resize(ref months, months.Length + 1);
                            //Stores month in appropriate position of the months array
                            months[k] = newMonth;
                        }

                        //When all months have been added to the months array the array length is decreased by one because no more months will be added
                        //This is done to prevent a null reference exception
                        Array.Resize(ref months, months.Length - 1);

                        //Months array assigned to monthly observations array in the year instance
                        newYear.MonthlyObservations = months;

                        //Years array length increased by one so that another year can be added in the next iteration
                        Array.Resize(ref years, years.Length + 1);
                        //Stores year in appropriate position of the years array
                        years[j] = newYear;
                        
                    }

                    //Prevents null reference exception
                    Array.Resize(ref years, years.Length - 1);

                    //Years array assigned to years array in the location instance
                    newLocation.Years = years;

                    //Stored locations array increased by one so that another location can be added in the next iteration
                    Array.Resize(ref Data.storedLocations, Data.storedLocations.Length + 1);
                    //Stores location instance in appropriate position of the stored locations array in the data class
                    Data.storedLocations[i] = newLocation;
                }

                //Prevents null reference exception
                Array.Resize(ref Data.storedLocations, Data.storedLocations.Length - 1);

                inputStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            
        }        

        private void DisplayLocationDetails()
        {
            lstLocation.Items.Clear();

            //No location details printed if the stored locations array is null
            if (Data.storedLocations != null)
            {

                //Prints location details of each location to display to the user
                foreach (Location loc in Data.storedLocations)
                {
                    lstLocation.Items.Add(string.Format("{0} Address: {1}, {2} Postcode: {3} Longitude: {4} Latitude: {5}",
                        loc.LocationName, loc.StreetNumberAndName, loc.County, loc.PostCode, loc.GetLongitude(), loc.GetLatitude()));
                }
            }
            
        }

        private void lstLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutofillLocationTextBoxes();
            DisplayYearDetails();            
            
            if (lstLocation.SelectedIndex != -1)
            {                          
                //enables user to save edits, delete location, and access year details associated with the selected location
                //only permitted if the user has selected a location from the list
                btnSaveLocationChanges.Enabled = true;
                btnDeleteLocation.Enabled = true;
                ChangeYearAccessibility(true);
                
                if (Data.storedLocations[lstLocation.SelectedIndex].Years != null &&
                    Data.storedLocations[lstLocation.SelectedIndex].Years.Length > 0)
                {
                    //if the location has year data then the first entry is automatically selected
                    lstYear.SelectedIndex = 0;

                    //User can also search for years since there is year data
                    txtSearchYear.Enabled = true;
                    btnClearYearSearch.Enabled = true;
                }
                else
                {
                    //if there is no year data then the user cannot edit or delete years since there are none present
                    btnSaveYearChanges.Enabled = false;
                    btnDeleteYear.Enabled = false;
                    
                    ClearYearFields();
                    ClearDataGrid();

                    //User cannot access month details because there is no year data to store monthly observations
                    ChangeMonthlyObservationAccessiblity(false);

                    //Search disabled because there is no year data
                    txtSearchYear.Enabled = false;
                    btnClearYearSearch.Enabled = false;
                }

            }
            else
            {
                //if there is no location selected everything becomes disabled except for adding a new location
                ClearLocationFields();
                btnSaveLocationChanges.Enabled = false;
                btnDeleteLocation.Enabled = false;
                ChangeMonthlyObservationAccessiblity(false);
                ClearYearFields();
                ClearDataGrid();
                ChangeYearAccessibility(false);
            }
        }

        private void AutofillLocationTextBoxes()
        {
            //if a location is selected then the location details are filled out in the text boxes automatically for the user
            if (lstLocation.SelectedIndex > -1)
            {

                //location reference stored in variable and location fields filled out with location details
                Location tempLocation = Data.storedLocations[lstLocation.SelectedIndex];

                txtLocationName.Text = tempLocation.LocationName;
                txtStreetNumAndName.Text = tempLocation.StreetNumberAndName;
                txtCounty.Text = tempLocation.County;
                txtPostCode.Text = tempLocation.PostCode;
                txtLatitude.Text = tempLocation.GetLatitude().ToString();
                txtLongitude.Text = tempLocation.GetLongitude().ToString();
            }
        }

        private void btnClearLocationFields_Click(object sender, EventArgs e)
        {
            ClearLocationFields();
        }

        private void ClearLocationFields()
        {
            //Replaces all text in location fields with empty strings  
            txtLocationName.Text = "";
            txtStreetNumAndName.Text = "";
            txtCounty.Text = "";
            txtPostCode.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
        }

        private void btnSaveLocationChanges_Click(object sender, EventArgs e)
        {

            if (lstLocation.SelectedIndex > -1)
            {
                if (string.IsNullOrWhiteSpace(txtLocationName.Text) || string.IsNullOrWhiteSpace(txtStreetNumAndName.Text) || string.IsNullOrWhiteSpace(txtCounty.Text)
                || string.IsNullOrWhiteSpace(txtPostCode.Text) || string.IsNullOrWhiteSpace(txtLatitude.Text) || string.IsNullOrWhiteSpace(txtLongitude.Text))
                {
                    MessageBox.Show("Please fill in all text boxes to edit the location");
                    return;
                }

                //Takes values from the location fields and replaces the details in the selected location
                Location loc = Data.storedLocations[lstLocation.SelectedIndex];

                string oldLocName = loc.LocationName;
                string oldStreet = loc.StreetNumberAndName;
                string oldCounty = loc.County;
                string oldPostCode = loc.PostCode;
                float oldLat = loc.GetLatitude();
                float oldLong = loc.GetLongitude();

                loc.LocationName = txtLocationName.Text;                
                loc.StreetNumberAndName = txtStreetNumAndName.Text;
                loc.County = txtCounty.Text;
                loc.PostCode = txtPostCode.Text;
                loc.SetLatitude(txtLatitude.Text);
                loc.SetLongitude(txtLongitude.Text);

                if (loc.IsError)
                {
                    loc.LocationName = oldLocName;
                    loc.StreetNumberAndName = oldStreet;
                    loc.County = oldCounty;
                    loc.PostCode = oldPostCode;
                    loc.SetLatitude(oldLat.ToString());
                    loc.SetLongitude(oldLong.ToString());

                    MessageBox.Show("No changes to " + loc.LocationName + " were saved!");
                }
                else
                {
                    MessageBox.Show("All changes to "  + loc.LocationName + " successfully saved!");

                    //records selected index of location and year so that they can be reselected when the list display is refreshed
                    int locIndex = lstLocation.SelectedIndex;
                    int yearIndex = lstYear.SelectedIndex;

                    UpdateDisplay();

                    lstLocation.SelectedIndex = locIndex;
                    lstYear.SelectedIndex = yearIndex;
                }
                
            }

        }

        private void DisplayYearDetails()
        {

            if (lstLocation.SelectedIndex > -1 && Data.storedLocations[lstLocation.SelectedIndex].Years != null)
            {
                //if a location is selected and the years array of that location is not null 

                lstYear.Items.Clear();

                Location tempLocation = Data.storedLocations[lstLocation.SelectedIndex];

                if (tempLocation.Years != null)
                {
                    //gets year details of each year and displays it on the list to the user
                    foreach (Year theYear in tempLocation.Years)
                    {
                        lstYear.Items.Add(string.Format("{0} Description: {1}",
                            theYear.GetYear(), theYear.YearDescription));
                    }
                }                
            }            
            else
            {
                //clears year list if no location is selected by the user
                lstYear.Items.Clear();
            }
            
        }

        private void AutofillYearTextBoxes()
        {
            //if a year is selected then the year details are automatically filled out into the year text fields
            if (lstYear.SelectedIndex > -1)
            {
                Year tempYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];

                txtYearDate.Text = tempYear.GetYear().ToString();
                txtYearDescription.Text = tempYear.YearDescription;
            }
            
        }

        private void lstYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutofillYearTextBoxes();
            DisplayMonthlyObservationDetails();


            if (lstYear.SelectedIndex != -1)
            {
                //if a year is selected then user can edit or delete the currently selected year
                //the user can also access controls over the monthly observations of that year
                btnSaveYearChanges.Enabled = true;
                btnDeleteYear.Enabled = true;
                ChangeMonthlyObservationAccessiblity(true);
            }
            else
            {
                //if no year selected then the user cannot edit or delete the years and months section of the form is cleared
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
            if (string.IsNullOrWhiteSpace(txtLocationName.Text) || string.IsNullOrWhiteSpace(txtStreetNumAndName.Text) || string.IsNullOrWhiteSpace(txtCounty.Text)
                || string.IsNullOrWhiteSpace(txtPostCode.Text) || string.IsNullOrWhiteSpace(txtLatitude.Text) || string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                MessageBox.Show("Please fill in all the text boxes to create a new location");
                return;
            }

            Location newLocation = new Location(txtLocationName.Text, txtStreetNumAndName.Text, txtCounty.Text, txtPostCode.Text,
                txtLatitude.Text, txtLongitude.Text);

            if (newLocation.IsError)
            {
                //no location saved in data class locations array if any errors occurred when the location instance is created
                return;
            }

            if (Data.storedLocations == null)
            {
                //if the data stored locations array is null then a new array of size 1 is created
                Data.storedLocations = new Location[1];
            }
            else
            {
                //the array size is increased by one to accomodate for another location to be added
                Array.Resize(ref Data.storedLocations, Data.storedLocations.Length + 1);
            }
            
            Data.storedLocations[Data.storedLocations.Length - 1] = newLocation;

            MessageBox.Show("New location " + txtLocationName.Text + " successfully created!");

            UpdateDisplay();
            
            //selects the newly created location at the bottom of the list
            lstLocation.SelectedIndex = Data.storedLocations.Length - 1;
        }

        private void btnAddNewYear_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtYearDate.Text) || string.IsNullOrWhiteSpace(txtYearDescription.Text))
            {
                MessageBox.Show("Please fill in all text boxes to create a new year");
                return;
            }

            Year newYear = new Year(txtYearDate.Text, txtYearDescription.Text);

            if (newYear.IsError)
            {
                //if there is any error when creating the year instance the year does not get saved to the years array
                return;
            }
            
            Location selectedLocation = Data.storedLocations[lstLocation.SelectedIndex];
            Year[] locationYears = selectedLocation.Years;


            if (locationYears == null)
            {
                //if years array of location is null then an array of size 1 is created
                locationYears = new Year[1];
            }
            else
            {
                //array size increased by one to accomodate for a newly added year
                Array.Resize(ref locationYears, locationYears.Length + 1);
            }

            locationYears[locationYears.Length - 1] = newYear;

            selectedLocation.Years = locationYears;
            Data.storedLocations[lstLocation.SelectedIndex] = selectedLocation;

            int locIndex = lstLocation.SelectedIndex;

            MessageBox.Show("New year " + txtYearDate.Text + " successfully created!");

            UpdateDisplay();

            //selects newly created year and currently selected location
            lstLocation.SelectedIndex = locIndex;
            lstYear.SelectedIndex = locationYears.Length - 1;

            GenerateMonthData();
            SaveMonthChanges(false);
        }

        private void btnSaveYearChanges_Click(object sender, EventArgs e)
        {

            if (lstYear.SelectedIndex > -1)
            {
                if (string.IsNullOrWhiteSpace(txtYearDate.Text) || string.IsNullOrWhiteSpace(txtYearDescription.Text))
                {
                    MessageBox.Show("Please fill in all text boxes to edit the year");
                    return;
                }

                //stores reference of year in years array of selected location
                Year editedYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];

                string oldYear = editedYear.GetYear().ToString();
                string oldYearDesc = editedYear.YearDescription;                

                editedYear.SetYear(txtYearDate.Text);
                editedYear.YearDescription = txtYearDescription.Text;

                if (editedYear.IsError)
                {
                    editedYear.SetYear(oldYear);
                    editedYear.YearDescription = oldYearDesc;

                    MessageBox.Show("No changes to year " + editedYear.GetYear().ToString() + " saved!");
                }
                else
                {

                    MessageBox.Show("All changes to year " + editedYear.GetYear().ToString() + " successfully saved!");

                    int locIndex = lstLocation.SelectedIndex;
                    int yearIndex = lstYear.SelectedIndex;

                    UpdateDisplay();

                    lstLocation.SelectedIndex = locIndex;
                    lstYear.SelectedIndex = yearIndex;

                }

            }

        }

        private void DisplayMonthlyObservationDetails()
        {
            if (lstYear.SelectedIndex > -1)
            {
                Year selectedYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];
                Month[] monthsOfYear = selectedYear.MonthlyObservations;

                if (monthsOfYear != null)
                {
                    for (int i = 0; i < numOfRows; i++)
                    {
                        dgdMonthlyObservations[0, i].Value = monthsOfYear[i].GetMonthID();
                        dgdMonthlyObservations[1, i].Value = monthsOfYear[i].GetMaxTemp();
                        dgdMonthlyObservations[2, i].Value = monthsOfYear[i].GetMinTemp();
                        dgdMonthlyObservations[3, i].Value = monthsOfYear[i].GetNumDaysAirFrost();
                        dgdMonthlyObservations[4, i].Value = monthsOfYear[i].GetMillimetresOfRainfall();
                        dgdMonthlyObservations[5, i].Value = monthsOfYear[i].GetNumHoursSunshine();
                    }
                }
                else
                {
                    ClearDataGrid();
                }
            }
            
        }

        private void UpdateDisplay()
        {
            DisplayYearDetails();
            DisplayLocationDetails();

            txtSearchLocation.Text = "";
            txtSearchYear.Text = "";
        }

        private void GenerateMonthsDataGrid()
        {          
            dgdMonthlyObservations.RowCount = numOfRows;
            dgdMonthlyObservations.ColumnCount = numOfCols;

            dgdMonthlyObservations.Columns[0].HeaderText = "Month ID";
            dgdMonthlyObservations.Columns[1].HeaderText = "Maximum Temperature";
            dgdMonthlyObservations.Columns[2].HeaderText = "Minimum Temperature";
            dgdMonthlyObservations.Columns[3].HeaderText = "Number of Days of Air Frost";
            dgdMonthlyObservations.Columns[4].HeaderText = "Millimetres of Rainfall";
            dgdMonthlyObservations.Columns[5].HeaderText = "Number of Hours of Sunshine";

            dgdMonthlyObservations.Rows[0].HeaderCell.Value = "January";
            dgdMonthlyObservations.Rows[1].HeaderCell.Value = "February";
            dgdMonthlyObservations.Rows[2].HeaderCell.Value = "March";
            dgdMonthlyObservations.Rows[3].HeaderCell.Value = "April";
            dgdMonthlyObservations.Rows[4].HeaderCell.Value = "May";
            dgdMonthlyObservations.Rows[5].HeaderCell.Value = "June";
            dgdMonthlyObservations.Rows[6].HeaderCell.Value = "July";
            dgdMonthlyObservations.Rows[7].HeaderCell.Value = "August";
            dgdMonthlyObservations.Rows[8].HeaderCell.Value = "September";
            dgdMonthlyObservations.Rows[9].HeaderCell.Value = "October";
            dgdMonthlyObservations.Rows[10].HeaderCell.Value = "November";
            dgdMonthlyObservations.Rows[11].HeaderCell.Value = "December";
        }

        private void btnClearMonthFields_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void ClearDataGrid()
        {
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    dgdMonthlyObservations[j, i].Value = "";
                }
            }
        }

        private void btnSaveMonthChanges_Click(object sender, EventArgs e)
        {
            SaveMonthChanges(true);
        }

        private void SaveMonthChanges(bool displayCreateMessage)
        {
            Month[] monthsOfYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].MonthlyObservations;


            if (monthsOfYear == null)
            {
                monthsOfYear = new Month[numOfRows];
            }

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    if (dgdMonthlyObservations[j, i].Value == null || dgdMonthlyObservations[j, i].Value.ToString() == "")
                    {
                        MessageBox.Show("Please fill in all blank spaces in the Monthly Observations data grid.");
                        return;
                    }
                }
            }

            try
            {
                for (int i = 0; i < numOfRows; i++)
                {
                    string monthID = dgdMonthlyObservations[0, i].Value.ToString();
                    string maxTemp = dgdMonthlyObservations[1, i].Value.ToString();
                    string minTemp = dgdMonthlyObservations[2, i].Value.ToString();
                    string numDaysAirFrost = dgdMonthlyObservations[3, i].Value.ToString();
                    string millimetresOfRainfall = dgdMonthlyObservations[4, i].Value.ToString();
                    string numHoursOfSunshine = dgdMonthlyObservations[5, i].Value.ToString();

                    Month newMonth = new Month(monthID, maxTemp, minTemp, numDaysAirFrost, millimetresOfRainfall, numHoursOfSunshine);
                    if (newMonth.IsError) return;

                    monthsOfYear[i] = newMonth;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].MonthlyObservations = monthsOfYear;

            if (displayCreateMessage) MessageBox.Show("All changes to Monthly Observations successfully saved!");
        }

        private void btnPopulateFields_Click(object sender, EventArgs e)
        {
            GenerateMonthData();
        }

        private void GenerateMonthData()
        {
            for (int i = 0; i < numOfRows; i++)
            {
                dgdMonthlyObservations[0, i].Value = i + 1;
                dgdMonthlyObservations[1, i].Value = rand.Next(10, 24);
                dgdMonthlyObservations[2, i].Value = rand.Next(-5, 9);
                dgdMonthlyObservations[3, i].Value = rand.Next(0, 20);
                dgdMonthlyObservations[4, i].Value = rand.Next(0, 200);
                dgdMonthlyObservations[5, i].Value = rand.Next(0, 300);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeYearAccessibility(bool isEnabled)
        {
            gboxYearDetails.Enabled = isEnabled;
            lstYear.Enabled = isEnabled;
            txtSearchYear.Enabled = isEnabled;
            btnClearYearSearch.Enabled = isEnabled;
        }

        private void ChangeMonthlyObservationAccessiblity(bool isEnabled)
        {
            gboxMonth.Enabled = isEnabled;
            dgdMonthlyObservations.Enabled = isEnabled;            
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete " + Data.storedLocations[lstLocation.SelectedIndex].LocationName + "?", "Warning!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                Data.storedLocations[lstLocation.SelectedIndex] = null;

                for (int i = lstLocation.SelectedIndex; i < Data.storedLocations.Length - 1; i++)
                {
                    Data.storedLocations[i] = Data.storedLocations[i + 1];
                }

                Array.Resize(ref Data.storedLocations, Data.storedLocations.Length - 1);

                lstLocation.SelectedIndex = -1;

                UpdateDisplay();
            }
        }

        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete year " + 
                Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].GetYear() + "?", "Warning!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                Location selectedLocation = Data.storedLocations[lstLocation.SelectedIndex];

                selectedLocation.Years[lstYear.SelectedIndex] = null;

                for (int i = lstYear.SelectedIndex; i < selectedLocation.Years.Length - 1; i++)
                {
                    selectedLocation.Years[i] = selectedLocation.Years[i + 1];
                }

                Year[] yearsArray = selectedLocation.Years;

                Array.Resize(ref yearsArray, yearsArray.Length - 1);

                if (yearsArray.Length == 0)
                {
                    yearsArray = null;
                }

                Data.storedLocations[lstLocation.SelectedIndex].Years = yearsArray;

                int currentLocationIndex = lstLocation.SelectedIndex;

                UpdateDisplay();

                lstLocation.SelectedIndex = currentLocationIndex;

                lstYear.SelectedIndex = -1;
            }
        }
            

        private void btnSaveAllChangesToFile_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void WriteToFile()
        {
            if (fileName == null)
            {
                MessageBox.Show("There is no file currently loaded!");
                return;
            }

            try
            {                
                StreamWriter outputStream = new StreamWriter(fileName);

                if (Data.storedLocations != null)
                {
                    int numLocations = Data.storedLocations.Length;

                    outputStream.WriteLine(numLocations);

                    foreach (Location loc in Data.storedLocations)
                    {
                        outputStream.WriteLine(loc.LocationName);
                        outputStream.WriteLine(loc.StreetNumberAndName);
                        outputStream.WriteLine(loc.County);
                        outputStream.WriteLine(loc.PostCode);
                        outputStream.WriteLine(loc.GetLatitude());
                        outputStream.WriteLine(loc.GetLongitude());

                        if (loc.Years != null)
                        {
                            outputStream.WriteLine(loc.Years.Length);
                        }
                        else
                        {
                            break;
                        }

                        foreach (Year year in loc.Years)
                        {
                            outputStream.WriteLine(year.YearDescription);
                            outputStream.WriteLine(year.GetYear());

                            for (int i = 0; i < 12; i++)
                            {
                                outputStream.WriteLine(year.MonthlyObservations[i].GetMonthID());
                                outputStream.WriteLine(year.MonthlyObservations[i].GetMaxTemp());
                                outputStream.WriteLine(year.MonthlyObservations[i].GetMinTemp());
                                outputStream.WriteLine(year.MonthlyObservations[i].GetNumDaysAirFrost());
                                outputStream.WriteLine(year.MonthlyObservations[i].GetMillimetresOfRainfall());
                                outputStream.WriteLine(year.MonthlyObservations[i].GetNumHoursSunshine());

                                if (i != 11)
                                {
                                    outputStream.WriteLine(year.GetYear());
                                }

                            }
                        }

                    }

                }

                outputStream.Close();

                MessageBox.Show("All changes have successfully been saved to " + fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void txtSearchLocation_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchLocation.Text.ToUpper();
            
            if (search != "")
            {
                int numChar = search.Length;
                locResults = new int[1];
                bool locationFound = false;
                locCurrentSearchIndex = 0;

                for (int i = 0; i < Data.storedLocations.Length; i++)
                {
                    if (numChar <= Data.storedLocations[i].LocationName.Length)
                    {                        
                        if (Equals(search, Data.storedLocations[i].LocationName.Substring(0, numChar).ToUpper()))
                        {
                            locResults[locResults.Length - 1] = i;
                            Array.Resize(ref locResults, locResults.Length + 1);
                            locationFound = true;
                        }
                    }
                }

                Array.Resize(ref locResults, locResults.Length - 1);

                if (locationFound)
                {
                    lstLocation.SelectedIndex = locResults[0];
                    lblLocationSearchStatus.Text = string.Format("({0}) results found!", locResults.Length);
                    btnNextFoundLocation.Enabled = true;
                }
                else
                {
                    lstLocation.SelectedIndex = -1;
                    lblLocationSearchStatus.Text = "No results!";
                    btnNextFoundLocation.Enabled = false;
                }
            }
            else
            {
                lblLocationSearchStatus.Text = "";
                btnNextFoundLocation.Enabled = false;
            }
            
        }

        private void btnNextFoundLocation_Click(object sender, EventArgs e)
        {
            try
            {
                lstLocation.SelectedIndex = locResults[++locCurrentSearchIndex];
            }
            catch (IndexOutOfRangeException)
            {
                locCurrentSearchIndex = 0;
                lstLocation.SelectedIndex = locResults[locCurrentSearchIndex];
            }
        }
        

        private void btnNextFoundYear_Click(object sender, EventArgs e)
        {
            try
            {
                lstYear.SelectedIndex = yearResults[++yearCurrentSearchIndex];
            }
            catch (IndexOutOfRangeException)
            {
                yearCurrentSearchIndex = 0;
                lstYear.SelectedIndex = yearResults[yearCurrentSearchIndex];
            }
        }

        private void txtSearchYear_TextChanged(object sender, EventArgs e)
        {
            //converts search string to uppercase to ignore uppercase/lowercase comparisons
            string search = txtSearchYear.Text.ToUpper();
            //year results array created to store any results from the year search
            yearResults = new int[1];

            //year found set to false at the beginning 
            bool yearFound = false;
            //current search index set to 0 so that the first found result is selected
            yearCurrentSearchIndex = 0;

            if (search != "")
            {

                int numChar = search.Length;

                //goes through all the years of the selected location
                for (int i = 0; i < Data.storedLocations[lstLocation.SelectedIndex].Years.Length; i++)
                {
                    //the number of characters of the search must be less than the length of the location name
                    //or substring will throw an error
                    if (numChar <= Data.storedLocations[lstLocation.SelectedIndex].Years[i].GetYear().ToString().Length)
                    {
                        //if the exracted substring is the same as the search result then the year is added to the 
                        //results array and the array size is increased by 1 
                        if (Equals(search, Data.storedLocations[lstLocation.SelectedIndex].Years[i].GetYear().ToString().Substring(0, numChar).ToUpper()))
                        {
                            yearResults[yearResults.Length - 1] = i;
                            Array.Resize(ref yearResults, yearResults.Length + 1);
                            yearFound = true;
                        }
                    }
                }
                //ensures that none of the elements in the array are null
                Array.Resize(ref yearResults, yearResults.Length - 1);

                //if year was found then the first result is selected in the list 
                //user allowed to cycle through results beause next result button is enabled
                if (yearFound)
                {
                    lstYear.SelectedIndex = yearResults[yearCurrentSearchIndex];
                    lblYearSearchStatus.Text = string.Format("({0}) results found!", yearResults.Length);
                    btnNextFoundYear.Enabled = true;
                }
                else
                {
                    //if no results found then no year is selected and the user is notified 
                    lstYear.SelectedIndex = -1;
                    lblYearSearchStatus.Text = "No results!";
                    btnNextFoundYear.Enabled = false;
                }
            }
            else
            {
                //if the search box is empty then the search status is not shown and the next result button is disabled
                lblYearSearchStatus.Text = "";
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
            if (GetFileDirectory()) LoadData();
        }


        private void btnChangeSaveFileDirectory_Click(object sender, EventArgs e)
        {
            if (GetFileDirectory()) WriteToFile();
        }

        private bool GetFileDirectory()
        {
            try
            {
                //Opens a window where the user can browse for a text file
                openFileDialog.Title = "Please select .txt file";
                openFileDialog.ShowDialog();

                //file directory is recorded in varaible to be used when reading and writing to the file
                if (openFileDialog.FileName.Equals("")) return false;
                
                fileName = openFileDialog.FileName;

                //Displays current file directory on the form
                lblFileDirectory.Text = "File Directory: " + fileName;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void btnMonthGraphs_Click(object sender, EventArgs e)
        {
            string locationName = Data.storedLocations[lstLocation.SelectedIndex].LocationName;
            int currentLocIndex = lstLocation.SelectedIndex;
            int currentYearIndex = lstYear.SelectedIndex;
            frmGraphs tempFrmGraphs = new frmGraphs(locationName, currentLocIndex, currentYearIndex);
            tempFrmGraphs.Show();
        }
        

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            //Clears data in data class and clears all displays
            Data.storedLocations = null;
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
