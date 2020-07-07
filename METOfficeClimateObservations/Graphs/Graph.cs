using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace METOfficeClimateObservations.Main_Classes
{
    public class Graph
    {
        protected const int numMonths = 12;
        public float GraphInterval { get; protected set; }

        public float YearMinValue { get; protected set; }

        public float YearMaxValue { get; protected set; }

        public float[] DataSet { get; protected set; }
        public Color GraphBarColour { get; protected set; }

        public string GraphName { get; protected set; }

        public string GraphXAxisName { get; protected set; }

        public Graph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, float[] theDataSet, Color theGraphBarColour)
        {
            GraphName = theGraphName;
            GraphXAxisName = theGraphXAxisName;
            GraphInterval = theGraphInterval;
            YearMinValue = theMinValue;
            YearMaxValue = theMaxValue;
            DataSet = theDataSet;
            GraphBarColour = theGraphBarColour;

            Initialize();
        }

        // Constructor that passes up parameters for the box plot graph
        public Graph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, Color theGraphBarColour)
        {
            GraphName = theGraphName;
            GraphXAxisName = theGraphXAxisName;
            GraphInterval = theGraphInterval;
            YearMinValue = theMinValue;
            YearMaxValue = theMaxValue;
            GraphBarColour = theGraphBarColour;
        }


        // Calculates min and max in dataset
        protected virtual void Initialize()
        {

            for (int i = 0; i < numMonths; i++)
            {
                float currentValue = DataSet[i];

                if (currentValue < YearMinValue)
                {
                    YearMinValue = currentValue;
                }
                if (currentValue > YearMaxValue)
                {
                    YearMaxValue = currentValue;
                }
            }

            // Calculates length of axes to accomodate for all values in dataset 
            // and to finish at the next graph interval

            // Max value rounded up to the nearest graph interval
            if (YearMaxValue % GraphInterval != 0)
            {
                YearMaxValue = YearMaxValue + (GraphInterval - (YearMaxValue % GraphInterval));
            }
            // Min value rounded up to the nearest graph interval
            if (YearMinValue % GraphInterval != 0)
            {
                YearMinValue = YearMinValue - (YearMinValue % GraphInterval);
            }
        }
    }
}
