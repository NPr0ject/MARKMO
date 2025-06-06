using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace labs
{
    namespace labs
    {
        public class Kruskal
        {
            private static int Find(int[] parents, int vertex)
            {
                while (parents[vertex] != vertex)
                {
                    parents[vertex] = parents[parents[vertex]];
                    vertex = parents[vertex];
                }
                return vertex;
            }
            public static void FindTree(int[,] graph)
            {
                int n = graph.GetLength(0);
                List<int[]> rebra = new List<int[]>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (graph[i, j] != 0)
                        {
                            rebra.Add(new int[] { i, j, graph[i, j] });
                        }
                    }
                }
                rebra.Sort((a, b) => a[2].CompareTo(b[2]));
                int[] parents = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parents[i] = i;
                }
                int selectrebro = 0;
                int currentrebro = 0;
                List<int[]> ansewer = new List<int[]>();
                while (selectrebro < n - 1)
                {
                    int[] edge = rebra[currentrebro++];
                    int predFrom = Find(parents, edge[0]);
                    int predTo = Find(parents, edge[1]);
                    if (predFrom != predTo)
                    {
                        ansewer.Add(edge);
                        parents[predTo] = predFrom;
                        selectrebro++;
                    }
                }
                // Вывод результата
                Console.WriteLine("Ребра: ");
                for (int i = 0; i < ansewer.Count; i++)
                {
                    Console.WriteLine((ansewer[i][0] + 1) + "-" + (ansewer[i][1] + 1));
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
                FindTree(graph);
            }
        }
    }
}
