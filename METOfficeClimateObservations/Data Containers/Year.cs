using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    public class Year
    {
        public int YearDate { get; set; }
        public string YearDesc{ get; set; }
        public Month[] MonthObs { get; set; }

        public Year(int theYear, string theYearDescription)
        {
            YearDate = theYear;
            YearDesc = theYearDescription;
        }
    }
}
