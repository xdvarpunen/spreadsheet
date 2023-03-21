namespace SpreadsheetEngine;

public class Grid
{
    public const int minimumColumn = 0;
    public const int maximumColumn = 100;
    public const int minimumRow = 0;
    public const int maximumRow = 100;
    public List<Cell> Cells { get; set; } = new();

    public Grid() 
    { 
        
    }

    public void InitializeGrid()
    {
        for (int row = minimumRow; row < maximumRow; row++)
        {
            for (int column = minimumColumn; column < maximumColumn; column++)
            {
                //var cell = new Cell();
                //cell.Row = row;
                //cell.Column = column;
                //// TODO: add Dictionary key
                //Cells.Add(cell);
            }
        }
    }

    public static string ConvertColumnRowToStringRepresentation(int columnIndex, int rowIndex) {
        return "C"+columnIndex+"R"+rowIndex;
    }

    public static bool IsColumnRowCell(string cell)
    {
        bool isColumnRowCell = false;

        var indexOfC = cell.IndexOf("C");
        var indexOfR = cell.IndexOf("R");

        if(indexOfC != -1 && indexOfR != -1) 
        {
            var column = cell.Substring(1, indexOfC-1);
            var row = cell[(indexOfC+1)..];

            var isColumnNumeric = int.TryParse(column, out _);
            var isRowNumeric = int.TryParse(row, out _);

            isColumnRowCell = isColumnNumeric && isRowNumeric;
        }

        return isColumnRowCell;
    }

    public static HashSet<string> GetCodeCellReferences(List<List<string>> code)
    {
        HashSet<string> cellReferences = new();
            
        foreach (var codeRow in code)
        {
            var functionParameters = codeRow.Skip(1).ToArray();
            foreach (var parameter in functionParameters)
            {
                if(IsColumnRowCell(parameter))
                {
                    cellReferences.Add(parameter);
                }
            }
        }

        return cellReferences;
    }
}

// Grid
// columns 0-100, rows 0-100
// Cell CNRN
// other Cell references

// Toposort