namespace SpreadsheetEngine;

public class Cell
{
    public int Column { get; }
    public int Row { get; }
    public string Key { get; }
    public HashSet<string> CellReferences { get; set; } = new();
    public Dictionary<string, object> Context { get; set; } = new();
    public string Result { get; set; } = string.Empty;
    public List<List<string>> Code { get; set; } = new();
    public Cell(int column, int row)
    {
        Column = column;
        Row = row;
        Key = "R" + Row + "C" + Column;
    }

    public List<string> CodeExplained { get; set; } = new();
}