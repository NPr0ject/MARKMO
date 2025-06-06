using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskrSviaznost
{
    class Graph
    {
        int[,] Matrix;
        int Size;
        public Graph(int[,] matrix)
        {
            Matrix = matrix;
            Size = matrix.GetLength(0);
        }

        public List<List<int>> ComponentSvyaznosti()
        {
            List<List<int>> components = new List<List<int>>();
            bool[] visited = new bool[Size];

            for (int i = 0; i < Size; i++)
            {
                if (!visited[i])
                {
                    List<int> component = new List<int>();
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);
                    visited[i] = true;
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        component.Add(current);
                        for (int j = 0; j < Size; j++)
                        {
                            if (Matrix[current, j] == 1 && !visited[j])
                            {
                                visited[j] = true;
                                queue.Enqueue(j);
                            }
                        }
                    }
                    components.Add(component);
                }
            }
            return components;
        }
    }
    class Program
    {
        static void Main()
        {
            int[,] matrix = {
            {0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0},
            {1, 0, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0}
        };
            Graph graph = new Graph(matrix);
            List<List<int>> components = graph.ComponentSvyaznosti();
            Console.WriteLine("Компоненты связности:");
            for (int i = 0; i < components.Count; i++)
            {
                for (int j = 0; j < components[i].Count; j++)
                {
                    if (j != 0) Console.Write(", ");
                    Console.Write(components[i][j] + 1);
                }
                Console.WriteLine();
            }
        }
    }
}
