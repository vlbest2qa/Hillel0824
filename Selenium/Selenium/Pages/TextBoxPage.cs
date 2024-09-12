using OpenQA.Selenium;

namespace Selenium
{
    internal class TextBoxPage
    {
        public TextBoxPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver _driver;

        private string pageUrl = "https://demoqa.com/text-box";
        By fullNameBy = By.Id("userName");
        By emailBy = By.Id("userEmail");
        By currentAddressBy = By.XPath("//*[@placeholder='Current Address']");
        By permanentAddressBy = By.XPath("//*[@class='col-md-9 col-sm-12']//*[@id='permanentAddress']");
        By submitButtonBy = By.Id("submit");
        By nameOutputBy = By.Id("name");
        By emailOutputBy = By.Id("email");
        By currentOutputAddressBy = By.CssSelector("#output #currentAddress.mb-1");
        By permanentOutputAddressBy = By.XPath("//*[@Id='output']//*[@id='permanentAddress']");

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void FillFullName(string fullName)
        {
            _driver.FillInput(fullNameBy, fullName);
        }

        public void FillEmail(string email)
        {
            _driver.FillInput(emailBy, email);
        }

        public void FillCurrentAdress(string currentAdress)
        {
            _driver.FillInput(currentAddressBy, currentAdress);
        }

        public void FillPermanentAdress(string permanentAdress)
        {
            _driver.FillInput(permanentAddressBy, permanentAdress);
        }

        public void ClickSubmitButton()
        {
            _driver.ClickElement(submitButtonBy);
        }
        
        public string GetOutputName()
        {
            return _driver.GetTextElement(nameOutputBy);
        }
        
        public string GetOutputEmail()
        {
            return _driver.GetTextElement(emailOutputBy);
        }
        
        public string GetCurrentAdress()
        {
            return _driver.GetTextElement(currentOutputAddressBy);
        }
        
        public string GetPermanentAdress()
        {
            return _driver.GetTextElement(permanentOutputAddressBy);
        }
    }
}
