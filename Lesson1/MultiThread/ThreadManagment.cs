using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class ThreadManagment
    {
        public static void Start()
        {
            //Mutex mutex = new Mutex(true, "TestMutex", out var is_created_new);

            //Semaphore semaphore = new Semaphore(0, 5);      //начальное значение потоков 0, максимальное значение 5

            //for(int i=0;i<20;i++)
            //{
            //    var i0 = i;
            //    var thread = new Thread(()=>
            //    {
            //        semaphore.WaitOne();
            //        for(int j=0;j<10;j++)
            //        {
            //            Console.WriteLine($"Thread id:{Thread.CurrentThread.ManagedThreadId} - {j} ");
            //        }
            //        semaphore.Release();
            //    });
            //    thread.Start();
            //}
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine($"Thread id:{Thread.CurrentThread.ManagedThreadId} - started");
                    manualResetEvent.WaitOne();
                    Console.WriteLine($"Thread id:{Thread.CurrentThread.ManagedThreadId} - completed");
                });
                thread.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Для продолжения выполнения потока нажмите Enter");
                Console.ReadLine();
                manualResetEvent.Set();
            }
        }
    }
}
