using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Selenium
{
    public class AutomationPracticeFormTests
    {
        private IWebDriver _driver;
        IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            _js = (IJavaScriptExecutor)_driver;
        }

        private void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        private void FillInput(By selector, string value)
        {
            var fieldToTest = _driver.FindElement(selector);
            ScrollTo(fieldToTest);
            fieldToTest.SendKeys(value);
        }

        //Мне кажется это уже излишним, но как вариант
        private void FillAndEnter(By selector, string value)
        {
            var fieldTotest = _driver.FindElement(selector);
            FillInput(selector, value);
            fieldTotest.SendKeys(Keys.Enter);
        }

        private void ClickElement(By selector)
        {
            var elementForClick = _driver.FindElement(selector);
            ScrollTo(elementForClick);
            elementForClick.Click();
        }
        private void SelectElement(By selector, string value)
        {
            var fieldToTest = new SelectElement(_driver.FindElement(selector));
            fieldToTest.SelectByText(value);
        }

        public string GetBorderColor(By selector)
        {
            var fieldTotest = _driver.FindElement(selector);
            ScrollTo(fieldTotest);
            //string x = fieldTotest.GetCssValue("border-color");
            return fieldTotest.GetCssValue("border-color");
        }

        [Test]
        public void FillAndSubmitFormTest()
        {
            // Scroll to First Name and fill it out
            FillInput(By.Id("firstName"), "John");

            // Scroll to Last Name and fill it out
            FillInput(By.Id("lastName"), "Doe");

            // Scroll to Email and fill it out
            FillInput(By.Id("userEmail"), "johndoe@example.com");

            // Scroll to Gender and set it
            ClickElement(By.CssSelector("label[for='gender-radio-1']"));

            // Scroll to Mobile Number and fill it out
            FillInput(By.Id("userNumber"), "1234567890");

            // Scroll to Date of Birth and set it
            ClickElement(By.Id("dateOfBirthInput"));
            SelectElement(By.ClassName("react-datepicker__month-select"), "May");
            SelectElement(By.ClassName("react-datepicker__year-select"), "1990");
            ClickElement(By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));

            // Scroll to Subjects and fill it out
            FillAndEnter(By.Id("subjectsInput"), "Maths");

            // Scroll to Hobbies and select one
            ClickElement(By.CssSelector("label[for='hobbies-checkbox-1']"));

            // Scroll to Current Address and fill it out
            FillInput(By.Id("currentAddress"), "123 Main Street, Anytown, USA");

            // Scroll to State dropdown and select a state
            ClickElement(By.Id("state"));
            ClickElement(By.XPath("//div[text()='NCR']"));

            // Scroll to City dropdown and select a city

            ClickElement(By.Id("city"));
            ClickElement(By.XPath("//div[text()='Delhi']"));

            // Scroll to Submit button and click it
            ClickElement(By.Id("submit"));

            // Validate the Form Submission (e.g., check for the confirmation modal)
            var confirmationModal = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));
            Assert.That(confirmationModal.Displayed);
            Assert.That(confirmationModal.Text, Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {

            // Check if the border color indicates an error
            string mandatoryFieldBorderColor = "rgb(220, 53, 69)"; // Red
            string optionalFieldBorderColor = "rgb(40, 167, 69)"; //Green

            // Scroll to and click the Submit button without filling any field
            ClickElement(By.Id("submit"));

            // Scroll to and verify validation for First Name
            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(GetBorderColor(By.Id("firstName"))), "First Name validation failed.");

            // Scroll to and verify validation for Last Name
            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(GetBorderColor(By.Id("lastName"))), "Last Name validation failed.");

            // Scroll to and verify validation for Email
            Assert.That(optionalFieldBorderColor, Is.EqualTo(GetBorderColor(By.Id("userEmail"))), "Email validation failed.");

            // Scroll to and verify validation for Mobile Number
            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(GetBorderColor(By.Id("userNumber"))), "Mobile Number validation failed.");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}