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

        public BoxPlotGraph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, Color theGraphBarColour,
            float[] theMinDataSet, float[] theMaxDataSet) : base(theGraphName, theGraphXAxisName, theGraphInterval, theMinValue, theMaxValue, theGraphBarColour)
        {
            GraphName = theGraphName;
            GraphXAxisName = theGraphXAxisName;
            GraphInterval = theGraphInterval;
            YearMinValue = theMinValue;
            YearMaxValue = theMaxValue;
            GraphBarColour = theGraphBarColour;
            MinDataSet = theMinDataSet;
            MaxDataSet = theMaxDataSet;

            Initialize();
        }
        
        public float[] MinDataSet { get; }

        public float[] MaxDataSet { get; }

        protected override void Initialize()
        {
            for (int i = 0; i < numMonths; i++)
            {
                float currentMinValue = MinDataSet[i];

                if (currentMinValue < YearMinValue)
                {
                    YearMinValue = currentMinValue;
                }

                float currentMaxValue = MaxDataSet[i];

                if (currentMaxValue > YearMaxValue)
                {
                    YearMaxValue = currentMaxValue;
                }
            }

            if (YearMaxValue % 5 != 0)
            {
                YearMaxValue = YearMaxValue + (GraphInterval - (YearMaxValue % GraphInterval));
            }

            if (YearMinValue % 5 != 0)
            {
                YearMinValue = YearMinValue - (GraphInterval + (YearMinValue % GraphInterval));
            }
        }
    }
}
