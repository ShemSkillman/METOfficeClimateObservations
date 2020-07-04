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

        protected float graphInterval;
        protected float yearMinValue, yearMaxValue;
        protected float[] dataSet;
        protected Color graphBarColour;
        protected string graphName;
        protected string graphXAxisName;

        public Graph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, float[] theDataSet, Color theGraphBarColour)
        {
            graphName = theGraphName;
            graphXAxisName = theGraphXAxisName;
            graphInterval = theGraphInterval;
            yearMinValue = theMinValue;
            yearMaxValue = theMaxValue;
            dataSet = theDataSet;
            graphBarColour = theGraphBarColour;

            CalculateMinAndMax();
        }

        //Constructor that passes up parameters for the box plot graph
        public Graph(string theGraphName, string theGraphXAxisName, float theGraphInterval, float theMinValue, float theMaxValue, Color theGraphBarColour)
        {
            graphName = theGraphName;
            graphXAxisName = theGraphXAxisName;
            graphInterval = theGraphInterval;
            yearMinValue = theMinValue;
            yearMaxValue = theMaxValue;
            graphBarColour = theGraphBarColour;
        }

        public float GraphInterval
        {
            get
            {
                return graphInterval;
            }
        }

        public float YearMinValue
        {
            get
            {
                return yearMinValue;
            }
        }

        public float YearMaxValue
        {
            get
            {
                return yearMaxValue;
            }
        }

        public float[] DataSet
        {
            get
            {
                return dataSet;
            }
        }

        public Color GraphBarColour
        {
            get
            {
                return graphBarColour;
            }            
        }

        public string GraphName
        {
            get
            {
                return graphName;
            }
        }

        public string GraphXAxisName
        {
            get
            {
                return graphXAxisName;
            }
        }    

        protected virtual void CalculateMinAndMax()
        {
            //WORKS OUT LOWEST AND HIGHEST VALUE IN THE DATA SET

            for (int i = 0; i < numMonths; i++)
            {
                float currentValue = dataSet[i];

                if (currentValue < yearMinValue)
                {
                    yearMinValue = currentValue;
                }
                if (currentValue > yearMaxValue)
                {
                    yearMaxValue = currentValue;
                }
            }

            //BELOW CODE WORKS OUT THE RANGE OF THE AXES SO THAT ALL VALUES ARE WITHIN IT

            //this rounds the maximum value up to the nearest graph interval
            if (yearMaxValue % graphInterval != 0)
            {
                yearMaxValue = yearMaxValue + (graphInterval - (yearMaxValue % graphInterval));
            }
            //this round the minimum value down to the nearest graph interval
            if (yearMinValue % graphInterval != 0)
            {
                yearMinValue = yearMinValue - (yearMinValue % graphInterval);
            }
        }
    }
}
