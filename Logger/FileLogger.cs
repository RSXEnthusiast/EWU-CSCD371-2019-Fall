using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string outPath;

        public FileLogger(string outPath)
        {
            this.outPath = outPath;
            if (!File.Exists(outPath))
            {
                File.Create(outPath).Close();
            }
        }

        public override void Log(LogLevel logLevel, string s)
        {
            StreamWriter sw = new StreamWriter(outPath, true);
            sw.WriteLine($"{DateTime.Now.ToString()}{className}{logLevel}{s}");
            sw.Close();
        }
    }
}