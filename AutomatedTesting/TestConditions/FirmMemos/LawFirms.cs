using AutomatedTesting.InternalActions.Shared;
using NUnit.Framework;
using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTesting.TestConditions.FirmMemos
{
    class LawFirms
    {
        [SetUp]
        public void Initialize()
        {
            //Set which browser is going to run
            BrowserActions.SetBrowser();
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(ConfigurationSettings.AppSettings["Enviroment"]);
            //Logs In 
            login.Login();
        }

        #region Global Instances
        PageObjectCaller poc = new PageObjectCaller();
        #endregion

        [Test]
        public void GetListOfLawFirms ()
        {
            poc.FirmMemosPage.LawFirmExpandFilter.Click();
            List<string> asd = poc.FirmMemosLawPopUp.getListOfLawFirms();

            using (StreamWriter sr = new StreamWriter(@"C:\Users\Mariano Rodriguez\Desktop\LawFirms.txt"))
            {
                foreach (string e in asd)
                {
                    sr.WriteLine(e);
                }
            }

        }

        //[TearDown]
        //public void TestCleanUp()
        //{
        //    //Just for this tests if fails inside of pop up may break CleanUp so if pop up open this will close it
        //    if (poc.FirmMemosAddAlertPopUp.CancelButton.Displayed) poc.FirmMemosAddAlertPopUp.CancelButton.Click();
        //    //Gets Logout Class
        //    LogoutActions logOut = new LogoutActions();
        //    //Logs Out from Application
        //    logOut.LogOut();
        //    //Closes Browser
        //    BrowserActions.CloseBrowser();
        //}
    }
}
