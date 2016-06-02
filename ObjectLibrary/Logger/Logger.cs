using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Logger
{
    public interface Ilog
    {
        void Info(string message, string param = "", [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);
    }

    public static class Log
    {

        #region Declarations
        private static bool _startedTest;
        private static readonly Stopwatch _timer = new Stopwatch();

        private static string _path;
        private static string _file;

        private static string timer;
        #endregion Declarations       

        static Log()
        {
            StackTrace st = new StackTrace(true);
            //setFileName(st.GetFrames()[1].GetMethod().Name + "-{0:yyyy-MM-dd_hh-mm-ss-tt_1}.txt");
            setFileName("Mariano");
            setFilePath(@"C:\");
            StartTimer();
        }

        public static void TerminateLogger()
        {
            StreamWriter outFile = File.AppendText(_path + _file);
            outFile.WriteLine("--------------------------------------------------------------------");
            outFile.WriteLine("{0} - Automation Condition Finalized ", DateTime.Now);
            outFile.WriteLine("Total test time: {0}", _timer.Elapsed);
            outFile.Close();
            setFileName("");
            setFilePath("");
        }

        private static void setFileName(string name)
        {
            _file = string.Format(name, DateTime.Now);
        }

        private static string getFileName()
        {
            return _file;
        }

        private static void setFilePath(string path)
        {
            _path = path;
        }

        private static string getFilePath()
        {
            return _path;
        }


        /// <summary>
        /// Prints information reference to methods and time in the file
        /// </summary>
        public static void Info(string message, string param = "", [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            StartTimer();
            timer = String.Format("{0:00}:{1:00}:{2:00}:{3:000000}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds);
            Console.WriteLine("{0} : INFO - {1}", timer, message);

            addLineToFile(_timer.Elapsed + " - " + message + "\nMethod: " + memberName);
            Console.WriteLine(_timer.Elapsed + " - " + message + "\nMethod: " + memberName);
        }

        /// <summary>
        /// Prints an ERROR in the file
        /// </summary>
        public static void Error(string message, Exception ex, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            StartTimer();
            timer = String.Format("{0:00}:{1:00}:{2:00}:{3:000000}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds);
            Console.Error.WriteLine("{0} : ERROR - {1}", _timer.Elapsed, message);
            string[] _stack = ex.StackTrace.Split('.');

            addLineToFile("********************************************************************************************************************************************************************************************************************************************************************************************");
            addLineToFile(DateTime.Now.ToString() + " - EXCEPCION");
            addLineToFile("Message internal: " + message);
            addLineToFile("Message exception: " + ex.Message);
            addLineToFile("Method exception: " + _stack[_stack.Length - 2].Split(')')[0] + ")");
            addLineToFile("Line exception: " + _stack[_stack.Length - 1].Split(' ')[1]);
            addLineToFile("Source: c:" + _stack[_stack.Length - 2].Split(':')[1] + ".cs");
            addLineToFile("TargetSite: " + ex.TargetSite);
            addLineToFile("InnerException: " + ex.InnerException);
            addLineToFile("********************************************************************************************************************************************************************************************************************************************************************************************");

        }


        /// <summary>
        /// Initializes a timer
        /// </summary>
        public static void StartTimer()
        {
            if (_startedTest) return;
            _timer.Restart();
            _startedTest = true;
        }

        /// <summary>
        /// Adds one line to file
        /// </summary>
        private static void addLineToFile(string msg)
        {
            StreamWriter outputFile = checkFileSize();

            outputFile.WriteLine(msg);
            outputFile.WriteLine(" ");
            outputFile.Close();
        }

        /// <summary>
        /// Creates a file
        /// </summary>
        private static StreamWriter checkFileSize()
        {
            FileInfo file = new FileInfo(_path + _file);
            if (file.Exists)
            {
                if (file.Length > (10240))
                {
                    string[] fileParts = file.ToString().Split('_');
                    string[] nbr = fileParts[2].Split('.');
                    int fileNbr = Int32.Parse(nbr[0]) + 1;
                    string a = fileParts[0] + fileParts[1] + "_" + Convert.ToString(fileNbr) + ".txt";
                    StreamWriter outputFile = new StreamWriter(fileParts[0] + "_" + fileParts[1] + "_" + Convert.ToString(fileNbr) + ".txt", true);
                    outputFile.WriteLine("{0} - Automation Condition Initialized ", DateTime.Now);
                    outputFile.WriteLine("---------------------------------------------------------");
                    return outputFile;
                }
                return File.AppendText(_path + _file);
            }
            StreamWriter outFile = new StreamWriter(_path + _file, true);
            outFile.WriteLine("{0} - Automation Condition Initialized ", DateTime.Now);
            outFile.WriteLine("--------------------------------------------------------------------");
            return outFile;
        }
    }
}