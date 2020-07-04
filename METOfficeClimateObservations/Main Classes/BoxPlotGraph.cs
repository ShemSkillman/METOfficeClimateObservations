using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace METOfficeClimateObservations.Main_Classes
{
    public partial class BoxPlotGraph : Graph
    {        
        protected float[] minDataSet, maxDataSet;

        public BoxPlotGraph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, Color theGraphBarColour,
            float[] theMinDataSet, float[] theMaxDataSet) : base(theGraphName, theGraphXAxisName, theGraphInterval, theMinValue, theMaxValue, theGraphBarColour)
        {
            graphName = theGraphName;
            graphXAxisName = theGraphXAxisName;
            graphInterval = theGraphInterval;
            yearMinValue = theMinValue;
            yearMaxValue = theMaxValue;
            graphBarColour = theGraphBarColour;
            minDataSet = theMinDataSet;
            maxDataSet = theMaxDataSet;

            CalculateMinAndMax();
        }
        
        public float[] MinDataSet
        {
            get
            {
                return minDataSet;
            }
        }

        public float[] MaxDataSet
        {
            get
            {
                return maxDataSet;
            }
        }

        protected override void CalculateMinAndMax()
        {
            for (int i = 0; i < numMonths; i++)
            {
                float currentMinValue = minDataSet[i];

                if (currentMinValue < yearMinValue)
                {
                    yearMinValue = currentMinValue;
                }

                float currentMaxValue = maxDataSet[i];

                if (currentMaxValue > yearMaxValue)
                {
                    yearMaxValue = currentMaxValue;
                }
            }

            if (yearMaxValue % 5 != 0) //should be yearMaxValue % graphInterval != 0 in order to round to nearest graph Interval
            {
                yearMaxValue = yearMaxValue + (graphInterval - (yearMaxValue % graphInterval));
            }

            if (yearMinValue % 5 != 0) //should be yearMinValue % graphInterval != 0 in order to round to nearest graph Interval
            {
                yearMinValue = yearMinValue - (graphInterval + (yearMinValue % graphInterval));
            }
        }
    }
}
