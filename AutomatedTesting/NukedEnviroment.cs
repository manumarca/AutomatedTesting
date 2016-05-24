﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using NUnit.Framework;
using System.Configuration;
using AutomatedTesting.Actions;
using ObjectLibrary.Shared;

namespace AutomatedTesting
{
    class NukedEnviroment
    {
    
        [SetUp]
        public void Initialize()
        {
            //Set Basic XML 
            var config = ConfigurationSettings.AppSettings;
            //Set which browser is going to run
            BrowserActions.SetBrowser();
            //Goes to Intelligize
            BrowserActions.GoToUrl(config["Enviroment"]);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Logs In 
            login.Login();
        }

        [Test]
        public void ExecuteTest()
        {
                        
        }

        [TearDown]
        public void TestCleanUp()
        {

            BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}