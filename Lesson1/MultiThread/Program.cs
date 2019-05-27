
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread th1 = new Thread(new ThreadStart(myFunc));
            //th1.IsBackground = true;
            //th1.Priority = ThreadPriority.Highest;
            //th1.Start();

            //var threads = new List<Thread>();
            //for(int i=0; i<10; i++)
            //{
            //    threads.Add(new Thread(()=> myFunc2($"Message {i}")));                
            //}

            //threads.ForEach(t=>t.Start()); 

            //var th3 = new Thread(new ThreadTask { Data = "123"}.ThreadMethod);

            //ThreadPoolTest.Start();
            //ConcurencyTest.Start();

            ThreadManagment.Start();

            lock (ConcurencyTest._SyncRoot)
            {
                Console.WriteLine("Нажмите Enter");
                Console.ReadLine();
            }
            

            
        }
        static bool Do_Work = true;

        static void myFunc()
        {
            try
            {
                for (var i = 0; Do_Work & i < 100_000; i++)
                {

                    Thread.Sleep(100);
                    Console.Title = $"Iteration {i}";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static void myFunc2(object parameter)
        {
            var msg = parameter as string ?? throw new ArgumentException("Параметр не является строкой");
            for (var i = 0; Do_Work & i < 100_000; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"{msg} Current Thread Id {i} {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }

    internal class ThreadTask
    {
        public string Data { get; set; }

        public void ThreadMethod()
        {
            var data = Data;
            for (var i = 0; i < 100_000; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Message {i} : {data} :Current Thread Id {i} {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
