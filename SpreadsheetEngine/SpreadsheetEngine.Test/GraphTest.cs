namespace SpreadsheetEngine.Test
{
    [TestFixture]
    public class GraphTest
    {
        [Test]
        public void GraphShouldCheckIsCyclic()
        {
            // Arrange
            var g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);

            // Act
            var isCyclic = g.IsCyclic();

            // Assert
            Assert.That(isCyclic, Is.True);
        }

        [Test]
        public void GraphShouldCheckIsNotCyclic()
        {
            // Arrange
            var g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);

            // Act
            var isCyclic = g.IsCyclic();

            // Assert
            Assert.That(isCyclic, Is.False);
        }

        [Test]
        public void GraphShouldCheckIsTopologicalSorted()
        {
            // Arrange
            var g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);
            var expectedTopologicallySortedGraph = new int[] { 5, 4, 3, 2, 1, 0 };

            // Act
            var topologicallySortedGraph = g.TopologicalSort();

            // Assert
            Assert.That(topologicallySortedGraph, Is.EquivalentTo(expectedTopologicallySortedGraph));
        }
    }
}