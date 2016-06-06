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

namespace AutomatedTesting.TestConditions.FirmMemos
{
    class LawFirms
    {
        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        UnitOfWork unitOfWork = new UnitOfWork();
        DataHelper dHelper = new DataHelper();
        #endregion

        [SetUp]
        public void Initialize()
        {
            var enviroment = unitOfWork.EnvironmentRepository.GetList();
            ModelsLibrary.Shared.GlobalSettings wantedEnviroment = enviroment.Find(x => x.Page == "FirmMemos");
            //Set which browser is going to run
            BrowserActions.SetBrowser(wantedEnviroment);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);

            #region Enter Client Matter if Needed
            bool clientNeeded = false;
            try
            {
                poc.UpperTabPage.BillingReferenceTextBox.WaitUntilClickable(WebDriver.Driver);
                poc.UpperTabPage.BillingReferenceTextBox.SendKeys(wantedEnviroment.BillingReference);
                clientNeeded = true;
            }
            catch { }
            if (clientNeeded) poc.UpperTabPage.BillingReferenceApplyButton.Click();
            #endregion
        }

        [Test]
        public void LawFirmMemos()
        {
            
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

            #region Gets LawFirm Feed Names
            //Can Use this 
            var lawFirmFeed = unitOfWork.LawFirmFeed.GetList();
            lawFirmFeed.RemoveAll(x => x.Name2 == "?");
            ////or
            //var lawFirmFeed2 = poc.FirmMemosLawPopUp.getListOfLawFirms();
            #endregion
         
            
            //Takes each lawfirm to make the rssFeed
            foreach (var lawFirm in lawFirmFeed)
            {
                #region Writes LawFirm
                //Writes Law firm
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(lawFirm.Name2);
                BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
                //Enter to accept law fimr written
                poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Tab);
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
                    Thread.Sleep(3000);
                    poc.FirmMemosPage.AddAlertButton.Click();
                    try { if (poc.FirmMemosAddAlertPopUp.CancelButton.Displayed) clicked = true; }
                    catch { };
                }
                while (!clicked);
                #endregion

                #region Creates Rss and copy important info
                ////Clicks RSS Feed RadioButton
                poc.FirmMemosAddAlertPopUp.RssFeedRadiobutton.WaitUntilClickable(WebDriver.Driver);
                poc.FirmMemosAddAlertPopUp.RssFeedRadiobutton.Click();
                ////Copy URL Link
                Thread.Sleep(3000);
                unitOfWork.LawFirmFeed.UpdateObject(lawFirm.LawFirmName, "NewURL", poc.FirmMemosAddAlertPopUp.RSSFeedURLBox.GetAttribute("value"));
                ////Writes Down Alert Name
                var alertName = "FM - " + lawFirm.Name2;
                poc.FirmMemosAddAlertPopUp.AlertNameTextBox.SendKeys(alertName);
                unitOfWork.LawFirmFeed.UpdateObject(lawFirm.LawFirmName, "AlertName", alertName);
                #endregion Id Bug

                #region Cleans Up used Law Firm in Search Filter
                //Exits Pop Up Canceling the operation
                poc.FirmMemosAddAlertPopUp.CancelButton.Click();
                //poc.FirmMemosAddAlertPopUp.SaveButton.Click();
                Thread.Sleep(4000);
                //
                poc.FirmMemosPage.CloseFirstTab.Click();
                //Clears Existing Search
                for (int i = 0; i <= 3; i++) poc.FirmMemosPage.LawFirmTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Backspace);
                #endregion
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
    }
}
