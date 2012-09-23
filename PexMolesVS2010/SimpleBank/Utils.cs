using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleBank
{
    public static class Utils
    {
        public static string SomeDumbMethod(int i, int j)
        {
            if (i > j )
            {
                if (j == 12)
                    return "output1";
                else
                    return "output2";
            }
            else
            {
                return "output3";
            }
        }

        public static string Capitalize()
        {
            string value = ReadFooValue();

            //home work -> HomeWork
            // WARNING: this sample is for demonstration only: it *contains* bugs.
            var sb = new StringBuilder();
            bool word = false;
            foreach (var c in value)
            {
                if (char.IsLetter(c))
                {
                    if (word)
                        sb.Append(c);
                    else
                    {
                        sb.Append(char.ToUpper(c));
                        word = true;
                    }
                }
                else
                {
                    if (c == '!')
                        sb.Append('_');
                    word = false;
                }
            }

            return sb.ToString();
        }

        public static string ReadFooValue()
        {
            string path = @"C:\mytest.txt";
            if (!File.Exists(path))
            {
                return null;
            }

            return File.ReadAllText(path);
        }

        public static String GetMessage()
        {
            if (DateTime.Now.DayOfYear == 1)
            {
                return "Happy New Year!";
            }
            return "Just a normal day!";
        }

        public static int Fibonacci(int x)
        {
            if (x <= 1)
            {
                return 1;
            }
            return Fibonacci(x - 1) + Fibonacci(x - 2);
        }
    }
}
