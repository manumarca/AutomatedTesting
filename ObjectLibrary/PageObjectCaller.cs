using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Pages.Home;
using ObjectLibrary.Pages.LogIn;
using ObjectLibrary.Pages.FirmMemosPages;
using ObjectLibrary.Shared;
using OpenQA.Selenium;

namespace ObjectLibrary
{
    public class PageObjectCaller
    {
        public PageObjectCaller()
        {
            
        }

        private FirmMemosAddAlertPopUp firmMemosAddAlertPopUp;
        private FirmMemosLawPopup firmMemosLawPopUp;
        private FirmMemosPage firmMemosPage;
        private HomePage homePage;
        private LoginPage loginPage;
        private SwitchProducts switchProducts;
        private UpperTabPage upperTabPage;

        
        public UpperTabPage UpperTabPage
        {
            get
            {
                if (upperTabPage != null) return upperTabPage;
                upperTabPage = new UpperTabPage();
                return upperTabPage;
            }
        }

        public SwitchProducts SwitchProducts
        {
            get
            {
                if (switchProducts != null) return switchProducts;
                switchProducts = new SwitchProducts();
                return switchProducts;
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                if (loginPage != null) return loginPage;
                loginPage = new LoginPage();
                return loginPage;
            }
        }

        public HomePage HomePage
        {
            get
            {
                if (homePage != null) return homePage;
                homePage = new HomePage();
                return homePage;
            }
        }

        public FirmMemosPage FirmMemosPage
        {
            get
            {
                if (firmMemosPage != null) return firmMemosPage;
                firmMemosPage = new FirmMemosPage();
                return firmMemosPage;
            }
        }

        public FirmMemosLawPopup FirmMemosLawPopUp
        {
            get
            {
                if (firmMemosLawPopUp != null) return firmMemosLawPopUp;
                firmMemosLawPopUp = new FirmMemosLawPopup();
                return firmMemosLawPopUp;
            }
        }

        public FirmMemosAddAlertPopUp FirmMemosAddAlertPopUp
        {
            get
            {
                if (firmMemosAddAlertPopUp != null) return firmMemosAddAlertPopUp;
                firmMemosAddAlertPopUp = new FirmMemosAddAlertPopUp();
                return firmMemosAddAlertPopUp;
            }
        }

    }
}
