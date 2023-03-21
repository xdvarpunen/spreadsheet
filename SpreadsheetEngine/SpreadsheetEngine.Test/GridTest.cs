namespace SpreadsheetEngine.Test;

[TestFixture]
public class GridTest
{
    [Test]
    public void GridShould()
    {
        // Arrange
        var grid = new Grid();
        
        // Act
        var cell1 = new Cell(1,2);
        cell1.Code = new List<List<string>>()
        {
            new List<string>()
            {
                "define",
                "x",
                "3"
            },
            new List<string>()
            {
                "return",
                "x",
            }
        };
        var cell2 = new Cell(2,2);
        cell2.Code = new List<List<string>>()
        {
            new List<string>()
            {
                "define",
                "x",
                "9"
            },
            new List<string>()
            {
                "return",
                "x",
            }
        };
        var cell3 = new Cell(3, 2);
        cell3.Code = new List<List<string>>()
        {
            new List<string>()
            {
                "define",
                "x",
                "R2C1"
            },
            new List<string>()
            {
                "define",
                "y",
                "R2C2"
            },
            new List<string>()
            {
                "sum",
                "x",
                "y"
            },
            new List<string>()
            {
                "return",
                "x",
            }
        };
        grid.Cells.Add(cell1);
        grid.Cells.Add(cell2);
        grid.Cells.Add(cell3);
        
        Dictionary<string, List<string>> Vertices = new Dictionary<string, List<string>>();
        foreach(var cell in grid.Cells)
        {
            Vertices[cell.Key] = Grid.GetCodeCellReferences(cell.Code).ToList();
        }

        var x = Vertices;

        GraphString gs = new GraphString();
        gs.Vertices = Vertices;
        var toposortedGrid = gs.TopologicalSort();
        var toposortedGridSorted = toposortedGrid.Reverse();

        var cellsComputedResults = new Dictionary<string, string>();

        foreach (var cellKey in toposortedGridSorted)
        {
            var cell = grid.Cells.Find(x => x.Key == cellKey);
            if(cell != null)
            {
                var indexOfCell = grid.Cells.IndexOf(cell);

                var value = InterpreterEngine.Interpret(cellsComputedResults, cell.Key, cell.Code);
            }
        }

        // Assert
        var expectedCellsComputedResults = new Dictionary<string, string>
        {
            { "R2C1", "3" },
            { "R2C2", "9" },
            { "R2C3", "12" }
        };
        Assert.That(cellsComputedResults.Count, Is.EqualTo(3));
        Assert.That(cellsComputedResults, Is.EquivalentTo(expectedCellsComputedResults));
    }
}
