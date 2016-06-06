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
using AutomatedTesting.TestConditions.Dictionaries;
using ObjectLibrary;
using OpenQA.Selenium.Remote;
using Repositories.cs;
using Repositories.cs.Helpers;
using System.Collections.Generic;

namespace AutomatedTesting.TestConditions.Login
{
    
    class LoginTestCasesExecutor
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
        public void LoginTestCasesExecutorMethod()
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
                    testStatus = TestCaseExecutor.Executor(TestCasesDictionaries.LoginTestCases[testCase.TestCase]);

                    #region TestStatusUpdater
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

        [TearDown]
        public void TestCleanUp()
        {
  
        }

    }

    
}
