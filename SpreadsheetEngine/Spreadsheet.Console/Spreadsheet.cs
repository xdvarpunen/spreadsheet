using SpreadsheetEngine;

namespace Spreadsheet.Console;
public class Spreadsheet
{
    private readonly Grid grid;

    public Spreadsheet() 
    { 
        grid = new Grid();
    }

    public void PrintSpreadsheet()
    {
        foreach(var cell in grid.Cells)
        {
            // hmm
        }
    }

    public void EditCell(string cellKey, string cellContent)
    {
        // hmm
        
    }

    private void ComputeCells()
    {
        // hmm

        //// Easy
        //// DictionaryOfCellsReferences[Cell] = [Cells]
        //Dictionary<string, List<string>> Vertices = new Dictionary<string, List<string>>();
        //foreach (var cell in grid.Cells)
        //{
        //    Vertices[cell.Key] = Grid.GetCodeCellReferences(cell.Code).ToList();
        //}

        //var x = Vertices;

        //GraphString gs = new GraphString();
        //gs.Vertices = Vertices;
        //var toposortedGrid = gs.TopologicalSort();
        //var toposortedGridSorted = toposortedGrid.Reverse();

        ////grid.Cells[0].Result = "";
        //var cellsComputedResults = new Dictionary<string, string>();

        //// TODO: finish interpreter engine
        //// Interpret
        //foreach (var cellKey in toposortedGridSorted)
        //{
        //    var cell = grid.Cells.Find(x => x.Key == cellKey);
        //    if (cell != null)
        //    {
        //        var indexOfCell = grid.Cells.IndexOf(cell);
        //        // Context, other cells result/value

        //        // Interpreter engine should be shell feature?
        //        var value = InterpreterEngine.Interpret(cellsComputedResults, cell.Key, cell.Code);
        //        //cellsComputedResults.Add(cellKey, value);
        //    }
        //}
    }
}