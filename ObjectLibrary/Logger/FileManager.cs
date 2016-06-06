using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Logger
{
    public class FileManager
    {
        private static string _path;
        private static string _fileName;
        private static TextWriter writer;

        public FileManager() {
            _path = setPath();
        }
        
        /// <summary>
        /// Sets the path for the current instance of the file
        /// </summary>
        private string setPath ()
        {
            return @"C:\Users\Mariano Rodriguez\Desktop\";
        }

        /// <summary>
        /// Sets the name of the logger file
        /// </summary>
        protected void setFileName(string testName)
        {
            _fileName = String.Format(testName + "_{0}-{1}-{2}.xml", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// Creates the log file
        /// </summary>
        protected static void addLine(string line)
        {
            if (writer == null)
            {
                using (writer = File.CreateText(_path + _fileName))
                {
                    writer.WriteLine(line);
                }
            }
            else
            {
                using (writer = File.AppendText(_path + _fileName))
                {
                    
                    writer.WriteLine(line);
                }
            }
        }

        protected void setLoggerHeader (string testName, string testDescription, string startedTime)
        {
            addLine("\t<testName>" + testName + "</testName>");
            addLine("\t<testDescription>" + testDescription + "</testDescription>");
            addLine("\t<startedTime>" + startedTime + "</startedTime>");
        }
    }
}
