using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium.Pages;

namespace Selenium
{
    public class ButtonTests : BaseClass
    {
        [Test]
        public void DoubleClickButtonTest()
        {
            // Arrange
            var buttonsPage = new ButtonsPage(_driver);
            buttonsPage.NavigateTo("https://demoqa.com/buttons");

            // Act
            buttonsPage.DoubleClickTheButton();

            // Assert
            Assert.That(buttonsPage.IsDoubleClickMassegeDisplayed());
            Assert.That(buttonsPage.DoubleClickMassegeText(), Is.EqualTo("You have done a double click"));
        }

        [Test]
        public void RightClickButtonTest()
        {
            // Arrange
            var buttonsPage = new ButtonsPage(_driver);
            buttonsPage.NavigateTo("https://demoqa.com/buttons");

            // Act
            buttonsPage.RightClickTheButton();

            // Assert
            Assert.That(buttonsPage.IsRightClickMassegeDisplayed());
            Assert.That(buttonsPage.RightClickMassegeText(), Is.EqualTo("You have done a right click"));
        }

        [Test]
        public void ClickMeButtonTest()
        {
            // Arrange
            var buttonsPage = new ButtonsPage(_driver);
            buttonsPage.NavigateTo("https://demoqa.com/buttons");

            // Act
            buttonsPage.ClickMeAction();

            // Assert
            Assert.That(buttonsPage.IsClickMeMassegeDisplayed());
            Assert.That(buttonsPage.ClickMeMassegeText(), Is.EqualTo("You have done a dynamic click"));
        }
    }
}