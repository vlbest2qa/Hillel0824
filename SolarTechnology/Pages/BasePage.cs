using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SolarTechnology.Pages
{
    public class BasePage
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

        public void ScrollToBottom(IWebElement element)
        {
            _js.ExecuteScript($"arguments[0].scrollIntoView(false);", element);
        }

        public void WaitForElementVisible(By by, int sec = 3)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            wait.Until(d => d.FindElement(by).Displayed);
        }

        public void WaitForElementInvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => !d.FindElement(by).Displayed);
        }

        
        public void WaitForLoader()
        {
            By loader = By.Id("p_prldr");
            WaitForElementVisible(loader);
            WaitForElementInvisible(loader);
        }

        public void WaitAndClickElement(By selector)
        {
            WaitForElementVisible(selector);

            IWebElement element = FindElement(selector);
            ScrollToBottom(FindElement(selector));
            element.Click();
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var element = _driver.FindElements(by);
            return element;
        }
    }
}
