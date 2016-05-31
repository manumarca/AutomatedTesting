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
using AutomatedTesting.InternalActions.Shared;
using ObjectLibrary;
using OpenQA.Selenium.Remote;
using Repositories.cs;
using Repositories.cs.Helpers;
using System.Collections.Generic;

namespace AutomatedTesting
{
    class NukedEnviroment
    {
               
        [SetUp]
        public void Initialize()
        {
            //Set which browser is going to run
            BrowserActions.SetBrowser();
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(ConfigurationSettings.AppSettings["Enviroment"]);
            //Logs In 
            login.Login();
        }

        [Test]
        public void ExecuteTest()
        {
            #region Instances
            PageObjectCaller poc = new PageObjectCaller();
            UnitOfWork unitOfWork = new UnitOfWork();
            #endregion

            #region Navigate To Firm Memos
            ////Goes To Firm Memos Page
            //poc.HomePage.FirmMemosLink.WaitUntilClickable(WebDriver.Driver);
            //poc.HomePage.FirmMemosLink.Click();
            ////Waits for ajax loading to finish
            //BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
            #endregion

            #region Opens Law Firm Pop Up
            //Opens Law Firm Pop Up 
            //poc.FirmMemosPage.LawFirmExpandFilter.WaitUntilClickable(WebDriver.Driver);
            //poc.FirmMemosPage.LawFirmExpandFilter.Click();
            #endregion

            #region Closes Law Firm Pop Up
            //Closes Law Firm Pop Up
            //poc.FirmMemosLawPopUp.LawFirmCancelFilter.WaitUntilClickable(WebDriver.Driver);
            //poc.FirmMemosLawPopUp.LawFirmCancelFilter.Click();
            #endregion

            #region Gets RSS Feed Names
            var rssFeed = unitOfWork.RssFeedRepository.GetList();
            rssFeed.RemoveAll(x => x.Name2 == "?");
            #endregion


            foreach (var rss in rssFeed)
            {
                //Writes Law firm
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(rss.Name2);
                BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
                //Enter to accept law fimr written
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(Keys.Tab);
                //Starts The search
                poc.FirmMemosPage.SearchButton.WaitUntilClickable(WebDriver.Driver);
                poc.FirmMemosPage.SearchButton.Click();
                //Clicks to open AddAlertButton
                Thread.Sleep(3000);
                poc.FirmMemosPage.AddAlertButton.Click();

                #region Id Bug
                ////Clicks RSS Feed RadioButton
                //poc.FirmMemosAddAlertPopUp.rssRadioButton.WaitUntilClickable(WebDriver.Driver);
                //poc.FirmMemosAddAlertPopUp.rssRadioButton.Click();
                ////Copy URL Link
                unitOfWork.RssFeedRepository.UpdateObject(rss.LawFirmName,"NewURL","Changed"); // poc.FirmMemosAddAlertPopUp.RSSFeedURLBox.Text
                ////Writes Down Alert Name
                //poc.FirmMemosAddAlertPopUp.AlertNameTextBox.SendKeys("FM - " + rss.Name2);
                #endregion Id Bug

                //Exits Pop Up Canceling the operation
                poc.FirmMemosAddAlertPopUp.CancelButton.Click();
                //Clears Existing Search
                for (int i = 0; i <= 5; i++) poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(Keys.Backspace);
            }
        

        }

        [TearDown]
        public void TestCleanUp()
        {
            //Gets Logout Class
            LogoutActions logOut = new LogoutActions();
            //Logs Out from Application
            logOut.LogOut();
            //Closes Browser
            BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}
