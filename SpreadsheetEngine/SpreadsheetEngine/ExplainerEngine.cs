namespace SpreadsheetEngine
{
    public class ExplainerEngine
    {
        public static string ExplainCodeRow(List<string> codeRow)
        {
            var explanation = string.Empty;
            if (codeRow[0] == "define")
            {
                explanation = $"define variable {codeRow[1]} and assign value {codeRow[2]}";
            } 
            else if (codeRow[0] == "sum")
            {
                explanation = $"add to variable {codeRow[1]} value {codeRow[2]}";
            }
            else if (codeRow[0] == "return")
            {
                explanation = $"assign cell with value {codeRow[1]}";
            }
            return explanation;
        }

        public static List<string> Explain(List<List<string>> code)
        {
            List<string> explanations = new List<string>();
            foreach (List<string> codeRow in code)
            {
                explanations.Add(ExplainCodeRow(codeRow));
            }

            return explanations;
        }
    }
}
