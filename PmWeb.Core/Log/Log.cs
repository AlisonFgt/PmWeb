using System;
using System.IO;

namespace PmWeb.Core
{
    public class Log
    {
        public static void Debug(string content)
        {
            SaveLog("DEBUG", content);
        }

        public static void Error(string content)
        {
            SaveLog("ERROR", content);
        }

        public static void Error(string content, string error)
        {
            SaveLog("ERROR", content + error);
        }

        public static void SaveLog(string status, string content)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            log.WriteLine(status);
            log.WriteLine(DateTime.Now);
            log.WriteLine(content);
            log.WriteLine();

            log.Close();
        }
    }
}
