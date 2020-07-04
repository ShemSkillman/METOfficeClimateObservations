using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    class Month
    {
        private int monthID;
        private float maxTemp;
        private float minTemp;
        private int numDaysAirFrost;
        private float millimetresRainfall;
        private float numHoursSunshine;
        private bool isError;

        public Month(string theMonthID, string theMaxTemp, string theMinTemp, string theNumDaysAirFrost, string theMillimetresRainfall, string theNumHoursSunshine)
        {
            SetMonthID(theMonthID);
            SetMaxTemp(theMaxTemp);
            SetMinTemp(theMinTemp);
            SetNumDaysAirFrost(theNumDaysAirFrost);
            SetMillimetresOfRainfall(theMillimetresRainfall);
            SetNumHoursSunshine(theNumHoursSunshine);
        }

        public void SetMonthID(string idNum)
        {
            try
            {
                monthID = Convert.ToInt32(idNum);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a whole number for the Month ID Number.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Month ID Number is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public int GetMonthID()
        {
            return monthID;
        }

        public void SetMaxTemp(string tempMax)
        {
            try
            {
                maxTemp = Convert.ToSingle(tempMax);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Maximum Month Temperature.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Maximum Month Temperature is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public float GetMaxTemp()
        {
            return maxTemp;
        }

        public void SetMinTemp(string tempMin)
        {
            try
            {
                minTemp = Convert.ToSingle(tempMin);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Minimum Month Temperature.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Minimum Month Temperature is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public float GetMinTemp()
        {
            return minTemp;
        }

        public void SetNumDaysAirFrost(string airFrostDays)
        {
            try
            {
                numDaysAirFrost = Convert.ToInt32(airFrostDays);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a whole number for the Number of Days of Air Frost.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Number of Days of Air Frost is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public int GetNumDaysAirFrost()
        {
            return numDaysAirFrost;
        }

        public void SetMillimetresOfRainfall(string mmOfRainfall)
        {
            try
            {
                millimetresRainfall = Convert.ToSingle(mmOfRainfall);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Millimetres of Rainfall this Month.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Millimetres of Rainfall this Month is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public float GetMillimetresOfRainfall()
        {
            return millimetresRainfall;
        }

        public void SetNumHoursSunshine(string sunshineHours)
        {
            try
            {
                numHoursSunshine = Convert.ToSingle(sunshineHours);
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a value in the format 0.0 for the Number of Hours of Sunshine this Month.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Number of Hours of Sunshine this Month is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public float GetNumHoursSunshine()
        {
            return numHoursSunshine;
        }

        public bool IsError
        {
            get
            {
                return isError;
            }
        }
    }
}
