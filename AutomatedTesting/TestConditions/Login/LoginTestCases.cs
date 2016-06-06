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

namespace AutomatedTesting.TestConditions.Login
{
    
    class LoginTestCases
    {


        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        [SetUp]
        public void Initialize()
        {
            
        }
        
        [Test]
        public void LoginTestCasesExecutor()
        {
            //Gets the Test Casest
            unitOfWork.LoginTestCases.SetExcel();
            var testCases = unitOfWork.LoginTestCases.GetList();    

            //Goes through each test case
            foreach (var testCase in testCases)
            {
                //If it was already runned and passed wont be runned
                if (!testCase.Status.Equals("Passed"))
                {
                    bool testStatus = false;
                    //Choose the TestCase
                    switch(testCase.TestCase)
                    {
                        case "Correct Login":
                            testStatus = TestCaseExecutor.Executor(new Action(CorrectLogin));
                            break;    
                        case "Incorrect Login entering wrong UserName":
                            testStatus = TestCaseExecutor.Executor(new Action(LoginWithIncorrectUserName));
                            break;
                        case "Incorrect Login entering wrong Password":
                            testStatus = TestCaseExecutor.Executor(new Action(LoginWithIncorrectPassword));
                            break;
                    }

                    #region TestStatusUpdater
                    var asd = unitOfWork.LoginTestCases;
                    TestCaseExecutor.Updater(testStatus,unitOfWork.LoginTestCases);
                    if (testStatus)
                    {
                        //If Steps were correctly done will write the Pass for the case
                        unitOfWork.LoginTestCases.SetExcel();
                        unitOfWork.LoginTestCases.UpdateObject(testCase.TestCase, "Status", "Passed");
                        //Closes the driver
                        WebDriver.Driver.Quit();
                    }
                    else
                    {
                        //Will Update the excel with the failed for that test
                        unitOfWork.LoginTestCases.SetExcel();
                        unitOfWork.LoginTestCases.UpdateObject(testCase.TestCase, "Status", "Failed");
                        //Closes the driver
                        WebDriver.Driver.Quit();
                    }
                    #endregion TestStatusUpdater

                }
            }

        }

        public void LoginWithIncorrectUserName()
        {
            //Gets The Data for this TestCase
            unitOfWork.EnvironmentRepository.SetExcel();
            var enviroment = unitOfWork.EnvironmentRepository.GetList();
            var wantedEnviroment = enviroment.Find(x => x.Page == "IncorrectUsername");
            //Set which browser is going to run
            BrowserActions.SetBrowser(wantedEnviroment);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);
            //Checks that its Logged in
            Assert.IsTrue(poc.LoginPage.WrongUserNameorPassWord.Enabled);
        }

        public void LoginWithIncorrectPassword()
        {
            //Gets The Data for this TestCase
            unitOfWork.EnvironmentRepository.SetExcel();
            var enviroment = unitOfWork.EnvironmentRepository.GetList();
            var wantedEnviroment = enviroment.Find(x => x.Page == "IncorrectPassword");
            //Set which browser is going to run
            BrowserActions.SetBrowser(wantedEnviroment);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);
            //Checks that its Logged in
            Assert.IsTrue(poc.LoginPage.WrongUserNameorPassWord.Enabled);
        }

        public void CorrectLogin()
        {
            //Gets The Data for this TestCase
            unitOfWork.EnvironmentRepository.SetExcel();
            var enviroment = unitOfWork.EnvironmentRepository.GetList();
            var wantedEnviroment = enviroment.Find(x => x.Page == "Default");
            //Set which browser is going to run
            BrowserActions.SetBrowser(wantedEnviroment);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(wantedEnviroment.Enviroment);
            //Logs In 
            login.Login(wantedEnviroment);
            //Checks that its Logged in
            Assert.IsTrue(poc.HomePage.FirmMemosLink.Enabled);
            //Gets Logout Class
            LogoutActions logOut = new LogoutActions();
            //Logs Out from Application
            logOut.LogOut();
            //Closes Browser
            BrowserActions.CloseBrowser();

        }

        [TearDown]
        public void TestCleanUp()
        {
  
        }

    }

    
}
