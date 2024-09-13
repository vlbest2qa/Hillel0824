using OpenQA.Selenium;
using System.Xml.Linq;

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
        private By submitButtonBy = By.Id("submit");
        private By deleteButtonBy = By.XPath("//*[@class='rt-tbody']//*[contains(@class,'rt-tr-group')]//*[@class='rt-td']//ancestor::*[@role='row']//*[@title='Delete']");
        private By rowsBy = By.XPath("//*[@class='rt-tbody']//*[contains(@class,'rt-tr-group')]");

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
            _driver.ClickElement(submitButtonBy);
        }

        public bool СheckAddedRow(string value, string whichRow)
        {
            By ResultStringBy = By.XPath($"//*[@class='rt-tbody']//*[@class='rt-tr-group']//*[contains(@class,'rt-tr') and *[@class='rt-td' and text()='{whichRow}']]");
            return _driver.GetTextElement(ResultStringBy).Contains(value);
        }

        public async Task OpenAsync()
        {
            await Task.Run(() => _driver.NavigateTo(pageUrl));
        }

        public async Task DeleteRowInTableAsync(string whitchRow)
        {
            By deleteTestButtonBy = By.XPath($"//*[@class='rt-tbody']//*[contains(@class,'rt-tr-group')]//*[@class='rt-td' and text()='{whitchRow}']//ancestor::*[@role='row']//*[@title='Delete']");
            await Task.Run(() => _driver.ClickElement(deleteTestButtonBy));
        }

        public async Task<int> CountRowInTableAsync()
        {
            return await Task.Run(() => _driver.FindElements(deleteButtonBy).Count);
        }

        public async Task<bool> IsRowPresentAsync(string searchRowBy)
        {
            return await Task.Run(() =>
            {
                return _driver.FindElements(rowsBy).Any(ele => ele.Text.Contains(searchRowBy));
            });
        }
    }
}
