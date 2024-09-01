using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium
{
    public class TextBoxTests : BaseClass
    {

        [Test]
        
        public void FillAndSubmitTextBox()
        {
            // Arrange
            var textBoxPage = new TextBoxPage(_driver);

            textBoxPage.NavigateTo("https://demoqa.com/text-box");

            string fullName = "Kotelevets Vladyslav";
            string email = "myemail@gmail.com";
            string currentAdress = "4B Serpova street, Kharkiv, Ukraine";
            string permanentAdress = "8 Berejnia street, Vasisheve, Ukraine";

            // Act
            textBoxPage.FillFullName(fullName);
            textBoxPage.FillEmail(email);
            textBoxPage.FillCurrentAdress(currentAdress);
            textBoxPage.FillPermanentAdress(permanentAdress);
            textBoxPage.ClickSubmitButton();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:" + fullName), "Full Name validation failed.");
                Assert.That(textBoxPage.GetOutputEmail(), Is.EqualTo("Email:" + email), "Email validation failed.");
                Assert.That(textBoxPage.GetCurrentAdress(), Is.EqualTo("Current Address :" + currentAdress), "Current Address validation failed.");
                Assert.That(textBoxPage.GetPermanentAdress(), Is.EqualTo("Permananet Address :" + permanentAdress), "Permananet Address validation failed.");
            });
        }
    }
}