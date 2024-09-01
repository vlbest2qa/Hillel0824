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
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");

            // Act
            buttonsPage.DoubleClickAction();

            // Assert
            Assert.That(buttonsPage.IsDoubleClickMassegeDisplayed());
            Assert.That(buttonsPage.DoubleClickMassegeText(), Is.EqualTo("You have done a double click"));
        }

        [Test]
        public void RightClickButtonTest()
        {
            // Arrange
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            var buttonsPage = new ButtonsPage(_driver);

            // Act
            buttonsPage.RightClickAction();

            // Assert
            Assert.That(buttonsPage.IsRightClickMassegeDisplayed());
            Assert.That(buttonsPage.RightClickMassegeText(), Is.EqualTo("You have done a right click"));
        }

        [Test]
        public void ClickMeButtonTest()
        {
            // Arrange
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            var buttonsPage = new ButtonsPage(_driver);

            // Act
            buttonsPage.ClickMeAction();

            // Assert
            Assert.That(buttonsPage.IsClickMeMassegeDisplayed());
            Assert.That(buttonsPage.ClickMeMassegeText(), Is.EqualTo("You have done a dynamic click"));
        }
    }
}