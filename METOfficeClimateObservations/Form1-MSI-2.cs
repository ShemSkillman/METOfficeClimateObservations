using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace METOfficeClimateObservations
{
    public partial class frmMain : Form
    {
        int numOfRows = 12;
        int numOfCols = 6;
        Random rand;

        //Name of file to access when reading and writing
        string fileName = "inputEXTENDED.txt";
        
        public frmMain()
        {
            InitializeComponent();
            rand = new Random();

            //Gets locations, years, and months data from the file
            SetUpLocations();

            GenerateMonthsDataGrid();
            DisplayLocationDetails();
            lstLocation.SelectedIndex = 0;
            lstYear.SelectedIndex = 0;
        }

        private void SetUpLocations()
        {
            //Variables to be filled when the file is read line by line
            string locationName, streetNumAndName, county, postCode, latitude, longitude;
            string yearDescription, year;
            string monthID, maxTemp, minTemp, numDaysAirFrost, monthRainfallMillimetres, monthHoursSunshine;

            //Number of locations and number of years within each location stored to determine number of for loop cycles
            int numYears, numLocations;

            try
            {
                //Input stream created to get information from file to the application
                StreamReader inputStream = new StreamReader(fileName);

                //Number of locations read at the top of the file
                numLocations = Convert.ToInt32(inputStream.ReadLine());

                //Array of locations in Data class created 
                Data.storedLocations = new Location[1];

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
                        for (int k = 0; k < 12; k++)
                        {
                            //All month details collected temporarily in variables
                            monthID = inputStream.ReadLine();
                            maxTemp = inputStream.ReadLine();
                            minTemp = inputStream.ReadLine();
                            numDaysAirFrost = inputStream.ReadLine(); 
                            monthRainfallMillimetres = inputStream.ReadLine(); 
                            monthHoursSunshine = inputStream.ReadLine();

                            //Last month (month ID = 12) in the file does not have year assigned to it so skip reading the year
                            if (k != 11)
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
            }
            //Handles any exceptions that may occur when reading from the file 
            catch (Exception e)
            {
                //Displays error message to the user
                MessageBox.Show(e.Message);
            }

            
        }        

        private void DisplayLocationDetails()
        {
            lstLocation.Items.Clear();

            foreach (Location loc in Data.storedLocations)
            {
                lstLocation.Items.Add(string.Format("{0} Address: {1}, {2} Postcode: {3} Longitude: {4} Latitude: {5}",
                    loc.LocationName, loc.StreetNumberAndName, loc.County, loc.PostCode, loc.GetLongitude(), loc.GetLatitude()));
            }
        }

        private void lstLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutofillLocationTextBoxes();
            DisplayYearDetails();

            if (Data.storedLocations[lstLocation.SelectedIndex].Years != null)
            {
                lstYear.SelectedIndex = 0;
            }
        }

        private void AutofillLocationTextBoxes()
        {
            lstLocation.SelectedIndex = lstLocation.SelectedIndex;

            if (lstLocation.SelectedIndex > -1)
            {
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
            txtLocationName.Text = "";
            txtStreetNumAndName.Text = "";
            txtCounty.Text = "";
            txtPostCode.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
        }

        private void btnSaveLocationChanges_Click(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.SelectedIndex;

            if (lstLocation.SelectedIndex > -1)
            {
                Location loc = Data.storedLocations[lstLocation.SelectedIndex];

                loc.LocationName = txtLocationName.Text;                
                loc.StreetNumberAndName = txtStreetNumAndName.Text;
                loc.County = txtCounty.Text;
                loc.PostCode = txtPostCode.Text;
                loc.SetLatitude(txtLatitude.Text);
                loc.SetLongitude(txtLongitude.Text);
                
                int locIndex = lstLocation.SelectedIndex;
                int yearIndex = lstYear.SelectedIndex;

                UpdateDisplay();

                lstLocation.SelectedIndex = locIndex;
                lstYear.SelectedIndex = yearIndex;
            }

        }

        private void DisplayYearDetails()
        {

            if (lstLocation.SelectedIndex > -1)
            {
                lstYear.Items.Clear();

                Location tempLocation = Data.storedLocations[lstLocation.SelectedIndex];

                if (tempLocation.Years != null)
                {
                    foreach (Year theYear in tempLocation.Years)
                    {
                        lstYear.Items.Add(string.Format("{0} Description: {1}",
                            theYear.GetYear(), theYear.YearDescription));
                    }
                }                
            }            

            
        }

        private void AutofillYearTextBoxes()
        {

            if (lstYear.SelectedIndex > -1 && lstYear.SelectedIndex > -1)
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
            Location newLocation = new Location(txtLocationName.Text, txtStreetNumAndName.Text, txtCounty.Text, txtPostCode.Text,
                txtLatitude.Text, txtLongitude.Text);

            Array.Resize(ref Data.storedLocations, Data.storedLocations.Length + 1);
            Data.storedLocations[Data.storedLocations.Length - 1] = newLocation;            

            UpdateDisplay();
            
            lstLocation.SelectedIndex = Data.storedLocations.Length - 1;
        }

        private void btnAddNewYear_Click(object sender, EventArgs e)
        {
            Year newYear = new Year(txtYearDate.Text, txtYearDescription.Text);

            lstLocation.SelectedIndex = lstLocation.SelectedIndex;

            Location selectedLocation = Data.storedLocations[lstLocation.SelectedIndex];
            Year[] locationYears = selectedLocation.Years;

            if (locationYears == null)
            {
                locationYears = new Year[1];
            }
            else
            {
                Array.Resize(ref locationYears, locationYears.Length + 1);
            }

            locationYears[locationYears.Length - 1] = newYear;

            selectedLocation.Years = locationYears;
            Data.storedLocations[lstLocation.SelectedIndex] = selectedLocation;

            int locIndex = lstLocation.SelectedIndex;

            UpdateDisplay();

            lstLocation.SelectedIndex = locIndex;
            lstYear.SelectedIndex = locationYears.Length - 1;
        }

        private void btnSaveYearChanges_Click(object sender, EventArgs e)
        {
            lstYear.SelectedIndex = lstYear.SelectedIndex;

            if (lstYear.SelectedIndex > -1)
            {
                Year editedYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex];

                editedYear.SetYear(txtYearDate.Text);
                editedYear.YearDescription = txtYearDescription.Text;

                int locIndex = lstLocation.SelectedIndex;
                int yearIndex = lstYear.SelectedIndex;

                UpdateDisplay();

                lstLocation.SelectedIndex = locIndex;
                lstYear.SelectedIndex = yearIndex;
            }

        }

        private void DisplayMonthlyObservationDetails()
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

        private void UpdateDisplay()
        {
            DisplayYearDetails();
            DisplayLocationDetails();
        }

        private void GenerateMonthsDataGrid()
        {
            

            dgdMonthlyObservations.RowCount = 12;
            dgdMonthlyObservations.ColumnCount = 6;

            dgdMonthlyObservations.Columns[0].HeaderText = "Month ID";
            dgdMonthlyObservations.Columns[1].HeaderText = "Maximum Temperature";
            dgdMonthlyObservations.Columns[2].HeaderText = "Minimum Temperature";
            dgdMonthlyObservations.Columns[3].HeaderText = "Number of Days of Air Frost";
            dgdMonthlyObservations.Columns[4].HeaderText = "Millimetres of Rainfall";
            dgdMonthlyObservations.Columns[5].HeaderText = "Number of Hours of Sunshine";
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
            Month[] monthsOfYear = Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].MonthlyObservations;

            if (monthsOfYear == null)
            {
                monthsOfYear = new Month[numOfRows];
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

                    monthsOfYear[i] = newMonth;
                }
            } 
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
            Data.storedLocations[lstLocation.SelectedIndex].Years[lstYear.SelectedIndex].MonthlyObservations = monthsOfYear;
        }

        private void btnPopulateFields_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numOfRows; i++)
            {
                dgdMonthlyObservations[0, i].Value = i + 1;
                dgdMonthlyObservations[1, i].Value = rand.Next(20, 50);
                dgdMonthlyObservations[2, i].Value = rand.Next(-15, 20);
                dgdMonthlyObservations[3, i].Value = rand.Next(0, 100);
                dgdMonthlyObservations[4, i].Value = rand.Next(0, 1000);
                dgdMonthlyObservations[5, i].Value = rand.Next(0, 70);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
