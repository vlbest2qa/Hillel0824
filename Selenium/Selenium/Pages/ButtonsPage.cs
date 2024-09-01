using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium.Pages
{
    internal class ButtonsPage : BasePage
    {
        public ButtonsPage(IWebDriver driver) : base(driver)
        {
        }

        private By doubleClickButtonBy = By.Id("doubleClickBtn");
        private By doubleClickMessageBy = By.Id("doubleClickMessage");
        private By rightClickButtonBy = By.Id("rightClickBtn");
        private By rightClickMessageBy = By.Id("rightClickMessage");
        private By clickMeButtonBy = By.XPath("//button[text()='Click Me']");
        private By clickMeButtonMassageBy = By.Id("dynamicClickMessage");


        
        public void DoubleClickTheButton()
        {
            DoubleClickAction(doubleClickButtonBy);
        }

        public bool IsDoubleClickMassegeDisplayed()
        {
            return IsElenentDisplayed(doubleClickMessageBy);
        }

        public string DoubleClickMassegeText()
        {
            return GetElementText(doubleClickMessageBy);
        }

        public void RightClickTheButton()
        {
            RightClickAction(rightClickButtonBy);
        }

        public bool IsRightClickMassegeDisplayed()
        {
            return IsElenentDisplayed(rightClickMessageBy);
        }

        public string RightClickMassegeText()
        {
            return GetElementText(rightClickMessageBy);
        }
        
        public void ClickMeAction() 
        {
            ClickElement(clickMeButtonBy); 
        }

        public bool IsClickMeMassegeDisplayed()
        {
            return IsElenentDisplayed(clickMeButtonMassageBy);
        }

        public string ClickMeMassegeText()
        {
            return GetElementText(clickMeButtonMassageBy);
        }

    }
}
