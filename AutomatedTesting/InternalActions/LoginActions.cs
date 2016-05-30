using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Pages.LogIn;
using ObjectLibrary.Shared;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Repositories.cs;
using Repositories.cs.Helpers;


namespace AutomatedTesting.InternalActions
{
    public class LoginActions
    {
        LoginPage loginPage = new LoginPage();


        public void Login()
        {
            EnterUser();
            EnterPassword();
            ClickOnSignIn();
        }
        
        public void EnterUser()
        {
            loginPage.UserName.SendKeys(ConfigurationSettings.AppSettings["User"]);
        }

        public void EnterPassword()
        {
            loginPage.PassWord.SendKeys(ConfigurationSettings.AppSettings["Password"]);
        }

        public void ClickOnSignIn()
        {
            loginPage.LogInButton.JsClick(WebDriver.Driver);
        }
    }
}
