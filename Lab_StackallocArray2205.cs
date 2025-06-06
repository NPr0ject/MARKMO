using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiP_StackallocArray
{
    unsafe class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char** lines = stackalloc char*[256];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                char* line = stackalloc char[s.Length + 1];
                for (int j = 0; j < s.Length; j++)
                {
                    line[j] = s[j];
                }
                line[s.Length] = '\0'; // нуль-терминатор в конце строки
                lines[i] = line;
            }
            int* charArray = stackalloc int[256];
            for (int i = 0; i < 256; i++)
            {
                charArray[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                char* line = lines[i];
                int j = 0;
                while (line[j] != '\0') // Пока не встретим нуль терминатор
                {
                    charArray[line[j]]++;
                    j++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                if (charArray[i] > 0)
                {
                    Console.WriteLine($"{(char)i}: {charArray[i]} раз");
                }
            }
        }
    }
}
