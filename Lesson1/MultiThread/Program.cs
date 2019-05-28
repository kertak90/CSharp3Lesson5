
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThread
{

//   1. Написать приложение, считающее в раздельных потоках: 
//факториал числа N, которое вводится с клавиатуры;
//    сумму целых чисел до N.
//   2. * Написать приложение, выполняющее парсинг CSV-файла произвольной структуры и сохраняющего его в обычный txt-файл.Все операции проходят в потоках.CSV-файл заведомо имеет большой объем.


    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> ThList = new List<Thread>();
            Thread th1 = new Thread(Factorial);
            ThList.Add(th1);
            Thread th2 = new Thread(Sum);
            ThList.Add(th2);

            Console.WriteLine("Введите целое число: ");
            int number = Convert.ToInt16(Console.ReadLine());

            foreach (var item in ThList)
            {
                item.Start(number);
            }
            Console.ReadLine();
        }

        static void Factorial(object o)
        {
            int n = (int)o;
            int sum = 1;

            for(int i=1;i<=n;i++)
            {
                Thread.Sleep(100);
                sum *= i;
                Console.WriteLine($"{i}; factorial:{sum}; Thread:{Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"Факториал числа {n} равен: {sum}");
        }

        static void Sum(object o)
        {            
            int n = (int)o;
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Thread.Sleep(100);
                sum += i;
                Console.WriteLine($"{i}; sum:{sum}; Thread:{Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"Сумма чисел {n} равны: {sum}");
        }
        
    }

    
}
