using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Runtime.CompilerServices;

namespace MultiThread
{
    [Synchronization]
    class Logger : ContextBoundObject, IDisposable
    {
        private TextWriter _writer;

        public Logger(TextWriter writer) => _writer = _writer;

        public Logger(string FileName) : this(new StreamWriter(File.OpenWrite(FileName))) { }

        public void Dispose() => _writer.Dispose();

        public void Log(string msg) => _writer.WriteLine($"{DateTime.Now}");
    }

    class Logger2 : ContextBoundObject, IDisposable
    {
        private TextWriter _writer;

        public Logger2(TextWriter writer) => _writer = _writer;
        
        public Logger2(string FileName) : this(new StreamWriter(File.OpenWrite(FileName))) { }

        public void Dispose() => _writer.Dispose();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string msg) => _writer.WriteLine($"{DateTime.Now}");
    }
}
