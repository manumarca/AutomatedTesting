using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Repositories.cs;
using Repositories.cs.Helpers;


namespace AutomatedTesting.InternalActions.Shared
{
    public class LoginActions
    {
        PageObjectCaller poc = new PageObjectCaller();


        public void Login()
        {
            EnterUser();
            EnterPassword();
            ClickOnSignIn();
        }
        
        public void EnterUser()
        {
            poc.LoginPage.UserName.SendKeys(ConfigurationSettings.AppSettings["User"]);
        }

        public void EnterPassword()
        {
            poc.LoginPage.PassWord.SendKeys(ConfigurationSettings.AppSettings["Password"]);
        }

        public void ClickOnSignIn()
        {
            poc.LoginPage.LogInButton.Click();
        }
    }
}
