using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Pages.LogIn;
using System.Configuration;

namespace AutomatedTesting.Actions
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
            var config = ConfigurationSettings.AppSettings;
            loginPage.UserName.SendKeys(config["User"]);
        }

        public void EnterPassword()
        {
            var config = ConfigurationSettings.AppSettings;
            loginPage.PassWord.SendKeys(config["Password"]);
        }

        public void ClickOnSignIn()
        {

        }



    }
}
