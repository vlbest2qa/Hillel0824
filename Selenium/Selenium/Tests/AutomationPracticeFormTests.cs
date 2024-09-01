using OpenQA.Selenium;
using Selenium.Pages;

namespace Selenium
{
    public class AutomationPracticeFormTests : BaseClass
    {
        [Test]
        public void FillAndSubmitFormTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);

            formPage.FillFirstName("John");
            formPage.FillLastName("Doe");
            formPage.FillEmail("johndoe@example.com");
            formPage.SelectGender("Male");
            formPage.FillMobileNubmer("1234567890");
            formPage.SelectDateOfBirth("May", "1990", "15");
            formPage.SelectSubject("Maths");
            formPage.SelectHobby("Sports");
            formPage.FillCurrentAddress("123 Main Street, Anytown, USA");
            formPage.SelectState("NCR");
            formPage.SelectCity("Delhi");
            formPage.ClickSubmitButton();

            Assert.That(formPage.IsConfirmationModalDisplayed());
            Assert.That(formPage.GetConfirmationModalText(), Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);
            string mandatoryFieldBorderColor = "rgb(220, 53, 69)";
            string optionalFieldBorderColor = "rgb(40, 167, 69)";
            By firstNameInputBy = By.Id("firstName");
            By lastNameInputBy = By.Id("lastName");
            By emailInputBy = By.Id("userEmail");
            By mobileNumberInputBy = By.Id("userNumber");
            
            formPage.ClickSubmitButton();
            Thread.Sleep(1000);

            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(formPage.GetBorderColor(firstNameInputBy)), "First Name validation failed.");
            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(formPage.GetBorderColor(lastNameInputBy)), "Last Name validation failed.");
            Assert.That(optionalFieldBorderColor, Is.EqualTo(formPage.GetBorderColor(emailInputBy)), "Email validation failed.");
            Assert.That(mandatoryFieldBorderColor, Is.EqualTo(formPage.GetBorderColor(mobileNumberInputBy)), "Mobile Number validation failed.");
        }
    }
}