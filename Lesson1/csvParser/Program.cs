using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class CSVParser
    {
        public CSVParser()
        {
            FileStream FS = new FileStream("parsed_data.txt", FileMode.Create, FileAccess.Write);
        }

        public void ReadFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader("sample.csv");
                string line;
                while((line=sr.ReadLine())!=null)
                {
                    Thread th = new Thread(ParseLine);
                    th.Start(line);
                }                
            }
            catch (Exception)
            {               
            }
        }
        public void ParseLine(object obj)
        {
            string str = obj as string;
            string[] strArray = str.Split(';');
            int number;
            string Email;
            string Name;
        }
    }
}
