using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium
{
    public class TextBoxTests : BaseClass
    {

        [Test]
        
        public void FillAndSubmitTextBox()
        {
            var formPage = new FormPage(_driver);

            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            By fullNameBy = By.Id("userName");
            By emailBy = By.Id("userEmail");
            By currentAddressBy = By.XPath("//*[@placeholder='Current Address']");
            By permanentAddressBy = By.XPath("//*[@class='col-md-9 col-sm-12']//*[@id='permanentAddress']");
            By nameOutputBy = By.Id("name");
            By emailOutputBy = By.Id("email");
            By currentOutputAddressBy = By.CssSelector("#output #currentAddress.mb-1");
            By permanentOutputAddressBy = By.XPath("//*[@Id='output']//*[@id='permanentAddress']");
            By submitButtonBy = By.Id("submit");
            string fullName = "Kotelevets Vladyslav";
            string email = "myemail@gmail.com";
            string currentAdress = "4B Serpova street, Kharkiv, Ukraine";
            string permanentAdress = "8 Berejnia street, Vasisheve, Ukraine";

            formPage.FillInput(fullNameBy, fullName);
            formPage.FillInput(emailBy, email);
            formPage.FillInput(currentAddressBy, currentAdress);
            formPage.FillInput(permanentAddressBy, permanentAdress);
            formPage.ClickElement(submitButtonBy);

            Assert.That("Name:" + fullName, Is.EqualTo(formPage.GetTextElement(nameOutputBy)), "Full Name validation failed.");
            Assert.That("Email:" + email, Is.EqualTo(formPage.GetTextElement(emailOutputBy)), "Email validation failed.");
            Assert.That("Current Address :" + currentAdress, Is.EqualTo(formPage.GetTextElement(currentOutputAddressBy)), "Current Address validation failed.");
            Assert.That("Permananet Address :" + permanentAdress, Is.EqualTo(formPage.GetTextElement(permanentOutputAddressBy)), "Permananet Address validation failed.");
        }
    }
}