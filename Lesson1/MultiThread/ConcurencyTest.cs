using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class ConcurencyTest
    {
        public static void Start()
        {
            for(int i = 0; i< 10; i++)
            {
                //var thread = new Thread(ThreadMethod);
                var thread = new Thread(SyncThreadMethod);
                thread.Start();
            }

            var result = new List<int>();
            for(int i=0; i<100; i++)
            {
                var i0 = i;
                var thread = new Thread(() => 
                {
                    var c = Digits(i0);
                    lock(result)
                    result.Add(c);
                });
                thread.Start();
            }
        }

        private static int Digits(int N)
        {
            return 42;
        }
        
        public static void ThreadMethod()
        {
            Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId} - ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine("10");
        }

        public static readonly object _SyncRoot = new object();
        public static void SyncThreadMethod()
        {
            Monitor.Enter(_SyncRoot);
            try
            {
                Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId} - ");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{i}, ");
                }
                Console.WriteLine("10");
            }
            finally
            {
                if (Monitor.IsEntered(_SyncRoot))
                    Monitor.Exit(_SyncRoot);
                
            }
                
                        
        }
    }
}
