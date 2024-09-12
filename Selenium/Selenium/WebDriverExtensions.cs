using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Xml.Linq;

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

        public static string GetElementText(this IWebDriver driver, By element)
        {
            return driver.FindElement(element).Text;
        }

        public static void ScrollTo(this IJavaScriptExecutor js, IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void FillInput(this IWebDriver driver, By selector, string value)
        {
            var fieldToTest = driver.FindElement(selector);
            ScrollTo((IJavaScriptExecutor)driver, fieldToTest);
            fieldToTest.SendKeys(value);
        }
    }
}