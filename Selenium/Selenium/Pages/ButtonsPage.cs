using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium
{
    internal class ButtonsPage : BasePage
    {
        public ButtonsPage(IWebDriver driver) : base(driver)
        {
        }

        private string pageUrl = "https://demoqa.com/buttons";
        private By doubleClickButtonBy = By.Id("doubleClickBtn");
        private By doubleClickMessageBy = By.Id("doubleClickMessage");
        private By rightClickButtonBy = By.Id("rightClickBtn");
        private By rightClickMessageBy = By.Id("rightClickMessage");
        private By clickMeButtonBy = By.XPath("//button[text()='Click Me']");
        private By clickMeButtonMassageBy = By.Id("dynamicClickMessage");

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void DoubleClickTheButton()
        {
            DoubleClickAction(doubleClickButtonBy);
        }

        public bool IsDoubleClickMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(doubleClickMessageBy);
        }

        public string DoubleClickMassegeText()
        {
            return _driver.GetElementText(doubleClickMessageBy);
        }

        public void RightClickTheButton()
        {
            RightClickAction(rightClickButtonBy);
        }

        public bool IsRightClickMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(rightClickMessageBy);
        }

        public string RightClickMassegeText()
        {
            return _driver.GetElementText(rightClickMessageBy);
        }
        
        public void ClickMeAction() 
        {
            ClickElement(clickMeButtonBy); 
        }

        public bool IsClickMeMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(clickMeButtonMassageBy);
        }

        public string ClickMeMassegeText()
        {
            return _driver.GetElementText(clickMeButtonMassageBy);
        }

    }
}
