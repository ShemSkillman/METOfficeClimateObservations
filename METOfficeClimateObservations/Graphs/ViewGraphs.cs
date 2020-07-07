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
    public partial class ViewGraphs : Form
    {
        string locationName;
        Year year;
        string[] monthNames;

        int[] yBarPositions;
        Graph[] graphs;

        // Graph bar config
        int graphBarSpacing = 10;
        int graphBarThickness = 40;
        const int maxBarLength = 1000;
        int barTextPosBuffer = 4;
        int barPosYOffset = 95;

        // Font config
        Color fontColor = Color.Black;
        Font axesFont = new Font("Arial", 12);
        Font graphValuesFont = new Font("Arial", 11);
        Font titleFont = new Font("Arial", 20);
        Font axisLabelFont = new Font("Arial", 14);

        // Axes config
        int axesThickness = 4;
        Color axesColor = Color.Black;
        Point yAxisStartPoint = new Point(100, 100);
        Point yAxisEndPoint = new Point(100, 700);
        Point xAxisStartPoint = new Point(100, 700);
        Point xAxisEndPoint = new Point(1100, 700);
        int yAxisMonthTextStartPosX = 5;
        Point titlePoint = new Point(20, 20);
        Point xAxisLabelPoint = new Point(550, 750);

        // Vertical interval lines config
        int VerticalIntervalGridLineThickness = 2;
        Color VerticalIntervalGridLineColour = Color.LightGray;
        float graphStartPosX = 100;
        float intervalStartY = 715;
        float intervalEndY = 100;
        float intervalTextOffset = -10;

        public ViewGraphs(Location location, int yearIndex, string[] monthNames)
        {
            InitializeComponent();

            locationName = location.LocationName;
            year = location.Years[yearIndex];
            this.monthNames = monthNames;

            CalculateGraphBarsYPos();

            // Creates graphs
            ExtractData();

            InitializeGraphSelection();

            Refresh();
        }

        // Y position of each bar calculated once, remains constant
        private void CalculateGraphBarsYPos()
        {
            int numMonths = monthNames.Length;

            yBarPositions = new int[numMonths];

            //sets position of each bar from Jan - Dec
            for (int i = 0; i < numMonths; i++)
            {
                yBarPositions[i] = barPosYOffset + graphBarSpacing + (graphBarThickness + graphBarSpacing) * i;
            }
        }

        private void ExtractData()
        {
            int numMonths = monthNames.Length;

            // Array stores all month obs data of category
            float[] monthsAirFrostData = new float[numMonths], monthsRainfallData = new float[numMonths], 
                monthsSunshineData = new float[numMonths], monthsMinTempData = new float[numMonths], 
                monthsMaxTempData = new float[numMonths];

            // Extract from year 
            for (int i = 0; i < numMonths; i++)
            {
                monthsAirFrostData[i] = year.MonthObs[i].NumDaysAirFrost;
                monthsRainfallData[i] = year.MonthObs[i].MillimetresRainfall;
                monthsSunshineData[i] = year.MonthObs[i].NumHoursSunshine;
                monthsMinTempData[i] = year.MonthObs[i].MinTemp;
                monthsMaxTempData[i] = year.MonthObs[i].MaxTemp;
            }

            CreateGraphs(monthsAirFrostData, monthsRainfallData, monthsSunshineData, monthsMinTempData, monthsMaxTempData);
        }
        
        private void CreateGraphs(float[] monthsAirFrostData, float[] monthsRainfallData, float[] monthsSunshineData,
            float[] monthsMinTempData, float[] monthsMaxTempData)
        {
            Graph sunshineHoursGraph = new Graph("Monthly Hours of Sunshine", "Number of Hours", 20f, 1000f, 0f, monthsSunshineData, Color.Yellow);
            Graph airFrostDaysGraph = new Graph("Monthly Days of Airfrost", "Number of Days", 5f, 1000f, 0f, monthsAirFrostData, Color.LightBlue);
            Graph rainfallGraph = new Graph("Monthly Amount of Rainfall", "Rainfall (mm)", 10f, 1000f, 0f, monthsRainfallData, Color.RoyalBlue);
            Graph minAndMaxTempGraph = new BoxPlotGraph("Monthly Minimum and Maximum Temperature", "Temperature", 2f, 100f, -100f, Color.Orange, monthsMinTempData, monthsMaxTempData);

            graphs = new Graph[] {minAndMaxTempGraph, sunshineHoursGraph, airFrostDaysGraph, rainfallGraph };
        }

        // Displays graph selections in combobox
        private void InitializeGraphSelection()
        {
            foreach (Graph graph in graphs)
            {
                cboxMonthDataTypes.Items.Add(graph.GraphName);
            }

            cboxMonthDataTypes.SelectedIndex = 0;
        }

        // Graph selection refreshes graphics panel
        private void cboxMonthDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        // Checkbox checked/unchecked refreshes graphics panel
        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        // Called when form refreshed, redraws graph based on selection
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graph graph = graphs[cboxMonthDataTypes.SelectedIndex];

            // Used to set up appropriate axes
            float overallRange = graph.YearMaxValue - graph.YearMinValue;

            // Graph size remains constant
            float pixelsPerUnit = maxBarLength / overallRange;

            using (Graphics panelGraphics = DrawingPanel.CreateGraphics())
            using (SolidBrush writeBrush = new SolidBrush(fontColor))
            {

                DrawVerticalGraphIntervals(graph, panelGraphics, writeBrush, pixelsPerUnit);

                if (graph is BoxPlotGraph boxPlotGraph)
                    DrawBoxPlotGraph(panelGraphics, writeBrush, overallRange, pixelsPerUnit, boxPlotGraph);
                else
                    DrawSimpleBarGraph(graph, panelGraphics, writeBrush, pixelsPerUnit);

                DrawAxes(graph, panelGraphics, writeBrush);
            }            
        }

        // Draws axes, labels and title
        private void DrawAxes(Graph graph, Graphics panelGraphics, SolidBrush writeBrush)
        {           
            using (Pen linePen = new Pen(axesColor, axesThickness))
            {
                panelGraphics.DrawLine(linePen, yAxisStartPoint, yAxisEndPoint);
                panelGraphics.DrawLine(linePen, xAxisStartPoint, xAxisEndPoint);
            }

            // Iterates through each bar and assigns month text eg. Jan on first bar on the graph
            for (int i = 0; i < monthNames.Length; i++)
            {
                Point textPoint = new Point(yAxisMonthTextStartPosX, yBarPositions[i] + (graphBarThickness / barTextPosBuffer));
                panelGraphics.DrawString(monthNames[i], axesFont, writeBrush, textPoint);
            }

            // Write graph title
            string drawTitle = locationName + " " + year.YearDate + " - " + graph.GraphName;
            panelGraphics.DrawString(drawTitle, titleFont, writeBrush, titlePoint);

            // Write X axis label
            string drawXAxisLabel = graph.GraphXAxisName;
            panelGraphics.DrawString(drawXAxisLabel, axisLabelFont, writeBrush, xAxisLabelPoint);
        }

        // Draws horizontal bar graph, left to right
        private void DrawSimpleBarGraph(Graph graph, Graphics panelGraphics, SolidBrush writeBrush, float pixelsPerUnit)
        {
            float[] dataSet = graph.DataSet;

            for (int i = 0; i < monthNames.Length; i++)
            {
                float currentValue = dataSet[i];

                // Takes into accout bar offset
                float barLength = (currentValue - graph.YearMinValue) * pixelsPerUnit;

                RectangleF bar = new RectangleF(graphStartPosX, yBarPositions[i], barLength, graphBarThickness);

                using (SolidBrush solidBrush = new SolidBrush(graph.GraphBarColour))
                {
                    panelGraphics.FillRectangle(solidBrush, bar);
                }

                // Show bar values (optional)
                if (chkShowValues.Checked)
                {
                    PointF valueTextPoint = new PointF(graphStartPosX + barLength, yBarPositions[i] + (graphBarThickness / barTextPosBuffer));
                    string drawBarValue = currentValue.ToString();
                    panelGraphics.DrawString(drawBarValue, graphValuesFont, writeBrush, valueTextPoint);
                }
            }
        }

        // Bars have a varied start point with provided min and max values
        private void DrawBoxPlotGraph(Graphics panelGraphics, SolidBrush writeBrush, float overallRange, float pixelsPerUnit, BoxPlotGraph bpGraph)
        {
            // Offset required due to negative values
            float offset = overallRange - bpGraph.YearMaxValue;

            for (int i = 0; i < monthNames.Length; i++)
            {
                // Min and Max temp of month
                float currentMinValue = bpGraph.MinDataSet[i];
                float currentMaxValue = bpGraph.MaxDataSet[i];

                float rangeBetweenMinAndMax = currentMaxValue - currentMinValue;

                // Calculates how box is drawn
                float startingPoint = (currentMinValue + offset) * pixelsPerUnit;
                float boxLength = rangeBetweenMinAndMax * pixelsPerUnit;

                RectangleF boxPlot = new RectangleF(graphStartPosX + startingPoint, yBarPositions[i], boxLength, graphBarThickness);

                using (SolidBrush solidBrush = new SolidBrush(bpGraph.GraphBarColour))
                {
                    panelGraphics.FillRectangle(solidBrush, boxPlot);
                }

                // Draw min and max values alongside boxplot (optional)
                if (chkShowValues.Checked)
                {
                    PointF minValueTextPoint = new PointF(graphStartPosX + startingPoint, yBarPositions[i] + (graphBarThickness / 4));
                    PointF maxValueTextPoint = new PointF(graphStartPosX + startingPoint + boxLength, yBarPositions[i] + (graphBarThickness / 4));

                    string drawMinValue = currentMinValue.ToString();
                    string drawMaxValue = currentMaxValue.ToString();

                    panelGraphics.DrawString(drawMinValue, graphValuesFont, writeBrush, minValueTextPoint);
                    panelGraphics.DrawString(drawMaxValue, graphValuesFont, writeBrush, maxValueTextPoint);
                }
            }
        }

        private void DrawVerticalGraphIntervals(Graph graph, Graphics panelGraphics, SolidBrush writeBrush, float pixelsPerUnit)
        {
            // Writes graph interval values under the X axis
            for (float currentValue = graph.YearMinValue, i = 0; currentValue <= graph.YearMaxValue; currentValue += graph.GraphInterval, i++)
            {
                float intervalDist = i * pixelsPerUnit * graph.GraphInterval;

                // Value printed under each interval line
                PointF textPoint = new PointF(graphStartPosX + intervalDist, intervalStartY + intervalTextOffset);
                string drawString = currentValue.ToString();
                panelGraphics.DrawString(drawString, axesFont, writeBrush, textPoint);

                // Draws faint line at each interval on graph
                using (Pen linePen = new Pen(VerticalIntervalGridLineColour, VerticalIntervalGridLineThickness))
                {
                    panelGraphics.DrawLine(linePen, graphStartPosX + intervalDist, intervalStartY, graphStartPosX + intervalDist, intervalEndY);
                }
            }
        }
    }
}
