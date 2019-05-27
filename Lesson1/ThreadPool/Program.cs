using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    internal static class ThreadPoolTest
    {
        public static void Start()
        {
            ThreadPool.SetThreads(2, 2);
        }
    }
}
