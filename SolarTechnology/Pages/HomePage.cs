using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private By solarPanelsLink = By.CssSelector(".list-inline [href='/shop/solar-panels']");

        public void OpenPage()
        {
            NavigateTo("https://solartechnology.com.ua/shop");

            WaitForLoader();
        }

        public void OpenSolarPanels()
        {
            WaitAndClickElement(solarPanelsLink);

            WaitForLoader();
        }
    }
}
