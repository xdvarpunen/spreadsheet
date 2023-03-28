namespace Visualization.Test
{
    [TestFixture]
    public class PlotlyVisualizationGeneratorTest
    {
        [Test]
        public void Test1()
        {
            PlotlyVisualizationGenerator.GenerateBarChart();

            Assert.Pass();
        }
    }
}