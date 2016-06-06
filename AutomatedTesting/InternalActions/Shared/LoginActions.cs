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
        UnitOfWork unitOfWork = new UnitOfWork();

        public void Login(ModelsLibrary.Shared.GlobalSettings env)
        {
            EnterUser(env);
            EnterPassword(env);
            ClickOnSignIn();
        }
        
        public void EnterUser(ModelsLibrary.Shared.GlobalSettings env)
        {
            poc.LoginPage.UserName.SendKeys(env.User);
        }

        public void EnterPassword(ModelsLibrary.Shared.GlobalSettings env)
        {
            poc.LoginPage.PassWord.SendKeys(env.Password);
        }

        public void ClickOnSignIn()
        {
            poc.LoginPage.LogInButton.Click();
        }
    }
}
