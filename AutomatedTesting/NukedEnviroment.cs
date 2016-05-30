﻿using System;
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
using ObjectLibrary.Pages.Home;
using ObjectLibrary.Pages.FirmMemosPages;
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
            ////Set which browser is going to run
            //BrowserActions.SetBrowser();
            ////Gets Login Class
            //LoginActions login = new LoginActions();
            ////Goes to Intelligize
            //BrowserActions.GoToUrl(ConfigurationSettings.AppSettings["Enviroment"]);
            ////Logs In 
            //login.Login();
        }

        [Test]
        public void ExecuteTest()
        {

            #region Navigate To Firm Memos
            //Goes To Firm Memos Page
            homePage.FirmMemosLink.Click();
            //Waits for ajax loading to finish
            BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
            #endregion

            FirmMemosPopup.getListOfLawFirms();
            //Opens Law Firm Pop Up 
            fmPage.LawFirmExpandFilter.FindElementWaitUntilClickable(WebDriver.Driver);
            fmPage.LawFirmExpandFilter.Click();
            
            UnitOfWork unitOfWork = new UnitOfWork();
            
            var rssFeed = unitOfWork.RssFeedRepository.GetList();
                        
            foreach (var rss in rssFeed)
            {
                Console.WriteLine(rss.Name2);
            }


            //Closes Law Firm Pop Up
            fmPage.LawFirmCancelFilter.FindElementWaitUntilClickable(WebDriver.Driver);
            fmPage.LawFirmCancelFilter.Click();
            
            homePage.FirmMemosLink.Click();
            BrowserActions.WaitForApplicationLoad(WebDriver.Driver);
            fmPage.LawFirmExpandFilter.Click();
            Thread.Sleep(1000);

            fmPage.LawFirmExpandFilter.ScrollIntoView(WebDriver.Driver);
            fmPage.LawFirmExpandFilter.Click();

        }

        [TearDown]
        public void TestCleanUp()
        {
            ////Gets Logout Class
            //LogoutActions logOut = new LogoutActions();
            ////Logs Out from Application
            //logOut.LogOut();
            ////Closes Browser
            //BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}
