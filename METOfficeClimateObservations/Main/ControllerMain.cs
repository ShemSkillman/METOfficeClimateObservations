using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace METOfficeClimateObservations.MVC
{
    class ControllerMain : BindingContext
    {
        Model model;

        public string[] MonthData { get; } = { "Month ID", "Maximum Temperature", "Minimum Temperature",
            "Number of Days of Air Frost", "Millimetres of Rainfall", "Number of Hours of Sunshine"};

        public string[] MonthNames { get; } = { "January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December"};

        public ControllerMain()
        {
            model = new Model();
        }

        public List<Location> Locations
        {
            get => model.Locations;
        }

        public string FileName
        {
            get => model.FileName;
            set
            {
                model.FileName = value;
            }
        }

        // Returns string array of all location details
        public string[] LocationDetails
        {
            get
            {
                if (model.Locations == null) return null;
                string[] locDetails = new string[model.Locations.Count];
                for (int i = 0; i < model.Locations.Count; i++)
                {
                    Location currentLoc = model.Locations[i];
                    locDetails[i] = (string.Format("{0} Address: {1}, {2} Postcode: {3} Longitude: {4} Latitude: {5}",
                        currentLoc.LocationName, currentLoc.StreetNumAndName, currentLoc.County, currentLoc.PostCode, 
                        currentLoc.Longitude, currentLoc.Latitude));
                }

                return locDetails;
            }
        }

        public void EditExistingLocation(int locIndex, string locName, string streetNumAndName, string county, string postCode,
            string latitude, string longitude)
        {
            model.EditExistingLocation(locIndex, locName, streetNumAndName, county, postCode, latitude, longitude);
        }

        public void SaveNewLocation(string locName, string streetNumAndName, string county, string postCode,
            string latitude, string longitude)
        {
            model.SaveNewLocation(locName, streetNumAndName, county, postCode, latitude, longitude);
        }

        public void SaveNewYear(int locIndex, string yearDate, string yearDesc)
        {
            model.SaveNewYear(locIndex, yearDate, yearDesc);
        }

        public void EditExistingYear(int locIndex, int yearIndex, string yearDate, string yearDesc)
        {
            model.EditExistingYear(locIndex, yearIndex, yearDate, yearDesc);
        }

        public void SaveMonths(int locIndex, int yearIndex, Month[] allMonths)
        {
            model.SaveMonths(locIndex, yearIndex, allMonths);
        }

        public void DeleteLocation(int locIndex)
        {
            model.DeleteLocation(locIndex);
        }

        public void DeleteYear(int locIndex, int yearIndex)
        {
            model.DeleteYear(locIndex, yearIndex);
        }

        // Returns list of location indexes which match search
        public List<int> SearchLocation(string search)
        {
            int numChar = search.Length;
            var locResults = new List<int>();

            for (int i = 0; i < Locations.Count; i++)
            {
                if (numChar <= Locations[i].LocationName.Length &&
                    Equals(search, Locations[i].LocationName.Substring(0, numChar).ToUpper()))
                {
                    locResults.Add(i);
                }
            }

            return locResults;
        }

        // Returns list of year indexes which match search
        public List<int> SearchYear(int locIndex, string search)
        {
            int numChar = search.Length;
            var yearResults = new List<int>();

            var years = Locations[locIndex].Years;

            for (int i = 0; i < years.Count; i++)
            {
                string yearDate = years[i].YearDate.ToString();
                if (numChar <= yearDate.Length &&
                    Equals(search, yearDate.Substring(0, numChar).ToUpper()))
                {
                    yearResults.Add(i);
                }
            }

            return yearResults;
        }

        public void ReadFile()
        {
            model.ReadFile();
        }

        public void WriteFile()
        {
            model.WriteFile();
        }

        public void ClearData()
        {
            model.ClearData();
        }
    }
}
