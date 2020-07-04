using METOfficeClimateObservations.Main_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METOfficeClimateObservations
{
    public partial class frmGraphs : Form
    {
        Year year;

        string locationName;
        int yearDate;
        
        //All months stored as strings in an array so they can be accessed and displayed on the graph
        string[] monthNames = { "January", "Februrary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        float[] monthsAirFrostData, monthsRainfallData, monthsSunshineData, monthsMinTempData, monthsMaxTempData;

        //stores y positions of each bar on the graph
        int[] yBarPositions;

        //Number of months in a year must always remain 12
        const int numMonths = 12;

        //stores all of graphs
        Graph[] graphs;

        //Sets the space between each bar on the graph
        int graphBarSpacing = 10;
        int graphBarThickness = 40;

        //max length a bar can be on the graph (pixel length of graph on panel)
        const int maxBarLength = 1000; //100 pixel buffer zone on each side

        public frmGraphs(string theLocationName, int locIndex, int yearIndex)
        {
            InitializeComponent();

            locationName = theLocationName;

            //Sets y position of each bar on every graph
            SetGraphBarsYPos();

            //Gets year instance and stores months data into seperate arrays
            ExtractYearData(locIndex, yearIndex);
            
            graphs = CreateGraphs();
            DisplayGraphSelection();

            //When form starts the first index is selected
            cboxMonthDataTypes.SelectedIndex = 0;

            Refresh();
        }


        private void SetGraphBarsYPos()
        {
            //number of bar positions must be no more or less than 12 since their are 12 months
            yBarPositions = new int[numMonths];

            //sets position of each bar from Jan - Dec
            for (int i = 0; i < numMonths; i++)
            {
                yBarPositions[i] = 95 + graphBarSpacing + (graphBarThickness + graphBarSpacing) * i;
            }
        }

        private void ExtractYearData(int theLocIndex, int theYearIndex)
        {
            try
            {
                //Exception handling in case year data is null
                year = Data.storedLocations[theLocIndex].Years[theYearIndex];
            }
            catch (Exception e)
            {
                //shows error message to user otherwise
                MessageBox.Show(e.Message);
                return;
            }

            yearDate = year.GetYear();

            //Creates arrays size 12 to store data of every field for each of the 12 months
            monthsAirFrostData = new float[numMonths];
            monthsRainfallData = new float[numMonths];
            monthsSunshineData = new float[numMonths];
            monthsMinTempData = new float[numMonths];
            monthsMaxTempData = new float[numMonths];

            for (int i = 0; i < numMonths; i++)
            {
                //Month data extracted from year and placed in appropriate arrays
                monthsAirFrostData[i] = year.MonthlyObservations[i].GetNumDaysAirFrost();
                monthsRainfallData[i] = year.MonthlyObservations[i].GetMillimetresOfRainfall();
                monthsSunshineData[i] = year.MonthlyObservations[i].GetNumHoursSunshine();
                monthsMinTempData[i] = year.MonthlyObservations[i].GetMinTemp();
                monthsMaxTempData[i] = year.MonthlyObservations[i].GetMaxTemp();
            }
        }
        
        private Graph[] CreateGraphs()
        {
            //Creates graph instances with different states to suit the type of data
            Graph sunshineHoursGraph = new Graph("Monthly Hours of Sunshine", "Number of Hours", 20f, 1000f, 0f, monthsSunshineData, Color.Yellow);
            Graph airFrostDaysGraph = new Graph("Monthly Days of Airfrost", "Number of Days", 5f, 1000f, 0f, monthsAirFrostData, Color.LightBlue);
            Graph rainfallGraph = new Graph("Monthly Amount of Rainfall", "Rainfall (mm)", 10f, 1000f, 0f, monthsRainfallData, Color.RoyalBlue);
            Graph minAndMaxTempGraph = new BoxPlotGraph("Monthly Minimum and Maximum Temperature", "Temperature", 2f, 100f, -100f, Color.Orange, monthsMinTempData, monthsMaxTempData);

            //graphs stored and accessible in this array
            Graph[] allGraphs = {minAndMaxTempGraph, sunshineHoursGraph, airFrostDaysGraph, rainfallGraph};
            return allGraphs;
        }

        private void DisplayGraphSelection()
        {
            //graphs accessible to user from the combobox
            foreach (Graph graph in graphs)
            {
                cboxMonthDataTypes.Items.Add(graph.GraphName);
            }
        }

        //when selection is changed the graphics panel is refreshed
        private void cboxMonthDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        //when checkbox is checked/unchecked the graphics panel is refreshed
        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            //Creates graphics object
            Graphics panelGraphics = DrawingPanel.CreateGraphics();

            //Sets font type and size and the brush for drawing the text for the whole graph
            Font normalTextFont = new Font("Arial", 12);
            Font smallerTextFont = new Font("Arial", 11);
            SolidBrush writeBrush = new SolidBrush(Color.Black);

            //Pen properties for drawing the axes
            int axesSize = 4;
            Color axesColor = Color.Black;

            //Pen properties for drawing grid lines on graphs
            int gridLineSize = 2;
            Color gridLineColour = Color.LightGray;
            
            Graph selectedGraph = graphs[cboxMonthDataTypes.SelectedIndex];

            //Gets graph data from graph instance to be used when painting the graph on the panel
            float minValue = selectedGraph.YearMinValue, maxValue = selectedGraph.YearMaxValue, graphInterval = selectedGraph.GraphInterval;
            Color brushColour = selectedGraph.GraphBarColour;
            
            float overallRange = maxValue - minValue;
            float pixelsPerUnit = maxBarLength / overallRange;

            //WRITES GRAPH INTERVAL VALUES UNDER THE X AXIS
            for (float currentValue = minValue, i = 0; currentValue <= maxValue; currentValue += graphInterval, i++)
            {
                PointF textPoint = new PointF(100 + (i * pixelsPerUnit * graphInterval), 705);
                string drawString = currentValue.ToString();
                panelGraphics.DrawString(drawString, normalTextFont, writeBrush, textPoint);

                //DRAWS FAINT LINE AT EACH INTERVAL ON THE GRAPH
                using (Pen linePen = new Pen(gridLineColour, gridLineSize))
                {
                    panelGraphics.DrawLine(linePen, 100 + (i * pixelsPerUnit * graphInterval), 715, 100 + (i * pixelsPerUnit * graphInterval), 100);
                }
            }

            //DRAWS BOX PLOT GRAPH
            if (selectedGraph is BoxPlotGraph)
            {
                //two values for each box plot
                float[] minDataSet = ((BoxPlotGraph)selectedGraph).MinDataSet;
                float[] maxDataSet = ((BoxPlotGraph)selectedGraph).MaxDataSet;
                
                //offset required due to negative values
                float offset = overallRange - maxValue;

                for (int i = 0; i < numMonths; i++)
                {
                    //gets min and max temperature of the month
                    float currentMinValue = minDataSet[i];
                    float currentMaxValue = maxDataSet[i];

                    //range calculated
                    float rangeBetweenMinAndMax = currentMaxValue - currentMinValue;

                    //calculates where the box is to be drawn and its length
                    float startingPoint = (currentMinValue + offset) * pixelsPerUnit;
                    float boxLength = rangeBetweenMinAndMax * pixelsPerUnit;

                    RectangleF boxPlot = new RectangleF(100 + startingPoint, yBarPositions[i], boxLength, graphBarThickness);
                    
                    using (SolidBrush solidBrush = new SolidBrush(brushColour))
                    {
                        panelGraphics.FillRectangle(solidBrush, boxPlot);
                    }

                    //DRAW MIN AND MAX VALUES ALONGSIDE BOX PLOT
                    if (chkShowValues.Checked)
                    {
                        PointF minValueTextPoint = new PointF(100 + startingPoint, yBarPositions[i] + (graphBarThickness / 4));
                        PointF maxValueTextPoint = new PointF(100 + startingPoint + boxLength, yBarPositions[i] + (graphBarThickness / 4));

                        string drawMinValue = currentMinValue.ToString();
                        string drawMaxValue = currentMaxValue.ToString();

                        panelGraphics.DrawString(drawMinValue, smallerTextFont, writeBrush, minValueTextPoint);
                        panelGraphics.DrawString(drawMaxValue, smallerTextFont, writeBrush, maxValueTextPoint);
                    }
                }
            }
            else
            {
                float[] dataSet = selectedGraph.DataSet;

                //DRAWS SIMPLE BAR GRAPH
                for (int i = 0; i < numMonths; i++)
                {
                    float currentValue = dataSet[i];
                    float barLength = (currentValue - minValue) * pixelsPerUnit;

                    RectangleF bar = new RectangleF(100, yBarPositions[i], barLength, graphBarThickness);

                    using (SolidBrush solidBrush = new SolidBrush(brushColour))
                    {
                        panelGraphics.FillRectangle(solidBrush, bar);
                    }

                    //DRAW VALUE ALONGSIDE BAR
                    if (chkShowValues.Checked)
                    {
                        PointF valueTextPoint = new PointF(100 + barLength, yBarPositions[i] + (graphBarThickness / 4));
                        string drawBarValue = currentValue.ToString();
                        panelGraphics.DrawString(drawBarValue, smallerTextFont, writeBrush, valueTextPoint);
                    }
                }
            }                

            //DRAWS THE AXES OF THE GRAPH

            //y axis line 
            Point yStartPoint = new Point(100, 100);
            Point yEndPoint = new Point(100, 700);

            //x axis line
            Point xStartPoint = new Point(100, 700);
            Point xEndPoint = new Point(1100, 700);

            //draws the axes
            using (Pen linePen = new Pen(axesColor, axesSize))
            {
                panelGraphics.DrawLine(linePen, yStartPoint, yEndPoint);
                panelGraphics.DrawLine(linePen, xStartPoint, xEndPoint);
            }

            //goes through y position of each bar and adds month text eg. Jan on first bar on the graph
            for (int i = 0; i < numMonths; i++)
            {
                Point textPoint = new Point(5, yBarPositions[i] + (graphBarThickness / 4));
                string drawString = monthNames[i];
                panelGraphics.DrawString(drawString, normalTextFont, writeBrush, textPoint);
            }

            //WRITES GRAPH TITLE
            Point titlePoint = new Point(20, 20);
            string drawTitle = locationName + " " + yearDate + " - " + selectedGraph.GraphName;
            using (Font titleFont = new Font("Arial", 20))
            {
                panelGraphics.DrawString(drawTitle, titleFont, writeBrush, titlePoint);
            }

            //WRITES X AXIS LABEL
            Point xAxisLabelPoint = new Point(550, 750);
            string drawXAxisLabel = selectedGraph.GraphXAxisName;
            using (Font axisFont = new Font("Arial", 14))
            {
                panelGraphics.DrawString(drawXAxisLabel, axisFont, writeBrush, xAxisLabelPoint);
            }

            //Frees up memory
            normalTextFont.Dispose();
            smallerTextFont.Dispose();
            writeBrush.Dispose();
            panelGraphics.Dispose();
        }
    }
}
