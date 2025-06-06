using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskrMost
{
    class Graph
    {
        int[,] Matrix;
        int n;
        public Graph(int[,] matrix)
        {
            Matrix = matrix;
            n = matrix.GetLength(0);
        }
        private void glubina(int a, bool[] visited)
        {
            visited[a] = true;
            for (int i = 0; i < n; i++)
            {
                if (Matrix[a, i] == 1 && !visited[i])
                {
                    glubina(i, visited);
                }
            }
        }
        private bool Connect()
        {
            bool[] visited = new bool[n];
            glubina(0, visited);

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                    return false;
            }
            return true;
        }
        public List<string> FindMost()
        {
            List<string> bridges = new List<string>();
            List<int[]> rebro = new List<int[]>();
            for (int u = 0; u < n; u++)
            {
                for (int v = u + 1; v < n; v++)
                {
                    if (Matrix[u, v] == 1)
                    {
                        rebro.Add(new int[] { u, v });
                    }
                }
            }
            for (int i = 0; i < rebro.Count; i++)
            {
                int u = rebro[i][0];
                int v = rebro[i][1];
                Matrix[u, v] = 0;
                Matrix[v, u] = 0;
                if (!Connect())
                {
                    bridges.Add((u + 1) + "-" + (v + 1));
                }
                Matrix[u, v] = 1;
                Matrix[v, u] = 1;
            }
            return bridges;
        }
    }
    class Program
    {
        static void Main()
        {
            int[,] matrix = {
            {0, 1, 1, 0, 0},
            {1, 0, 1, 1, 0},
            {1, 1, 0, 0, 0},
            {0, 1, 0, 0, 1},
            {0, 0, 0, 1, 0}
        };
            Graph g = new Graph(matrix);
            List<string> bridges = g.FindMost();
            Console.WriteLine("Мосты: ");
            for (int i = 0; i < bridges.Count; i++)
            {
                Console.WriteLine(bridges[i]);
            }
        }
    }
}
