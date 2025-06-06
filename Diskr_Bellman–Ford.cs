using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace labs
{
    public class FordBellman
    {
        public static void FindPaths(int[,] graph, int start)
        {
            int n  = graph.GetLength(0);
            int[] distant = new int[n];
            for (int i = 0; i < n; i++)
            {
                distant[i] = 400000000;
            }
            distant[start] = 0;
            for (int i = 1; i < n; i++)
            {
                bool updated = false;
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (graph[j, k] != 0)
                        {
                            if (distant[j] != 400000000 && distant[j] + graph[j, k] < distant[k])
                            {
                                distant[k] = distant[j] + graph[j, k];
                                updated = true;
                            }
                        }
                    }
                }
                if (!updated) {
                    break;
                }
            }
            Console.WriteLine($"Кратчайшие пути из вершины {(start + 1)}:");
            for (int i = 0; i < n; i++)
            {
                if (i != start)
                {
                    Console.Write("Длина пути в " + (i + 1) + ": ");
                    Console.WriteLine(distant[i]);
                }
            }
        }

        public static void Main()
        {
            int[,] graph = new int[,]
            {{ 0, 2, 0, 6, 0 },
             { 2, 0, 3, 8, 5 },
             { 0, 3, 0, 0, 7 },
             { 6, 8, 0, 0, 9 },
             { 0, 5, 7, 9, 0 }};
            int start = 0;
            FindPaths(graph, start);
        }
    }
}
