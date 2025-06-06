using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDelegate
{
    class Program
    {
        delegate double OperationDelegate(double a, double b);

        static void Main()
        {
            Console.WriteLine("Первое число:");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Второе число:");
            double num2 = double.Parse(Console.ReadLine());
            OperationDelegate oper1 = (a, b) =>
            {
                double sum = a + b;
                double proizvedenie = sum * b;
                double minus = proizvedenie - b;
                return minus;
            };
            OperationDelegate oper2 = (a, b) =>
            {
                if (b == 0) { 
                    Console.WriteLine("Для второго оператора выполнение невозможно");
                    return -1;
                }

                double minus = a - b;
                double delenie = minus / b;
                double umnozhenie = delenie * b;
                return umnozhenie;
            };
            double rezultat1 = oper1(num1, num2);
            Console.WriteLine($"Результат первой операции: {rezultat1}");
            if (num2 == 0)
            {
                Console.WriteLine("Невозможно деление на ноль");
            }
            else
            {
                double rezultat2 = oper2(num1, num2);
                Console.WriteLine($"Результат второй операции: {rezultat2}");
            }
        }
    }
}
