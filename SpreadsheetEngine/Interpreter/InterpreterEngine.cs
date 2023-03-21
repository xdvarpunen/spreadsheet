namespace Interpreter
{
    public static class InterpreterEngine
    {
        public static void InterpretCodeRow(List<string> codeRow)
        {
            // hmm
        }
        public static void Interpret(List<List<string>> code)
        {
            foreach (List<string> codeRow in code)
            {
                InterpretCodeRow(codeRow);
            }
        }
    }
}