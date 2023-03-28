using CommandLine;
using ConsoleTables;
using SpreadsheetEngine;

internal class Program
{
    private static void Main(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fileToProcess = Path.Combine(currentDirectory, "spreadsheet.json");

        var spreadSheet = new Spreadsheet();
        spreadSheet.SetTestSpreadsheet();

        Parser.Default.ParseArguments<Options>(args)
                           .WithParsed(o =>
                           {
                               if (o.PrintTable)
                               {
                                   var spreadsheetTable = spreadSheet.SpreadsheetToStringTable();
                                   var table = new ConsoleTable(spreadsheetTable[0].ToArray());
                                   for (int row = 1; row < spreadsheetTable.Count; row++)
                                   {
                                       table.AddRow(spreadsheetTable[row].ToArray());
                                   }
                                   table.Write();
                                   Console.WriteLine();
                               }
                               else if (o.ReadCellResult is not null)
                               {
                                   Console.WriteLine("Read cell...");
                                   Console.WriteLine(o.ReadCellResult);
                                   
                                   var cell = spreadSheet.Grid.ConvertStringRepresentationToColumnRow(o.ReadCellResult);
                                   if (cell is not null)
                                   {
                                       Console.WriteLine(cell.Result);
                                   }
                               }
                               else if (o.ReadCellCode is not null)
                               {
                                   Console.WriteLine("Read cell...");
                                   Console.WriteLine(o.ReadCellCode);

                                   var cell = spreadSheet.Grid.ConvertStringRepresentationToColumnRow(o.ReadCellCode);
                                   if (cell is not null)
                                   {
                                       Console.WriteLine();
                                       Console.WriteLine("---");
                                       foreach (var codeRow in cell.Code)
                                       {
                                           Console.WriteLine(string.Join(" ", codeRow));
                                       }
                                       Console.WriteLine("---");
                                       Console.WriteLine();
                                   }
                               }
                               // TODO START
                               else if (o.WriteCell is not null)
                               {
                                   Console.WriteLine("Write cell...");
                                   Console.WriteLine(o.WriteCell);

                                   var cell = spreadSheet.Grid.ConvertStringRepresentationToColumnRow(o.WriteCell);
                                   if (cell is not null)
                                   {
                                       // Write cell code
                                   }
                               }
                               // TODO END
                               else if (o.ExplainCell is not null)
                               {
                                   Console.WriteLine("Explain cell...");
                                   Console.WriteLine(o.ExplainCell);
                                   // see if cell exist
                                   var cell = spreadSheet.Grid.ConvertStringRepresentationToColumnRow(o.ExplainCell);
                                   Console.WriteLine(cell!.Key);
                                   // explain cell
                                   if (cell is not null)
                                   {
                                       var codeExplanation = ExplainerEngine.Explain(cell.Code);
                                       foreach (var explanation in codeExplanation)
                                       {
                                           Console.WriteLine(explanation);
                                       }
                                   }
                               }
                               else if (o.CurrentSpreadsheetFilePath)
                               {
                                   // Done
                                   Console.WriteLine($"Current file to be processed in path: {fileToProcess}");
                               }
                               else if (o.CreateSpreadsheet)
                               {
                                   // Done
                                   Helper.IsSpreadsheetCreated(fileToProcess);
                                   if (!File.Exists(fileToProcess))
                                   {
                                       Console.WriteLine($"Creating spreadsheet into path {fileToProcess}");
                                       File.Create(fileToProcess);
                                   }
                               }
                               else
                               {
                                   // Done
                                   Console.WriteLine("Spreadsheet CLI");
                               }
                           });
    }
}

public class Helper
{
    public static void IsSpreadsheetCreated(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"File does not exist in path {path}");
        }
    }
}

public class Options
{
    [Option('f', "currentSpreadsheetFilePath", Required = false, HelpText = "Show current spreadsheet file path.")]
    public bool CurrentSpreadsheetFilePath { get; set; }

    [Option('c', "createSpreadsheet", Required = false, HelpText = "Create spreadsheet.")]
    public bool CreateSpreadsheet { get; set; }

    [Option('a', "readCellResult", Required = false, HelpText = "Read cell result.")]
    public string? ReadCellResult { get; set; }

    [Option('r', "readCellCode", Required = false, HelpText = "Read cell code.")]
    public string? ReadCellCode { get; set; }

    [Option('w', "writeCell", Required = false, HelpText = "Write cell.")]
    public string? WriteCell { get; set; }

    [Option('e', "explainCell", Required = false, HelpText = "Explain cell.")]
    public string? ExplainCell { get; set; }

    [Option('p', "printTable", Required = false, HelpText = "Print table.")]
    public bool PrintTable { get; set; }

    // TODO: organize to verbs
}

// -p
// -e R1C1