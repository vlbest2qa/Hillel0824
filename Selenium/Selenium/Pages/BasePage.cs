using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Selenium.Pages
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
            //_js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            _js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public void FillInput(By selector, string value)
        {
            var fieldToTest = _driver.FindElement(selector);
            ScrollTo(fieldToTest);
            fieldToTest.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            var elementForClick = _driver.FindElement(selector);
            ScrollTo(elementForClick);
            elementForClick.Click();
        }

        public void SelectElement(By selector, string value)
        {
            var fieldToTest = new SelectElement(_driver.FindElement(selector));
            fieldToTest.SelectByText(value);
        }

        public string GetBorderColor(By selector)
        {
            var fieldTotest = _driver.FindElement(selector);
            ScrollTo(fieldTotest);
            return fieldTotest.GetCssValue("border-color");
        }

        public string GetTextElement(By selector)
        {
            var fieldTotest = _driver.FindElement(selector);
            ScrollTo(fieldTotest);
            return fieldTotest.Text;
        }

        public void SelectDefinedElement(By selector, string value)
        {
            var elements = new SelectElement(_driver.FindElement(selector));
            elements.SelectByText(value);
        }

        public bool IsElenentDisplayed(By element)
        {
            var confirmationModal = _driver.FindElement(element);
            return confirmationModal.Displayed;
        }

        public string GetElementText(By element)
        {
            var confirmationModal = _driver.FindElement(element);
            return confirmationModal.Text;
        }

        public void DoubleClickAction(By selector)
        {
            var doubleClickButton = _driver.FindElement(selector);
            Actions actions = new Actions(_driver);
            actions.DoubleClick(doubleClickButton).Perform();
        }

        public void RightClickAction(By selector)
        {
            var rightClickButton = _driver.FindElement(selector);
            Actions actions = new Actions(_driver);
            actions.ContextClick(rightClickButton).Perform();
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
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

        public void WaitForElementEnabled(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
        }
        public void WaitAndClickElement(By selector)
        {
            WaitForElementVisible(selector);

            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.Click();
        }
    }
}
