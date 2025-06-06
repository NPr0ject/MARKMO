using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication22
{
    class Program
    {
        public static int[,] Graph(int[,] oldgraph, int n)
        {
            int[,] dist = new int[n, n];
            // матрица растояний
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        dist[i, j] = int.MinValue;
                    }
                    else if (oldgraph[i, j] == -1)
                    {
                        dist[i, j] = int.MaxValue;
                    }
                    else
                    {
                        dist[i, j] = oldgraph[i, j];
                    }
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue && dist[i, k] != int.MinValue && dist[k, j] != int.MinValue)
                        {
                            if (dist[i, j] > dist[i, k] + dist[k, j])
                            {
                                dist[i, j] = dist[i, k] + dist[k, j];
                            }
                        }
                    }
                }
            }
            return dist;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] graph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] arrau = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    graph[i, j] = Convert.ToInt32(arrau[j]);
                }
            }
            Console.WriteLine("2 have");
            int[,] ans = Graph(graph, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine(ans[i, j]);
                }
            }
        }
    }
}
