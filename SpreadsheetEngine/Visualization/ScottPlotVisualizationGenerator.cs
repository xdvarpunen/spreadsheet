namespace Visualization
{
    public static class ScottPlotVisualizationGenerator
    {
        public static void GenerateLineChart()
        {
            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataY = new double[] { 1, 4, 9, 16, 25 };
            var plt = new ScottPlot.Plot(400, 300);
            plt.AddScatter(dataX, dataY);
            plt.SaveFig(@"C:\Temp\quickstart.png");
        }
    }
}
