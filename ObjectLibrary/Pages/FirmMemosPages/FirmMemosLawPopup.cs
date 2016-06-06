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
    public class FirmMemosLawPopup
    {   
        public FirmMemosLawPopup()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
            
        }

        [FindsBy(How = How.Id, Using = "button-1093-btnIconEl")]
        public static IWebElement BtnOk { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        public IWebElement LawFirmCancelFilter { get; set; }

        [FindsBy(How = How.Id, Using = "ext-gen1251")]
        public IWebElement LawFirmFrameFilter { get; set; }

        //[FindsBy(How = How.Id, Using = "gridview-1106-table")]
        [FindsBy(How = How.XPath, Using = ".//table[@id[contains(., 'gridview') and contains(., 'table')]]")]
        public IWebElement LawFirmListFilter { get; set; }

        [FindsBy(How = How.Id, Using = "textfilter-1129-inputEl")]
        public IWebElement LawFirmTextBoxFilter { get; set; }

        public List<string> getListOfLawFirms ()
        {
            System.Threading.Thread.Sleep(1000);
            int trStartId = 11;
            int trActualId = trStartId;
            List<string> cells = new List<string>() { };
            string trId = "gridview-1080-record-ext-record-";
            string trPureId = trId;

            for (;;trStartId++)
            {
                try
                {
                    //cells.Add(LawFirmListFilter.FindElement(By.Id(trId + trStartId)).Text);
                    //trActualId++;
                    //Actions act = new Actions(WebDriver.Driver);
                    //act.MoveToElement(LawFirmListFilter.FindElement(By.Id(trId + (trStartId)))).Build().Perform();
                }
                catch (Exception)
                {
                    return cells;
                }
            }
        }
    }
}
