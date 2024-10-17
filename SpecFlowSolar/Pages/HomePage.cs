using OpenQA.Selenium;

namespace SpecFlowSolar.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private By pageTitleBy = By.XPath("//h1");
        private string homePageUrl = "https://solartechnology.com.ua/shop";
        private string homePageTitle = "Магазин";
        private By solarPanelsInMenu = By.CssSelector($".list-inline [href='/shop/solar-panels']");
        private By solarCabelsInMenu = By.CssSelector($".list-inline [href='/shop/solar-cable']");


        public void OpenHomePage()
        {
            NavigateTo(homePageUrl);
            WaitForLoader();
        }

        public void OpenSolarPanels()
        {
            WaitAndClickElement(solarPanelsInMenu);
            WaitForLoader();
        }

        public void OpenSolarCabels()
        {
            WaitAndClickElement(solarCabelsInMenu);
            WaitForLoader();
        }

        public bool IsCurentUrlEqualHome()
        {
            return GetCurrentUrl() == homePageUrl;
        }

        public bool IsTitleDisplayed()
        {
            return IsElenentDisplayed(pageTitleBy);
        }

        public string GetTitlelHome()
        {
            return FindElement(pageTitleBy).Text;
        }
    }
}