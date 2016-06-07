using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FManager
{
    public class FileManager
    {
        private static string _path;
        private static string _fileName;

        public FileManager (TestContext TestContext)
        {
            _path = @"C:/Logs/";
            _fileName = String.Format("{0}-{1:mm-dd-yy}.txt", TestContext.Test.Name, DateTime.Now.Day); 
        }


        private bool FileExists ()
        {
            if (File.Exists(_path + _fileName))
                return true;
            else
                return false;
        }

        public static void WriteLine (string msg)
        {
            using (StreamWriter sw = new StreamWriter(_path + _fileName))
            {
                sw.WriteLine(msg);
            }
        }
    }
}