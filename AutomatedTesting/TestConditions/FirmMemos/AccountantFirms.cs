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
    class AccountantFirms
    {
        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        UnitOfWork unitOfWork = new UnitOfWork();
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
        }

        [Test]
        public void AccountantFirmMemos()
        {
            #region Navigate To Firm Memos
            ////Goes To Firm Memos Page
            //poc.HomePage.FirmMemosLink.WaitUntilClickable(WebDriver.Driver);
            //poc.HomePage.FirmMemosLink.Click();
            ////Waits for ajax loading to finish
            //BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
            #endregion

            #region Gets AccountantFirm Feed Names
            var accountirmFeed = unitOfWork.AccountantFirmFeed.GetList();
            accountirmFeed.RemoveAll(x => x.Name == "?");
             #endregion

            //Takes each lawfirm to make the rssFeed
            foreach (var accountFirm in accountirmFeed)
            {
                #region Writes AccountFirm
                //Writes Law firm
                poc.FirmMemosPage.AccountFirmTextBoxFilter.SendKeys(accountFirm.Name);
                BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
                //Enter to accept law fimr written
                poc.FirmMemosPage.AccountFirmTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Tab);
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

                #region Creates Rss and copy important info
                ////Clicks RSS Feed RadioButton
                poc.FirmMemosAddAlertPopUp.RssFeedRadiobutton.WaitUntilClickable(WebDriver.Driver);
                poc.FirmMemosAddAlertPopUp.RssFeedRadiobutton.Click();
                ////Copy URL Link
                unitOfWork.AccountantFirmFeed.UpdateObject(accountFirm.AccountingFirmName, "NewURL", poc.FirmMemosAddAlertPopUp.RSSFeedURLBox.GetAttribute("value"));
                ////Writes Down Alert Name
                var alertName = "FM - " + accountFirm.Name;
                poc.FirmMemosAddAlertPopUp.AlertNameTextBox.SendKeys(alertName);
                unitOfWork.AccountantFirmFeed.UpdateObject(accountFirm.AccountingFirmName, "AlertName", alertName);
                #endregion Id Bug

                #region Cleans Up used Account Firm in Search Filter
                //Exits Pop Up Canceling the operation
                poc.FirmMemosAddAlertPopUp.CancelButton.Click();
                poc.FirmMemosPage.CloseFirstTab.Click();
                //Clears Existing Search
                for (int i = 0; i <= 3; i++) poc.FirmMemosPage.AccountFirmTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Backspace);
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

