using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskrLittleAlgorithm
{
    public class LittleAlgorithm
    {
        private int[,] costMatrix;
        private int size;
        private int[,] path;
        private int minCost = int.MaxValue;
        private int[] bestRoute;

        public LittleAlgorithm(int[,] matrix)
        {
            costMatrix = (int[,])matrix.Clone();
            size = matrix.GetLength(0);
            path = new int[size, size];
            bestRoute = new int[size + 1];
        }

        public (int[,] path, int cost, int[] route) FindOptimalPath()
        {
            int[] route = new int[size + 1];
            bool[] visited = new bool[size];
            route[0] = 0; // Начинаем с вершины 0
            visited[0] = true;

            BranchAndBound(1, route, visited, 0, (int[,])costMatrix.Clone());

            return (path, minCost, bestRoute);
        }

        private void BranchAndBound(int step, int[] route, bool[] visited, int currentCost, int[,] matrix)
        {
            if (step == size)
            {
                // Завершаем цикл
                int finalCost = currentCost + matrix[route[step - 1], route[0]];
                if (finalCost < minCost && matrix[route[step - 1], route[0]] != int.MaxValue)
                {
                    minCost = finalCost;
                    Array.Copy(route, bestRoute, size);
                    bestRoute[size] = route[0];
                    UpdatePathMatrix(route);
                }
                return;
            }

            for (int next = 0; next < size; next++)
            {
                if (!visited[next] && matrix[route[step - 1], next] != int.MaxValue)
                {
                    int newCost = currentCost + matrix[route[step - 1], next];
                    if (newCost >= minCost) continue;

                    route[step] = next;
                    visited[next] = true;
                    int[,] newMatrix = (int[,])matrix.Clone();
                    newMatrix[route[step - 1], next] = int.MaxValue;

                    BranchAndBound(step + 1, route, visited, newCost, newMatrix);

                    visited[next] = false;
                }
            }
        }

        private void UpdatePathMatrix(int[] route)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    path[i, j] = 0;
            for (int i = 0; i < size; i++)
            {
                int from = route[i];
                int to = route[(i + 1) % size];
                path[from, to] = costMatrix[from, to];
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            int[,] Matrix = new int[,]
            {
                { int.MaxValue, 26, 42, 15, 29, 25 },
                { 1, int.MaxValue, 16, 1, 30, 25 },
                { 20, 13, int.MaxValue, 35, 5, 0 },
                { 21, 16, 25, int.MaxValue, 18, 18 },
                { 12, 46, 27, 48, int.MaxValue, 5 },
                { 23, 5, 5, 9, 5, int.MaxValue }
            };

            var solver = new LittleAlgorithm(Matrix);
            var result = solver.FindOptimalPath();
            Console.WriteLine("\nОптимальный путь:");
            Console.WriteLine(string.Join(" -> ", result.route.Select(x => x + 1)));
            Console.WriteLine($"Минимальная стоимость: {result.cost}");
        }
    }
}
