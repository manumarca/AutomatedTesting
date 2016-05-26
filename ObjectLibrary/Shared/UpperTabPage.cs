using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Shared
{
    public class UpperTabPage
    {
        public UpperTabPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "user_details_container")]
        public IWebElement UserDetailsIcon{get;set;}

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement LogInButton { get; set; }
    }
}
