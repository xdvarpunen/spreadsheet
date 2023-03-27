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
                               // TODO START
                               if (o.PrintTable)
                               {
                                   // TODO: what is the format saved in?
                                   var spreadsheetTable = spreadSheet.SpreadsheetToStringTable();
                                   var table = new ConsoleTable(spreadsheetTable[0].ToArray());
                                   for (int row = 1; row < spreadsheetTable.Count; row++)
                                   {
                                       table.AddRow(spreadsheetTable[row].ToArray());
                                   }
                                   table.Write(Format.Minimal);
                                   Console.WriteLine();

                                   //Helper.IsSpreadsheetCreated(fileToProcess);
                                   //Console.WriteLine($"File processed: {fileToProcess}");
                                   //Console.WriteLine("Print table...");
                                   //var table = new ConsoleTable("one", "two", "three");
                                   //table.Configure(o => o.NumberAlignment = Alignment.Right);

                                   //table.AddRow(1, 2, 3);
                                   //table.AddRow("this line should be longer", "yes it is", "oh");

                                   ////table.Write();
                                   ////table.Write(Format.Alternative);

                                   //table.Write(Format.Minimal);
                                   //Console.WriteLine();
                               }
                               else if (o.ModifyCell is not null)
                               {
                                   Console.WriteLine("Modify cell...");
                                   Console.WriteLine(o.ModifyCell);
                                   // see if cell exist
                                   // write cell
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
    [Option('m', "modifyCell", Required = false, HelpText = "Modify cell.")]
    public string? ModifyCell { get; set; }
    [Option('e', "explainCell", Required = false, HelpText = "Explain cell.")]
    public string? ExplainCell { get; set; }
    [Option('p', "printTable", Required = false, HelpText = "Print table.")]
    public bool PrintTable { get; set; }
}
