using AutomatedTesting.InternalActions.Shared;
using NUnit.Framework;
using AutomatedTesting.InternalActions.Shared;
using ObjectLibrary;
using OpenQA.Selenium.Remote;
using Repositories.cs;
using Repositories.cs.Helpers;
using System.Collections.Generic;
using ObjectLibrary;
using OpenQA.Selenium;
using Repositories.cs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace AutomatedTesting.TestConditions.FirmMemos
{
    class LawFirms
    {
        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        [SetUp]
        public void Initialize()
        {
            List<ModelsLibrary.Shared.GlobalSettings> enviroment = unitOfWork.EnvironmentRepository.GetList();
            ModelsLibrary.Shared.GlobalSettings wantedEnviroment = enviroment.Find(x => x.Page == "FirmMemos");
            //Set which browser is going to run
            BrowserActions.SetBrowser(wantedEnviroment.Browser);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);
        }

        [Test]
        public void GetListOfLawFirms ()
        {
            poc.FirmMemosPage.LawFirmExpandFilter.Click();
            List<string> lawFirmFeed = poc.FirmMemosLawPopUp.getListOfLawFirms();
            Dictionary<string, string> newRSSFeed = new Dictionary<string, string>();
            poc.FirmMemosLawPopUp.LawFirmCancelFilter.Click();

            foreach (var lawFirm in lawFirmFeed)
            {
                #region Writes LawFirm
                //Writes Law firm
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(lawFirm);
                BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
                //Enter to accept law fimr written
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(Keys.Tab);
                #endregion

                #region Searches
                //Starts The search
                poc.FirmMemosPage.SearchButton.WaitUntilClickable(WebDriver.Driver);
                poc.FirmMemosPage.SearchButton.Click();
                #endregion

                #region Opens AddAlert Pop Up
                //Clicks to open AddAlertButton
                bool clicked = false;
                do
                {
                    poc.FirmMemosPage.AddAlertButton.Click();
                    Thread.Sleep(1000);
                    try { if (poc.FirmMemosAddAlertPopUp.CancelButton.Displayed) clicked = true; }
                    catch { };
                }
                while (!clicked);
                #endregion

                //Id´s from Pop Up changing constantly looking workaround to capture the element with stronger and constant property
                #region Id Bug
                ////Clicks RSS Feed RadioButton
                
                //poc.FirmMemosAddAlertPopUp.rssRadioButton.WaitUntilClickable(WebDriver.Driver);
                //poc.FirmMemosAddAlertPopUp.rssRadioButton.Click();
                ////Copy URL Link
                //  unitOfWork.RssFeedRepository.UpdateObject(lawFirm, "NewURL", "Changed"); // poc.FirmMemosAddAlertPopUp.RSSFeedURLBox.Text
                ////Writes Down Alert Name
                var alertName = "FM - " + lawFirm;
                //poc.FirmMemosAddAlertPopUp.AlertNameTextBox.SendKeys(alertName);
                //unitOfWork.RssFeedRepository.UpdateObject(lawFirm, "AlertName", alertName);

                newRSSFeed.Add(alertName, "Changed");
                #endregion Id Bug

                #region Cleans Up used Law Firm in Search Filter
                //Exits Pop Up Canceling the operation
                poc.FirmMemosAddAlertPopUp.CancelButton.Click();
                //Clears Existing Search
                for (int i = 0; i <= 3; i++) poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(Keys.Backspace);
                #endregion
            }
            foreach (var line in newRSSFeed)
            {
                Console.WriteLine("{0}, {1}", line.Key, line.Value);
            }
        }

        //[TearDown]
        //public void TestCleanUp()
        //{
        //    //Just for this tests if fails inside of pop up may break CleanUp so if pop up open this will close it
        //    if (poc.FirmMemosAddAlertPopUp.CancelButton.Displayed) poc.FirmMemosAddAlertPopUp.CancelButton.Click();
        //    //Gets Logout Class
        //    LogoutActions logOut = new LogoutActions();
        //    //Logs Out from Application
        //    logOut.LogOut();
        //    //Closes Browser
        //    BrowserActions.CloseBrowser();
        //}
    }
}
