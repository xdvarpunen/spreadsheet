namespace SpreadsheetEngine
{
    public class Spreadsheet
    {
        public Grid Grid { get; set; } = new Grid();
        public void SetTestSpreadsheet()
        {
            // prefilled spreadsheet
            var grid = new Grid();

            var cells = new List<Cell>();
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    var cell = new Cell(column, row);
                    cell.Result = $"C{column}R{row}";
                    cell.Code = new List<List<string>>()
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
                    cells.Add(cell);
                }
            }

            grid.Cells = cells;
            Grid = grid;
        }

        public List<List<string>> SpreadsheetToStringTable()
        {
            var table = new List<List<string>>();
            for (int row = 0; row < 10; row++)
            {
                var tableRow = new List<string>();
                for (int column = 0; column < 10; column++)
                {
                    var cell = Grid.GetCell(column, row);
                    tableRow.Add(cell!.Result);
                }
                table.Add(tableRow);
            }
            return table;
        }

        public string ExplainCell(string cell)
        {
            // TODO
            return string.Empty;
        }

        public void SetCell(string cellKey, string cellContent)
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
}
