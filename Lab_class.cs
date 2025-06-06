using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWith4act
{
    class Calculator
    {
        public int a;
        public int b;
        public Calculator(int num1, int num2)
        {
            this.a = num1;
            this.b = num2;
        }
        public int Sum()
        {
            return a + b;
        }
        public int Minus()
        {
            return a - b;
        }
        public int Umnozhenie()
        {
            return a * b;
        }
        public int Delenie()
        {
            if (b == 0)
            {
                Console.WriteLine("Невозможно деление на ноль");
                return -1;
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Первое число:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Второе число:");
            int num2 = int.Parse(Console.ReadLine());
            Calculator calc = new Calculator(num1, num2);
            Console.WriteLine($"Сложение: {calc.Sum()}");
            Console.WriteLine($"Вычитание: {calc.Minus()}");
            Console.WriteLine($"Умножение: {calc.Umnozhenie()}");
            Console.WriteLine($"Деление: {calc.Delenie()}");
        }
    }
}
