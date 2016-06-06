using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLibrary.Logger
{
    public class Log : FileManager
    {
        private TestContext _context;
        private readonly Stopwatch _timer = new Stopwatch();

        // Defines the constructor of the class to create an instance the context, timer and the header of the xml file
        public Log(TestContext testContext, string testDescription = null)
        {
            _context = testContext;
            _timer.Start();
            setFileName(_context.TestName);
            this.setLoggerHeader(testDescription);
        }

        private void setLoggerHeader (string testDescription)
        {
            addLine("<test>");
            setLoggerHeader(_context.TestName, testDescription, _timer.Elapsed.ToString());
        }

        public void setLoggerFooter ()
        {
            addLine("</test>");
        }

        public void Info (string message)
        {
            string msg = String.Format("{0} - INFO\t{1}", _timer.Elapsed, message);
            _context.WriteLine(msg);
            addLine("\t<msgLine>" + msg + "</msgLine>");
        }
    }
}
