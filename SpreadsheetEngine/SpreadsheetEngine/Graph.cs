namespace SpreadsheetEngine
{
    public class Graph
    {
        public int NumberOfVertices { get; set; }
        public Dictionary<int, List<int>> Vertices { get; set; } = new Dictionary<int, List<int>>();
        public Graph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;

            for (int i = 0; i < numberOfVertices; i++)
            {
                Vertices[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex, int edge)
        {
            if (Vertices.ContainsKey(vertex))
            {
                Vertices[vertex].Add(edge);
            }
            else
            {
                Vertices[vertex] = new List<int>() { edge };
            }
        }

        public void TopologicalSortUtil(int vertex, List<bool> visited, List<int> stack)
        {
            visited[vertex] = true;

            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == false)
                {
                    TopologicalSortUtil(i, visited, stack);
                }
            }

            stack.Add(vertex);
        }

        public int[] TopologicalSort()
        {
            var visited = new List<bool>();
            var stack = new List<int>();

            for (int i = 0; i < NumberOfVertices; i++)
            {
                visited.Add(false);
            }

            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (visited[i] == false)
                {
                    TopologicalSortUtil(i, visited, stack);
                }
            }

            //for (int i = 0; i < NumberOfVertices; i++)
            //{
            //    Console.WriteLine(stack[i]);
            //}

            return stack.ToArray();
        }

        public bool IsCyclicUtil(int vertex, List<bool> visited, List<bool> stack)
        {
            if (stack[vertex])
            {
                return true;
            }

            if (visited[vertex])
            {
                return false;
            }

            visited[vertex] = true;

            stack[vertex] = true;

            List<int> children = Vertices[vertex];
            for (int i = 0; i < children.Count; i++)
            {
                if(children.Count != 0)
                {
                    if (IsCyclicUtil(children[i], visited, stack))
                    {
                        return true;
                    }
                }
            }

            stack[vertex] = false;

            return false;
        }

        public bool IsCyclic()
        {
            var visited = new List<bool>();
            var stack = new List<bool>();

            for (int i = 0; i < NumberOfVertices; i++)
            {
                visited.Add(false);
                stack.Add(false);
            }

            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (IsCyclicUtil(i, visited, stack))
                {
                    return true;
                }
            }

            return false;
        }
    }
}