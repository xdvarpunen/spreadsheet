namespace SpreadsheetEngine
{
    public class GraphString
    {
        public int NumberOfVertices { get; set; } = 0;
        public Dictionary<string, List<string>> Vertices { get; set; } = new Dictionary<string, List<string>>();
        public GraphString() { }

        public void AddEdge(string vertex, string edge)
        {
            if (Vertices.ContainsKey(vertex))
            {
                Vertices[vertex].Add(edge);
            }
            else
            {
                Vertices[vertex] = new List<string>() { edge };
            }

            if (!Vertices.ContainsKey(edge))
            {
                Vertices[edge] = new List<string>();
            }

            NumberOfVertices++;
        }

        public void RemoveEdge(string vertex, string edge)
        {
            if (Vertices.ContainsKey(vertex))
            {
                if (Vertices[vertex].Count > 1)
                {
                    Vertices[vertex].Remove(edge);
                } else
                {
                    Vertices.Remove(vertex);
                }
            }
        }

        public void TopologicalSortUtil(string vertexKey, Dictionary<string, bool> visited, List<string> stack)
        {
            visited[vertexKey] = true;

            foreach (var vertex in Vertices)
            {
                if (visited[vertex.Key] == false)
                {
                    TopologicalSortUtil(vertex.Key, visited, stack);
                }
            }

            stack.Add(vertexKey);
        }

        public string[] TopologicalSort()
        {
            var visited = new Dictionary<string, bool>();
            var stack = new List<string>();

            foreach (var vertex in Vertices)
            {
                visited[vertex.Key] = false;
            }

            foreach (var vertex in Vertices)
            {
                if (visited[vertex.Key] == false)
                {
                    TopologicalSortUtil(vertex.Key, visited, stack);
                }
            }

            return stack.ToArray();
        }

        public bool IsCyclicUtil(string vertexKey, Dictionary<string, bool> visited, Dictionary<string, bool> stack)
        {
            if (stack[vertexKey])
            {
                return true;
            }

            if (visited[vertexKey])
            {
                return false;
            }

            visited[vertexKey] = true;

            stack[vertexKey] = true;

            List<string> children = Vertices[vertexKey];

            for (int i = 0; i < children.Count; i++)
            {
                if (children.Count != 0)
                {
                    if (IsCyclicUtil(children[i], visited, stack))
                    {
                        return true;
                    }
                }
            }

            stack[vertexKey] = false;

            return false;
        }

        public bool IsCyclic()
        {
            var visited = new Dictionary<string,bool>();
            var stack = new Dictionary<string, bool>();

            foreach (var vertex in Vertices)
            {
                visited[vertex.Key] = false;
                stack[vertex.Key] = false;
            }

            foreach (var vertex in Vertices)
            {
                if (IsCyclicUtil(vertex.Key, visited, stack))
                {
                    return true;
                }
            }

            return false;
        }
    }
}