using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace labs
{
    public class Deikstra
    {
        public static void FindPath(int[,] graph, int start, int end)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];
            bool[] visited = new bool[n];
            int[] pred = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = 400000000;
                pred[i] = -1;
            }
            distances[start] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int minDistance = 4000000;
                int dot = -1;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distances[j] <= minDistance)
                    {
                        minDistance = distances[j];
                        dot = j;
                    }
                }
                if (dot == end)
                {
                    break;
                }
                visited[dot] = true;
                for (int j = 0; j < n; j++)
                {
                    int rebroWeight = graph[dot, j];
                    if (rebroWeight == 0 || visited[j])
                    {
                        continue;
                    }
                    int newDistance = distances[dot] + rebroWeight;
                    if (newDistance < distances[j])
                    {
                        distances[j] = newDistance;
                        pred[j] = dot;
                    }
                }
            }
            List<int> path = new List<int>();
            int at = end;
            while (at != -1)
            {
                path.Add(at);
                at = pred[at];
            }
            path.Reverse();
            Console.WriteLine("Расстояние: " + distances[end]);
            Console.Write("Путь: ");
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write("- " +(path[i] + 1) + " -" );
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
            Console.WriteLine("Начальная вершина:");
            int start =  Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Конечная вершина:");
            int end = int.Parse(Console.ReadLine()) - 1;
            FindPath(graph, start, end);
        }
    }
}
