using Plotly.NET;
using Plotly.NET.ImageExport;

namespace Visualization
{
    public class PlotlyVisualizationGenerator
    {
        public static void GenerateBarChart()
        {
            var animals = new[] { "giraffes", "orangutans", "monkeys" };
            var sfValues = new[] { 20, 14, 23 };
            GenericChart.GenericChart column = Chart2D.Chart.Bar<int, string, string, string, string>(sfValues, animals);
            column.SavePNG(@"C:\Temp\ok", Width: 400, Height: 400);
        }
    }
}