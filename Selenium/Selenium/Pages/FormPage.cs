using OpenQA.Selenium;

namespace Selenium
{
    internal class FormPage
    {
        private string pageUrl = "https://demoqa.com/automation-practice-form";
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
        private string border = "border-color";

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver _driver;

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void FillFirstName(string firstName)
        {
            _driver.FillInput(firstNameInputBy, firstName);
        }

        public void FillLastName(string lastName)
        {
            _driver.FillInput(lastNameInputBy, lastName);
        }
        
        public void FillEmail(string email)
        {
            _driver.FillInput(emailInputBy, email);
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
            _driver.FillInput(mobileNumberInputBy, mobileNumber);
        }

        public void SelectDateOfBirth(string month, string year, string day)
        {
            By dayPickerBy = By.CssSelector($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            _driver.ClickElement(dateOfBirthInputBy);
            _driver.SelectDefinedElement(monthPickerBy, month);
            _driver.SelectDefinedElement(yearPickerBy, year);
            _driver.ClickElement(dayPickerBy);
        }

        public void SelectSubject(string value)
        {
            _driver.FillInput(subjectsInputBy, value);
            _driver.FindElement(subjectsInputBy).SendKeys(Keys.Enter);
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
            _driver.FillInput(currentAddressInputBy, currentAddress);
        }

        public void SelectState(string state)
        {
            _driver.ClickElement(stateDropdownBy);
            _driver.ClickElement(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            _driver.ClickElement(cityDropdownBy);
            _driver.ClickElement(By.XPath($"//div[text()='{city}']"));
        }

        public void ClickSubmitButton()
        {
            _driver.ClickElement(submitButtonBy);
        }

        public string GetConfirmationModalText()
        {
            return _driver.GetTextElement(confirmationModalBy);
        }

        public bool IsConfirmationModalDisplayed()
        {
            return _driver.IsElenentDisplayed(confirmationModalBy);
        }

        public string GetBorderColor(By selector)
        {
            return _driver.GetElementColor(selector, border);
        }
    }
}