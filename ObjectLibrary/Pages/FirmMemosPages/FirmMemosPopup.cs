using ObjectLibrary.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Pages.FirmMemosPages
{
    public class FirmMemosPopup
    {
        public FirmMemosPopup()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "button-1093-btnIconEl")]
        public static IWebElement BtnOk { get; set; }

        [FindsBy(How = How.Id, Using = "button-1094")]
        public IWebElement BtnCancel { get; set; }

        public static void getListOfLawFirms ()
        {
            string tableId = "gridview-1080-table";

            IWebElement table = WebDriver.Driver.FindElement(By.Id(tableId));
            //ICollection<IWebElement> rows = table.FindElements(By.TagName("tr"));
            
            int trStartId = 11;
            int trActualId = trStartId;
            List<IWebElement> cells = new List<IWebElement>() { };
            string trId = "gridview-1080-record-ext-record-";
            string trPureId = trId;

            for (;trStartId<176;trStartId++)
            {
                try
                {
                    cells.Add(table.FindElement(By.Id(trId + trStartId)));
                    trActualId++;
                }
                catch (NoSuchElementException)
                {
                    Actions act = new Actions(WebDriver.Driver);
                    act.MoveToElement(table.FindElement(By.Id(trPureId + (trActualId - 1)))).Build().Perform();
                }
            }
        }
    }
}
