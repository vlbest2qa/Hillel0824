using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium
{
    internal class ButtonsPage
    {
        public ButtonsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver _driver;

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
            _driver.DoubleClickAction(doubleClickButtonBy);
        }

        public bool IsDoubleClickMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(doubleClickMessageBy);
        }

        public string DoubleClickMassegeText()
        {
            return _driver.GetTextElement(doubleClickMessageBy);
        }

        public void RightClickTheButton()
        {
            _driver.RightClickAction(rightClickButtonBy);
        }

        public bool IsRightClickMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(rightClickMessageBy);
        }

        public string RightClickMassegeText()
        {
            return _driver.GetTextElement(rightClickMessageBy);
        }
        
        public void ClickMeAction() 
        {
            _driver.ClickElement(clickMeButtonBy); 
        }

        public bool IsClickMeMassegeDisplayed()
        {
            return _driver.IsElenentDisplayed(clickMeButtonMassageBy);
        }

        public string ClickMeMassegeText()
        {
            return _driver.GetTextElement(clickMeButtonMassageBy);
        }

    }
}
