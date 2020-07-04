using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    class Location
    {
        private string locationName;
        private string streetNumberAndName;
        private string county;
        private string postCode;
        private float latitude;
        private float longitude;
        private Year[] years;
        private bool isLongitudeError, isLatitudeError, isError;

        public Location(string theLocationName, string theStreetNumberAndName, string theCounty, string thePostCode, string theLatitude, string theLongitude, Year[] theYears)
        {
            locationName = theLocationName;
            streetNumberAndName = theStreetNumberAndName;
            county = theCounty;
            postCode = thePostCode;
            SetLatitude(theLatitude);
            SetLongitude(theLongitude);
            years = theYears;
        }

        public Location(string theLocationName, string theStreetNumberAndName, string theCounty, string thePostCode, string theLatitude, string theLongitude)
        {
            locationName = theLocationName;
            streetNumberAndName = theStreetNumberAndName;
            county = theCounty;
            postCode = thePostCode;
            SetLatitude(theLatitude);
            SetLongitude(theLongitude);
        }

        public string LocationName
        {
            set
            {
                locationName = value;
            }
            get
            {
                return locationName;
            }
        }

        public string StreetNumberAndName
        {
            set
            {
                streetNumberAndName = value;
            }
            get
            {
                return streetNumberAndName;
            }
        }

        public string County
        {
            set
            {
                county = value;
            }
            get
            {
                return county;
            }
        }

        public string PostCode
        {
            set
            {
                postCode = value;
            }
            get
            {
                return postCode;
            }
        }

        public void SetLatitude(string theLatitude)
        {
            try
            {
                latitude = Convert.ToSingle(theLatitude);
                isLatitudeError = false;
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Location Latitude.");
                isLatitudeError = true;
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Location Latitude is too large! Please enter a sensible value.");
                isLatitudeError = true;
                isError = true;
            }

            CheckAnyErrors();
        }

        public float GetLatitude()
        {
            return latitude;
        }

        public void SetLongitude(string theLongitude)
        {
            try
            {
                longitude = Convert.ToSingle(theLongitude);
                isLongitudeError = false;
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Location Longitude.");
                isLongitudeError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Location Longitude is too large! Please enter a sensible value.");
                isLongitudeError = true;
            }

            CheckAnyErrors();
        }

        public float GetLongitude()
        {
            return longitude;
        }

        public Year[] Years
        {
            set
            {
                years = value;
            }
            get
            {
                return years;
            }
        }

        public bool IsError
        {
            get
            {
                return isError;
            }
        }

        private void CheckAnyErrors()
        {
            if (isLongitudeError || isLatitudeError)
            {
                isError = true;
            }
            else
            {
                isError = false;
            }
        }

    }
}
