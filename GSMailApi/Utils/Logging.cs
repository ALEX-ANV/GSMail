using System;
using System.IO;

namespace GSMailApi.Utils
{
    public class Logging
    {
        private static StreamWriter _logFile;

        static Logging()
        {
            Write();
            Write(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            Write();
        }

        private static void Load()
        {
            var date = DateTime.Now.ToShortDateString();
            if (!Directory.Exists(Environment.CurrentDirectory + "\\logs"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\logs");
            }
            if (!File.Exists(Environment.CurrentDirectory + "\\logs\\" + date + ".log"))
            {
                var create = File.Create(Environment.CurrentDirectory + "\\logs\\" + date + ".log");
                create.Close();
            }
            _logFile = new StreamWriter(Environment.CurrentDirectory + "\\logs\\" + date + ".log", true);
        }

        public static void Write(string text, object word = null)
        {
            Write(text, new[] { word });
        }

        public static void Write(string text)
        {
            Write(text, null);
        }

        public static void Write(string text = "\r\n", object[] words = null)
        {
            Load();
            if (words != null)
            {
                text = string.Format(text, words);
            }
            int lengthLine = 150;
            if (text == "\r\n")
            {
                _logFile.WriteLine();
            }
            else
            {

                if (text.Length > lengthLine)
                {
                    int count = text.Length / lengthLine;
                    int start = 0;
                    for (int i = 1; i < count + 1; i++)
                    {
                        if (i == 1)
                        {
                            _logFile.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " +
                                               text.Substring(start, lengthLine));
                            start += lengthLine;
                        }
                        if (text.Length - start > lengthLine)
                        {
                            _logFile.WriteLine("           " + text.Substring(start, lengthLine));
                        }
                        else
                        {
                            _logFile.WriteLine("           " + text.Substring(start));
                        }
                    }

                }
                else
                {
                    _logFile.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " + text);
                }
            }
            Close();
        }

        
        public static void Exception(Exception e)
        {
            Write("Message: " + e.Message);
            Write("StackTrace: " + e.StackTrace);
        }
        
        public static void Close()
        {
            _logFile.Close();
        }
    }
}
