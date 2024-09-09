using OpenQA.Selenium;

namespace SolarTechnology.Pages
{
    internal class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public IJavaScriptExecutor _js;
        public IWebDriver _driver;

        public void NavigateTo(string link)
        {
            _driver.Navigate().GoToUrl(link);
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //_js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }


    }
}
