using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/* Разработать асинхронный метод для вычисления факториала числа. 
 * В методе Main выполнить проверку работы метода.*/
namespace Lab23
{
    class Program
    {
        static bool isReady = false;
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int n = Int32.Parse(Console.ReadLine());
            FactorialAsync(n);
            while (!isReady)
            {
                Console.WriteLine("Ожидаем результат.");
            }
            Console.ReadKey();
        }
        static void Factorial(int n)
        {
            ulong result = 1;
            for (uint i = 1; i <= n; i++)
            {
                result *= i;
            }
            isReady = true;
            Console.WriteLine($"Факториал равен {result}.");
        }
        static async void FactorialAsync(int n)
        {
            Console.WriteLine("Начался расчёт факториала.");
            await Task.Run(() => Factorial(n));
            Console.WriteLine("Расчёт факториала окончен.");
        }
    }
}
