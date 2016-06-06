using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Pages.LogIn
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserName{ get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id = 'login-controls']/div[4]/div/input")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/form/div/div[2]/div/div[4]/div[3]/div/ul/li")]
        public IWebElement WrongUserNameorPassWord { get; set; }
        
    }
}
