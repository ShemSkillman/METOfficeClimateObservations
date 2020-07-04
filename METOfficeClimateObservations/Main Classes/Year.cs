using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    class Year
    {
        private int yearDate;
        private string yearDescription;
        private Month[] monthlyObservations;
        private bool isError;

        public Year(string theYear, string theYearDescription)
        {
            SetYear(theYear);
            yearDescription = theYearDescription;
        }

        public Year(string theYear, string theYearDescription, Month[] theMonthlyObservations)
        {
            SetYear(theYear);
            yearDescription = theYearDescription;
            monthlyObservations = theMonthlyObservations;
        }

        public void SetYear(string year)
        {
            try
            {
                yearDate = Convert.ToInt32(year);
                isError = false;
            }
            catch (FormatException formatError)
            {
                System.Windows.Forms.MessageBox.Show(formatError.Message + "\nPlease enter a whole number for the Year.");
                isError = true;
            }
            catch (OverflowException overflowError)
            {
                System.Windows.Forms.MessageBox.Show(overflowError.Message + "\nEntered Year is too large! Please enter a sensible value.");
                isError = true;
            }
        }

        public int GetYear()
        {
            return yearDate;
        }

        public string YearDescription
        {
            set
            {
                yearDescription = value;
            }
            get
            {
                return yearDescription;
            }
        }

        public Month[] MonthlyObservations
        {
            set
            {
                monthlyObservations = value;
            }
            get
            {
                return monthlyObservations;
            }
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
