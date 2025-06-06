using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskrFordFalkerson
{
    public class FordFulkerson
    {
        private readonly int V;
        private int[,] resGraph;
        public FordFulkerson(int[,] graph)
        {
            V = graph.GetLength(0);
            resGraph = new int[V, V];
            for (int u = 0; u < V; u++)
            {
                for (int v = 0; v < V; v++)
                {
                    resGraph[u, v] = graph[u, v];
                }
            }
        }
        private bool BFS(int s, int t, out int[] parent)
        {
            parent = new int[V];
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && resGraph[u, v] > 0)
                    {
                        if (v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }
            return false;
        }
        public int MaxFlow(int s, int t)
        {
            int maxFlow = 0;
            int[] parent;
            while (BFS(s, t, out parent))
            {
                int pathFlow = int.MaxValue;
                for (int v = t; v != s; v = parent[v])
                {
                    int u = parent[v];
                    pathFlow = Math.Min(pathFlow, resGraph[u, v]);
                }
                for (int v = t; v != s; v = parent[v])
                {
                    int u = parent[v];
                    resGraph[u, v] -= pathFlow;
                    resGraph[v, u] += pathFlow;
                }
                maxFlow += pathFlow;
            }
            return maxFlow;
        }
        public static void Main()
        {
            int[,] graph = new int[,] {
            {0, 16, 13, 0, 0, 0},
            {0, 0, 10, 12, 0, 0},
            {0, 4, 0, 0, 14, 0},
            {0, 0, 9, 0, 0, 20},
            {0, 0, 0, 7, 0, 4},
            {0, 0, 0, 0, 0, 0}
        };

            FordFulkerson ff = new FordFulkerson(graph);
            int source = 0;
            int sink = 5;

            int maxFlow = ff.MaxFlow(source, sink);
            Console.WriteLine("Максимальный поток: " + maxFlow);
        }
    }
}
