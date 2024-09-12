using OpenQA.Selenium;

namespace Selenium
{
    internal class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {
        }

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
            FillInput(fullNameBy, fullName);
        }

        public void FillEmail(string email)
        {
            FillInput(emailBy, email);
        }

        public void FillCurrentAdress(string currentAdress)
        {
            FillInput(currentAddressBy, currentAdress);
        }

        public void FillPermanentAdress(string permanentAdress)
        {
            FillInput(permanentAddressBy, permanentAdress);
        }

        public void ClickSubmitButton()
        {
            ClickElement(submitButtonBy);
        }
        
        public string GetOutputName()
        {
            return GetTextElement(nameOutputBy);
        }
        
        public string GetOutputEmail()
        {
            return GetTextElement(emailOutputBy);
        }
        
        public string GetCurrentAdress()
        {
            return GetTextElement(currentOutputAddressBy);
        }
        
        public string GetPermanentAdress()
        {
            return GetTextElement(permanentOutputAddressBy);
        }

    }
}
