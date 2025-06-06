using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiPLambdaSTR
{
    internal class Program
    {
        static void Main()
        {
            List<string> words = new List<string>{"apple", "Banana", "Apricot", "avocado", "Orange"};
            var filteredWords = words.Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Слова на английскую 'a':");
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
