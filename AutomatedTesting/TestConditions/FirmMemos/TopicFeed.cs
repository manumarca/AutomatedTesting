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
    class TopicFeed
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
            BrowserActions.SetBrowser(wantedEnviroment.Browser);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);
        }

        [Test]
        public void TopicMemos()
        {

            #region Gets Topic Feed Names
            //Can Use this 
            var topicFeed = unitOfWork.TopicFeed.GetList();
            topicFeed.RemoveAll(x => x.Topic == "?");
            //Or This 

            #endregion

            //Takes each topic to make the rssFeed
            foreach (var topic in topicFeed)
            {
                #region Writes Topic
                //Writes Law firm
                poc.FirmMemosPage.TopicTextBoxFilter.SendKeys(topic.Topic);
                BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
                //Enter to accept law fimr written
                poc.FirmMemosPage.TopicTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Tab);
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
                unitOfWork.TopicFeed.UpdateObject(topic.Topic, "NewURL", poc.FirmMemosAddAlertPopUp.RSSFeedURLBox.GetAttribute("value"));
                ////Writes Down Alert Name
                var alertName = "FM - " + topic.Topic;
                poc.FirmMemosAddAlertPopUp.AlertNameTextBox.SendKeys(alertName);
                unitOfWork.TopicFeed.UpdateObject(topic.Topic, "AlertName", alertName);
                #endregion Id Bug

                #region Cleans Up used topic in Search Filter
                //Exits Pop Up Canceling the operation
                poc.FirmMemosAddAlertPopUp.CancelButton.Click();
                poc.FirmMemosPage.CloseFirstTab.Click();
                //Clears Existing Search
                for (int i = 0; i <= 3; i++) poc.FirmMemosPage.TopicTextBoxFilter.SendKeys(OpenQA.Selenium.Keys.Backspace);
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
