using OpenQA.Selenium;

namespace SolarTechnology.Pages
{
    public class CatalogPage : BasePage
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        private By productAreaBy = By.CssSelector(".card");
        private By filterButtonBy = By.CssSelector(".filter-button");
        private By addCartButtonBy = By.CssSelector(".add-product-to-cart");
        private By cartModalBy = By.CssSelector("div#cart-modal");
        private By goToCartInModalButtonBy = By.XPath("//a[contains(text(), 'Оформити замовлення')]");

        public int CountProducts()
        {
            return CountFindElements(productAreaBy);
        }

        public void OpenFilters()
        {
            WaitAndClickElement(filterButtonBy);
        }

        public void CheckBrandInFilters(string brand)
        {
            var brandCheckbox = By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']");
            WaitAndClickElement(brandCheckbox);
            WaitForLoader();
        }

        public void AddToCartSecondProduct()
        {
            var products = FindElements(productAreaBy);
            IWebElement secondProduct = products.ElementAt(1).FindElement(addCartButtonBy);
            secondProduct.Click();
            WaitForElementVisible(cartModalBy);
        }

        public void GoToCartInModal()
        {
            WaitAndClickElement(goToCartInModalButtonBy);
            WaitForLoader();
        }
    }
}
