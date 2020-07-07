using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    public class Month
    {
        public int MonthID { get; private set; }
        public float MaxTemp { get; private set; }
        public float MinTemp { get; private set; }
        public int NumDaysAirFrost { get; private set; }
        public float MillimetresRainfall { get; private set; }
        public float NumHoursSunshine { get; private set; }

        public Month(string theMonthID, string theMaxTemp, string theMinTemp, string theNumDaysAirFrost,
            string theMillimetresRainfall, string theNumHoursSunshine)
        {
            try
            {
                SetMonthID(theMonthID);
                SetMaxTemp(theMaxTemp);
                SetMinTemp(theMinTemp);
                SetNumDaysAirFrost(theNumDaysAirFrost);
                SetMillimetresOfRainfall(theMillimetresRainfall);
                SetNumHoursSunshine(theNumHoursSunshine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetMonthID(string idNum)
        {
            try
            {
                MonthID = Convert.ToInt32(idNum);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a whole number for the Month ID Number.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Month ID Number is too large! Please enter a sensible value.");
            }
        }

        public void SetMaxTemp(string tempMax)
        {
            try
            {
                MaxTemp = Convert.ToSingle(tempMax);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a value in the format 0.0 for the Maximum Month Temperature.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Maximum Month Temperature is too large! Please enter a sensible value.");
            }
        }

        public void SetMinTemp(string tempMin)
        {
            try
            {
                MinTemp = Convert.ToSingle(tempMin);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a value in the format 0.0 for the Minimum Month Temperature.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Minimum Month Temperature is too large! Please enter a sensible value.");
            }
        }

        public void SetNumDaysAirFrost(string airFrostDays)
        {
            try
            {
                NumDaysAirFrost = Convert.ToInt32(airFrostDays);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a whole number for the Number of Days of Air Frost.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Number of Days of Air Frost is too large! Please enter a sensible value.");
            }
        }

        public void SetMillimetresOfRainfall(string mmOfRainfall)
        {
            try
            {
                MillimetresRainfall = Convert.ToSingle(mmOfRainfall);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a value in the format 0.0 for the Millimetres of Rainfall this Month.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Millimetres of Rainfall this Month is too large! Please enter a sensible value.");
            }
        }

        public void SetNumHoursSunshine(string sunshineHours)
        {
            try
            {
                NumHoursSunshine = Convert.ToSingle(sunshineHours);
            }
            catch (FormatException)
            {
                throw new FormatException("Please enter a value in the format 0.0 for the Number of Hours of Sunshine this Month.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Entered Number of Hours of Sunshine this Month is too large! Please enter a sensible value.");
            }
        }
    }
}
