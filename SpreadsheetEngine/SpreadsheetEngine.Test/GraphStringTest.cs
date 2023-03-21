namespace SpreadsheetEngine.Test
{
    [TestFixture]
    public class GraphStringTest
    {
        [Test]
        public void GraphStringShouldCheckIsCyclic()
        {
            // Arrange
            var g = new GraphString();
            g.AddEdge("A", "B");
            g.AddEdge("B", "C");
            g.AddEdge("C", "A");

            // Act
            var isCyclic = g.IsCyclic();

            // Assert
            Assert.That(isCyclic, Is.True);
        }

        [Test]
        public void GraphShouldCheckIsNotCyclic()
        {
            // Arrange
            var g = new GraphString();
            g.AddEdge("A", "B");
            g.AddEdge("B", "C");
            g.AddEdge("C", "D");

            // Act
            var isCyclic = g.IsCyclic();

            // Assert
            Assert.That(isCyclic, Is.False);
        }

        [Test]
        public void GraphShouldCheckIsTopologicalSorted()
        {
            // Arrange
            var g = new GraphString();
            g.AddEdge("A", "B");
            g.AddEdge("B", "C");
            g.AddEdge("C", "D");
            var expectedTopologicallySortedGraph = new string[] { "D", "C", "B", "A" };

            // Act
            var topologicallySortedGraph = g.TopologicalSort();

            // Assert
            Assert.That(topologicallySortedGraph, Is.EquivalentTo(expectedTopologicallySortedGraph));
        }
    }
}
