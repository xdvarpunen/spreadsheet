using System.ComponentModel;

namespace SpreadsheetEngine
{
    public class InterpreterEngine
    {
        public static void InterpretCodeRow(
            Dictionary<string, string> cellsComputedResult, string cellKey, Dictionary<string, string> cellContext, List<string> codeRow)
        {
            if (codeRow[0] == "define")
            {
                if (!cellsComputedResult.ContainsKey(codeRow[2]))
                {
                    cellContext[codeRow[1]] = codeRow[2];
                } else
                {
                    cellContext[codeRow[1]] = cellsComputedResult[codeRow[2]];
                }
            }
            if (codeRow[0] == "sum")
            {
                int param1 = int.Parse(cellContext[codeRow[1]]);
                int param2 = int.Parse(cellContext[codeRow[2]]);
                cellContext[codeRow[1]] = (param1 + param2).ToString();
            }
            if (codeRow[0] == "return")
            {
                cellsComputedResult[cellKey] = cellContext[codeRow[1]];
            }
        }

        public static string Interpret(Dictionary<string,string> cellsComputedResult, string cellKey, List<List<string>> code)
        {
            var cellContext = new Dictionary<string, string>();
            foreach (List<string> codeRow in code)
            {
                InterpretCodeRow(cellsComputedResult, cellKey, cellContext, codeRow);
            }

            return "";
        }
    }
}
