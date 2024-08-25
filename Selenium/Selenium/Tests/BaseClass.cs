using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class BaseClass
    {
        public IWebDriver _driver;
        IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void FillInput(By selector, string value)
        {
            var fieldToTest = _driver.FindElement(selector);
            ScrollTo(fieldToTest);
            fieldToTest.SendKeys(value);
        }

        public void FillAndEnter(By selector, string value)
        {
            var fieldTotest = _driver.FindElement(selector);
            FillInput(selector, value);
            fieldTotest.SendKeys(Keys.Enter);
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
    }
}
