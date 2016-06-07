using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using FManager;
using System.Diagnostics;

namespace Log
{
    public class Logger
    {
        private static TestContext _context;
        private static readonly Stopwatch _timer;
        
        public Logger (TestContext TestContext)
        {
            _context = TestContext;
            Header();
            FileManager file = new FileManager(_context);
            _timer.Start();
        }

        /// <summary>
        /// Sets the info that is going to be shown in the Visual Studio context
        /// </summary>
        public static void Info (string msg)
        {
            Console.WriteLine
                (@"{0} - {1}"
                ,_timer.Elapsed, msg);
        }

        /// <summary>
        /// Sets the initial content of the Log file
        /// </summary>
        private static void Header ()
        {
            Console.WriteLine
                (@"
                {0} - Test Directory: {1}
                ", _context.Test.Name, _context.TestDirectory);
        }

        /// <summary>
        /// Sets the final content of the Log file
        /// </summary>
        private static void Footer ()
        {
            Console.WriteLine
                (@"
                    {0}
                ", _context.Result);
        }
    }
}
