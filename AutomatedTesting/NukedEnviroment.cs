using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Opera;
using NUnit.Framework;
using AutomatedTesting.InternalActions;
using ObjectLibrary.Shared;
using OpenQA.Selenium.Remote;
using Repositories.cs;

namespace AutomatedTesting
{
    class NukedEnviroment
    {
    
        [SetUp]
        public void Initialize()
        {
            ////Set Basic XML 
            //var config = ConfigurationSettings.AppSettings;
            ////Set which browser is going to run
            //BrowserActions.SetBrowser();
            ////Goes to Intelligize
            //BrowserActions.GoToUrl(config["Enviroment"]);
            ////Gets Login Class
            //LoginActions login = new LoginActions();
            ////Logs In 
            //login.Login();
        }

        [Test]
        public void ExecuteTest()
        {
            GSheetHelper gsHelper = new GSheetHelper();

            gsHelper.Authenticate();
            gsHelper.SelectSpreadSheet("abc");

            //UnitOfWork unitOfWork = new UnitOfWork();
            //var list = unitOfWork.ResourceRepository.GetList();
            //foreach (var value in list)
            //{
            //    Console.WriteLine(value);
            //}
            //WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementExists(By.Id("ext-gen1089")));
            

        }

        [TearDown]
        public void TestCleanUp()
        {
                        //BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}
