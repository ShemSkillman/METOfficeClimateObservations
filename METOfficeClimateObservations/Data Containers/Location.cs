using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace METOfficeClimateObservations
{
    public class Location
    {
        public string LocationName { get; set; }
        public string StreetNumAndName { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<Year> Years { get; set; }

        public Location(string theLocationName, string theStreetNumberAndName, string theCounty, string thePostCode, float theLatitude, float theLongitude, List<Year> theYears)
        {
            Initialize(theLocationName, theStreetNumberAndName, theCounty, thePostCode, theLatitude, theLongitude);
            Years = theYears;
        }

        public Location(string theLocationName, string theStreetNumberAndName, string theCounty, string thePostCode, float theLatitude, float theLongitude)
        {
            Initialize(theLocationName, theStreetNumberAndName, theCounty, thePostCode, theLatitude, theLongitude);
        }

        private void Initialize(string theLocationName, string theStreetNumberAndName, string theCounty, string thePostCode, float theLatitude, float theLongitude)
        {
            LocationName = theLocationName;
            StreetNumAndName = theStreetNumberAndName;
            County = theCounty;
            PostCode = thePostCode;
            Latitude = theLatitude;
            Longitude = theLongitude;
        }
    }
}
