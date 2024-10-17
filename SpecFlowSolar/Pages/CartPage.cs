using OpenQA.Selenium;

namespace SpecFlowSolar.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        private By removeProductButtonBy = By.CssSelector("span.remove-from-cart");

        public void RemoveProductFromCartIfOne()
        {
            WaitAndClickElement(removeProductButtonBy);
            WaitForLoader();
        }
    }
}
