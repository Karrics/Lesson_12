using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson12
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Упр 1");
            // Создаем и запускаем 3 потока
            Thread thread1 = new Thread(WriteNumbers);
            Thread thread2 = new Thread(WriteNumbers);
            Thread thread3 = new Thread(WriteNumbers);

            thread1.Start(); // Запуск первого потока
            thread2.Start(); // Запуск второго потока
            thread3.Start(); // Запуск третьего потока

            // Ожидаем завершения всех потоков
            thread1.Join();
            thread2.Join();
            thread3.Join();
            Console.WriteLine();


            Console.WriteLine("Упр 2");
            int number;
            Console.Write("Введите натуральное число: ");
            string input = Console.ReadLine();

            // Проверка на ввод натурального числа
            while (!int.TryParse(input, out number) || number <= 0)
            {
                Console.Write("Ошибка ввода! Введите натуральное число: ");
                input = Console.ReadLine();
            }

            // Синхронное возведение в квадрат
            int square = Square(number);
            Console.WriteLine($"Квадрат числа: {square}");

            // Асинхронное вычисление факториала с задержкой в 8 секунд
            int factorial = await FactorialAsync(number);
            Console.WriteLine($"Факториал числа: {factorial}");
            Console.WriteLine();


            Console.WriteLine("Упр 3");
            Type type = typeof(Program);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadLine();
        }

        static void WriteNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(1000); // Приостанавливаем поток на 1000 миллисекунд
            }
        }

        static int Square(int number)
        {
            return number * number;
        }

        static async Task<int> FactorialAsync(int number)
        {
            await Task.Delay(8000); // Задержка в 8 секунд

            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public string Output()
        {
            return "Test-Output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
