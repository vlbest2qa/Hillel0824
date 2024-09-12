using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void NavigateTo(this IWebDriver driver, string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        public static bool IsElenentDisplayed(this IWebDriver driver, By element)
        {
            return driver.FindElement(element).Displayed;
        }

        public static void ScrollToTop(this IJavaScriptExecutor js, IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ScrollToBottom(this IJavaScriptExecutor js, IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static void FillInput(this IWebDriver driver, By selector, string value)
        {
            ScrollToTop((IJavaScriptExecutor)driver, driver.FindElement(selector));
            driver.FindElement(selector).SendKeys(value);
        }

        public static void ClickElement(this IWebDriver driver, By selector)
        {
            ScrollToTop((IJavaScriptExecutor)driver, driver.FindElement(selector));
            driver.FindElement(selector).Click();
        }

        public static void DoubleClickAction(this IWebDriver driver, By selector)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(driver.FindElement(selector)).Perform();
        }

        public static string GetElementColor(this IWebDriver driver, By selector, string element)
        {
            ScrollToTop((IJavaScriptExecutor)driver, driver.FindElement(selector));
            return driver.FindElement(selector).GetCssValue(element);
        }

        public static string GetTextElement(this IWebDriver driver, By selector)
        {
            ScrollToTop((IJavaScriptExecutor)driver, driver.FindElement(selector));
            return driver.FindElement(selector).Text;
        }

        public static void SelectDefinedElement(this IWebDriver driver, By selector, string value)
        {
            var elements = new SelectElement(driver.FindElement(selector));
            elements.SelectByText(value);
        }

        public static void WaitForElementVisible(this IWebDriver driver, By by, int sec = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sec));
            wait.Until(d => d.FindElement(by).Displayed);
        }

        public static void WaitForElementInvisible(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => !d.FindElement(by).Displayed);
        }

        public static void WaitAndClickElement(this IWebDriver driver, By selector)
        {
            driver.WaitForElementVisible(selector);
            ScrollToBottom((IJavaScriptExecutor)driver, driver.FindElement(selector));
            driver.FindElement(selector).Click();
        }

        public static void RightClickAction(this IWebDriver driver, By selector)
        {
            Actions actions = new Actions(driver);
            actions.ContextClick(driver.FindElement(selector)).Perform();
        }
    }
}