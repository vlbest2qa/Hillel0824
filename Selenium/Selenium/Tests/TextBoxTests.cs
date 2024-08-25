using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Selenium
{
    public class TextBoxTests : AutomationPracticeFormTests
    {

        [Test]
        
        public void FillAndSubmitTextBox()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            string fullName = "Kotelevets Vladyslav";
            string email = "myemail@gmail.com";
            string currentAdress = "4B Serpova street, Kharkiv, Ukraine";
            string permanentAdress = "8 Berejnia street, Vasisheve, Ukraine";

            // Scroll to Full Name and fill it out
            FillInput(By.Id("userName"), fullName);

            // Scroll to Email and fill it out
            FillInput(By.Id("userEmail"), email);

            // Scroll to Current Address and fill it out
            FillInput(By.XPath("//*[@placeholder='Current Address']"), currentAdress);

            // Scroll to Permanent Address and fill it out
            FillInput(By.XPath("//*[@class='col-md-9 col-sm-12']//*[@id='permanentAddress']"), permanentAdress);

            // Scroll to Sublimit and set it
            ClickElement(By.Id("submit"));

            // Scroll to and verify validation

            Assert.That("Name:" + fullName, Is.EqualTo(GetTextElement(By.Id("name"))), "Full Name validation failed.");
            Assert.That("Email:" + email, Is.EqualTo(GetTextElement(By.Id("email"))), "Email validation failed.");
            Assert.That("Current Address :" + currentAdress, Is.EqualTo(GetTextElement(By.CssSelector("#output #currentAddress.mb-1"))), "Current Address validation failed.");
            Assert.That("Permananet Address :" + permanentAdress, Is.EqualTo(GetTextElement(By.XPath("//*[@Id='output']//*[@id='permanentAddress']"))), "Permananet Address validation failed.");

        }
    }
}