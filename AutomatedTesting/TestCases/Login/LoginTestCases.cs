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
    public class LoginTestCases
    {
        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
    }
}
