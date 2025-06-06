using System;
using System.Collections.Generic;
class HelloWorld {
  static void Main() {
        Console.Write("Введите a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Func<double, double, double> delenie = (x, y) => {
            if (b == 0){
                Console.WriteLine("Невозможн");
                return 0;
            }
            else 
            return x/y;
        };
        Func<double, double, double> proizved = ( x, y) => x*y;
        Func<double, double, double> sum = (x, y) => x + y;
        Func<double, double, double> minus = (x, y) => x-y;
        Console.Write("a + b = ");
        Console.WriteLine(sum(a, b));
        Console.Write("a - b = ");
        Console.WriteLine(minus(a, b));
        Console.Write("a * b = ");
        Console.WriteLine(proizved(a, b));
        Console.Write("a / b = ");
        Console.WriteLine(delenie(a, b));
    }
}
