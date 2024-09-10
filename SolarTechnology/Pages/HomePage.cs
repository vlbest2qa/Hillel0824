using OpenQA.Selenium;
namespace SolarTechnology.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private By pageTitleBy = By.XPath("//h1");
        private string homePageUrl = "https://solartechnology.com.ua/shop";
        private string homePageTitle = "Магазин";

        public void OpenHomePage()
        {
            NavigateTo(homePageUrl);
            WaitForLoader();
        }

        public void OpenHomePageMenu(string href)
        {
            By element = By.CssSelector($".list-inline [href='{href}']");
            WaitAndClickElement(element);
            WaitForLoader();
        }

        public bool IsCurentUrlEqualHome()
        {
            return GetCurrentUrl() == homePageUrl;
        }

        public int CountTitleElement()
        {
            return CountFindElements(pageTitleBy);
        }

        public bool IsTitleEqualHome()
        {
            return FindElement(pageTitleBy).Text == homePageTitle;
        }
    }
}
