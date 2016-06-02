using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Logger
{
    public class Logger
    {
        private readonly IWebDriver _driver;

        // Gets the logger and saves it in a local variable
        public Logger (IWebDriver driver)
        {
            _driver = driver;
        }

        protected static void Log (string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
