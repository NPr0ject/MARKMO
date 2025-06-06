using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace labs
{
    public class PrimAlgorithm
    {
        private static int MinKey(int[] key, bool[] ar, int n)
        {
            int minimal = 400000000;
            int minIndex = -1;

            for (int v = 0; v < n; v++)
            {
                if (!ar[v] && key[v] < minimal)
                {
                    minimal = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private static void PrintAns(int[] parent, int[,] graph, int n)
        {
            Console.WriteLine("Ребра ");
            int TotalWeight = 0;
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine((parent[i] + 1) + " - " + (i + 1));
                TotalWeight += graph[i, parent[i]];
            }
            Console.Write("Общий вес: ");
            Console.WriteLine(TotalWeight);
        }
        public static void FindTree(int[,] graph)
        {
            int n = graph.GetLength(0);
            int[] parent = new int[n];
            int[] key = new int[n];
            bool[] ar = new bool[n];
            for (int i = 0; i < n; i++)
            {
                key[i] = int.MaxValue;
                ar[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < n - 1; count++)
            {
                int u = MinKey(key, ar, n);
                ar[u] = true;
                for (int v = 0; v < n; v++)
                {
                    if (graph[u, v] != 0 && !ar[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }
            PrintAns(parent, graph, n);
        }

        public static void Main()
        {
            int[,] graph = new int[,]
            {{ 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }};
            FindTree(graph);
        }
    }
}
