using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2205
{
    unsafe class Program
    {
        static bool IsPalendrom(int a)
        {
            if (a < 0) // проверка на отрицательное число.
            {
                return false;
            }
            int alen = (int)Math.Log10(a) + 1; // узнаем кол-во разрядов числа.
            int* ele = stackalloc int[alen]; //

            int temp = a;
            for (int* i = ele; i < ele + alen; i++)
            {
                *i = (int)(temp % 10);
                temp /= 10;
            }

            int* left = ele;
            int* right = ele + alen - 1;
            while (left < right)
            {
                if (*left != *right)
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int* arra = stackalloc int[n];
            for (int i = 0; i < n; i++)
            {
                arra[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Палендромы");
            for (int i = 0; i < n; i++)
            {
                if (IsPalendrom(arra[i]))
                {
                    Console.WriteLine(arra[i]);
                }
            }
            Console.ReadKey();// чтобы не закрывался компилятор
        }
    }
}
