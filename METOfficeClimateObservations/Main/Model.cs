using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    class Model
    {
        public List<Location> Locations { get; private set; }

        //Located in \Debug\bin
        public string FileName { get; set; } = "inputEXTENDED.txt";

        public Model()
        {
            ReadFile();
        }

        public void ReadFile()
        {
            // Variables to be filled when the file is read line by line
            string locationName, streetNumAndName, county, postCode, latitude, longitude;
            string yearDescription, year;
            string monthID, maxTemp, minTemp, numDaysAirFrost, monthRainfallMillimetres, monthHoursSunshine;

            int numYears, numLocations;
            int numMonths = 12;

            try
            {
                StreamReader inputStream = new StreamReader(FileName);

                // Number of locations read at the top of the file
                numLocations = Convert.ToInt32(inputStream.ReadLine());

                // Check locations
                if (numLocations > 0)
                {
                    Locations = new List<Location>();
                }
                else
                {
                    inputStream.Close();
                    Locations = null;
                    throw new Exception("There are no locations in the file " + FileName);
                }

                // Iterates through locations
                for (int i = 0; i < numLocations; i++)
                {
                    locationName = inputStream.ReadLine();
                    streetNumAndName = inputStream.ReadLine();
                    county = inputStream.ReadLine();
                    postCode = inputStream.ReadLine();
                    latitude = inputStream.ReadLine();
                    longitude = inputStream.ReadLine();

                    Location newLocation = CreateLocation(locationName, streetNumAndName, county, postCode, latitude, longitude);

                    numYears = Convert.ToInt32(inputStream.ReadLine());
                    List<Year> years = new List<Year>();

                    // Iterates through years
                    for (int j = 0; j < numYears; j++)
                    {
                        yearDescription = inputStream.ReadLine();
                        year = inputStream.ReadLine();

                        Year newYear = CreateYear(year, yearDescription);

                        Month[] months = new Month[numMonths];

                        // Iterates through months
                        for (int k = 0; k < numMonths; k++)
                        {
                            monthID = inputStream.ReadLine();
                            maxTemp = inputStream.ReadLine();
                            minTemp = inputStream.ReadLine();
                            numDaysAirFrost = inputStream.ReadLine();
                            monthRainfallMillimetres = inputStream.ReadLine();
                            monthHoursSunshine = inputStream.ReadLine();

                            // Last month (month ID = 12) does not have year assigned, skips reading the year
                            if (k != numMonths - 1)
                            {
                                year = inputStream.ReadLine();
                            }

                            Month newMonth = new Month(monthID, maxTemp, minTemp, numDaysAirFrost, monthRainfallMillimetres, monthHoursSunshine);

                            months[k] = newMonth;
                        }

                        newYear.MonthObs = months;
                        years.Add(newYear);

                    }

                    newLocation.Years = years;
                    Locations.Add(newLocation);
                }

                inputStream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Location CreateLocation(string locName, string streetNumAndName, string county, string postCode,
            string latitude, string longitude)
        {
            try
            {
                return new Location(locName, streetNumAndName, county, postCode,
                    Convert.ToSingle(latitude), Convert.ToSingle(longitude));
            }
            catch (FormatException)
            {
                throw new FormatException("\nLatitude and Longitude must be entered in the format 0.0.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("\nValue entered for Latitude or Longtitude is too large! Please enter a sensible value.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Year CreateYear(string yearDate, string yearDesc)
        {
            try
            {
                return new Year(Convert.ToInt32(yearDate), yearDesc);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a whole number for the Year.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Year is too large! Please enter a sensible value.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteFile()
        {
            try
            {
                if (FileName == null)
                {
                    throw new Exception("There is no file currently loaded!");
                }

                StreamWriter outputStream = new StreamWriter(FileName);

                if (Locations != null)
                {
                    int numLocations = Locations.Count;

                    outputStream.WriteLine(numLocations);

                    foreach (Location loc in Locations)
                    {
                        outputStream.WriteLine(loc.LocationName);
                        outputStream.WriteLine(loc.StreetNumAndName);
                        outputStream.WriteLine(loc.County);
                        outputStream.WriteLine(loc.PostCode);
                        outputStream.WriteLine(loc.Latitude);
                        outputStream.WriteLine(loc.Longitude);

                        if (loc.Years != null)
                        {
                            outputStream.WriteLine(loc.Years.Count);
                        }
                        else
                        {
                            break;
                        }

                        foreach (Year year in loc.Years)
                        {
                            outputStream.WriteLine(year.YearDesc);
                            outputStream.WriteLine(year.YearDate);

                            for (int i = 0; i < 12; i++)
                            {
                                outputStream.WriteLine(year.MonthObs[i].MonthID);
                                outputStream.WriteLine(year.MonthObs[i].MaxTemp);
                                outputStream.WriteLine(year.MonthObs[i].MinTemp);
                                outputStream.WriteLine(year.MonthObs[i].NumDaysAirFrost);
                                outputStream.WriteLine(year.MonthObs[i].MillimetresRainfall);
                                outputStream.WriteLine(year.MonthObs[i].NumHoursSunshine);

                                if (i != 11)
                                {
                                    outputStream.WriteLine(year.YearDate);
                                }

                            }
                        }

                    }

                }

                outputStream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void ClearData()
        {
            Locations = null;
        }

        public void EditExistingLocation(int locIndex, string locName, string streetNumAndName, string county, string postCode,
            string latitude, string longitude)
        {
            try
            {
                Location editLoc = CreateLocation(locName, streetNumAndName, county, postCode, latitude, longitude);
                Locations[locIndex] = editLoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveNewLocation(string locName, string streetNumAndName, string county, string postCode,
            string latitude, string longitude)
        {
            try
            {
                Location newLoc = CreateLocation(locName, streetNumAndName, county, postCode, latitude, longitude);
                Locations.Add(newLoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveNewYear(int locIndex, string yearDate, string yearDesc)
        {
            try
            {
                Year year = CreateYear(yearDate, yearDesc);
                Locations[locIndex].Years.Add(year);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveMonths(int locIndex, int yearIndex, Month[] allMonths)
        {
            Locations[locIndex].Years[yearIndex].MonthObs = allMonths;
        }

        public void DeleteLocation(int locIndex)
        {
            Locations.Remove(Locations[locIndex]);
        }

        public void DeleteYear(int locIndex, int yearIndex)
        {
            var years = Locations[locIndex].Years;
            years.Remove(years[yearIndex]);
        }

        public void EditExistingYear(int locIndex, int yearIndex, string yearDate, string yearDesc)
        {
            try
            {
                Year editYear = CreateYear(yearDate, yearDesc);
                Locations[locIndex].Years[yearIndex] = editYear;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
