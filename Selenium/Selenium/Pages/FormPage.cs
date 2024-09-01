using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Pages
{
    internal class FormPage
    {
        public IJavaScriptExecutor _js;
        public IWebDriver _driver;

        private By firstNameInputBy = By.Id("firstName");
        private By lastNameInputBy = By.Id("lastName");
        private By emailInputBy = By.Id("userEmail");
        private By mobileNumberInputBy = By.Id("userNumber");
        private By currentAddressInputBy = By.Id("currentAddress");
        private By dateOfBirthInputBy = By.Id("dateOfBirthInput");
        private By monthPickerBy = By.ClassName("react-datepicker__month-select");
        private By yearPickerBy = By.ClassName("react-datepicker__year-select");
        private By subjectsInputBy = By.Id("subjectsInput");
        private By stateDropdownBy = By.Id("state");
        private By cityDropdownBy = By.Id("city");
        private By submitButtonBy = By.Id("submit");
        private By confirmationModalBy = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver) 
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;

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

        public void FillFirstName(string firstName)
        {
            FillInput(firstNameInputBy, firstName);
        }
        
        public void FillLastName(string lastName)
        {
            FillInput(lastNameInputBy, lastName);
        }
        
        public void FillEmail(string email)
        {
            FillInput(emailInputBy, email);
        }

        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
                    break;
                case "Female":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
                    break;
                case "Other":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-3']")).Click();
                    break;
                default:
                    Console.WriteLine($"The gender option '{gender}' is not recognized.");
                    break;
            }
        }

        public void FillMobileNubmer(string mobileNumber)
        {
            FillInput(mobileNumberInputBy, mobileNumber);
        }

        public void SelectDateOfBirth(string month, string year, string day)
        {
            By dayPickerBy = By.CssSelector($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            ClickElement(dateOfBirthInputBy);
            SelectDefinedElement(monthPickerBy, month);
            SelectDefinedElement(yearPickerBy, year);
            ClickElement(dayPickerBy);
        }

        public void SelectSubject(string value)
        {
            var fieldTotest = _driver.FindElement(subjectsInputBy);
            FillInput(subjectsInputBy, value);
            fieldTotest.SendKeys(Keys.Enter);
        }

        public void SelectHobby(string hobby)
        {
            switch (hobby)
            {
                case "Sports":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
                    break;
                case "Reading":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']")).Click();
                    break;
                case "Music":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']")).Click();
                    break;
                default:
                    Console.WriteLine($"The hobby option '{hobby}' is not recognized.");
                    break;
            }
        }

        public void FillCurrentAddress(string currentAddress)
        {
            FillInput(currentAddressInputBy, currentAddress);
        }

        public void SelectState(string state)
        {
            ClickElement(stateDropdownBy);
            ClickElement(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            ClickElement(cityDropdownBy);
            ClickElement(By.XPath($"//div[text()='{city}']"));
        }

        public void ClickSubmitButton()
        {
            ClickElement(submitButtonBy);
        }

        public string GetConfirmationModalText()
        {
            var confirmationModal = _driver.FindElement(confirmationModalBy);
            return confirmationModal.Text;
        }

        public bool IsConfirmationModalDisplayed()
        {
            var confirmationModal = _driver.FindElement(confirmationModalBy);
            return confirmationModal.Displayed;
        }
    }
}