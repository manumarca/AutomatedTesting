using ObjectLibrary.Shared;
using Repositories.cs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTesting.InternalActions
{
    public static class LogoutActions
    {
        private static UpperTabPage ut;

        public static void LogOut ()
        {
            ut = new UpperTabPage();

            //ut.UserDetailsIcon.Click();
            PageObjectHelper.FindElementWaitUntilClickable(ut.logoutLink).Click();
        }
    }
}
