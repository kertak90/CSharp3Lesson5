using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace csvParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CSVParser parser = new CSVParser();
            parser.ReadFile("sample.csv");
            Console.ReadLine();
        }
    }
    class CSVParser
    {
        Regex rg1 = new Regex("^[1-9][0-9]*$");
        Regex rg2 = new Regex("^[А-ЯЁ][а-яё]+");
        static string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex rg3 = new Regex(strRegex);
        public CSVParser()
        {
            
        }

        public void ReadFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string line;
                while((line=sr.ReadLine())!=null)
                {
//                    Thread th = new Thread(ParseLine);
//                    th.Start(line);
                    ParseLine(line);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void ParseLine(object obj)
        {
            List<int> number=new List<int>();
            List<string> Email=new List<string>();
            List<string> Name=new List<string>();
            
            string str = obj as string;
            string[] strArray = str.Split(';');
            foreach (var item in strArray)
            {
                var tmpstr = item.Replace("\"", "");
                Match mch1 = rg1.Match(tmpstr);
                if (mch1.Success)
                {
                    number.Add(Int16.Parse(mch1.Groups[0].Value));
                }

                Match mch2 = rg2.Match(tmpstr);
                if (mch2.Success)
                {
                    Name.Add(mch2.Groups[0].Value);
                }

                Match mch3 = rg3.Match(tmpstr);
                if (mch3.Success)
                {
                    Email.Add(mch3.Groups[0].Value);
                }
            }

            SaveResult(number, Email, Name);
        }
        private object ThLock = new object();
        void SaveResult(List<int> num, List<string> email, List<string> name)
        {
            lock (ThLock)
            {
                string resString = "";
                foreach (var item in num) resString += $"{item} ";
                foreach (var item in name) resString += $"{item} ";
                foreach (var item in email) resString += $"{item} ";
                
                using (StreamWriter outputFile = new StreamWriter("result.txt", true))
                {
                    outputFile.WriteLine(resString);
                }
            }
            
        }
    }
}