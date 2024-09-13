using OpenQA.Selenium;

namespace Selenium
{
    internal class WebTablesPage
    {
        public WebTablesPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver _driver;

        private string pageUrl = "https://demoqa.com/webtables";
        private By addButtonBy = By.Id("addNewRecordButton");
        private By firstNameBy = By.Id("firstName");
        private By lastNameBy = By.Id("lastName");
        private By emailBy = By.Id("userEmail");
        private By ageBy = By.Id("age");
        private By salaryBy = By.Id("salary");
        private By departmentBy = By.Id("department");
        private By SubmitButtonBy = By.Id("submit");
        

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void ClickAddButton()
        {
            _driver.ClickElement(addButtonBy);
        }

        public void FillRegistrationForm(string firstName, string lastName, string email, string age, string salary, string department)
        {
            _driver.FillInput(firstNameBy, firstName);
            _driver.FillInput(lastNameBy, lastName);
            _driver.FillInput(emailBy, email);
            _driver.FillInput(ageBy, age);
            _driver.FillInput(salaryBy, salary);
            _driver.FillInput(departmentBy, department);
        }

        public void ClickFormSubmitButton()
        {
            _driver.ClickElement(SubmitButtonBy);
        }

        public bool СheckAddedSting(string value, string whichString)
        {
            By ResultStringBy = By.XPath($"//*[@class='rt-tbody']//*[@class='rt-tr-group']//*[contains(@class,'rt-tr') and *[@class='rt-td' and text()='{whichString}']]");
            return _driver.GetTextElement(ResultStringBy).Contains(value);
        }
    }
}
