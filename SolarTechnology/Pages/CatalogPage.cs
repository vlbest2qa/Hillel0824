using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTechnology.Pages
{
    public class CatalogPage : BasePage
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        private By productTitle = By.CssSelector(".card-content .list-product-title");
        private By filterButton = By.CssSelector(".filter-button");
        
        public int CountFindProducts()
        {
            var products = FindElements(productTitle);
            return products.Count;
        }

        public void OpenFilters()
        {
            WaitAndClickElement(filterButton);
        }

        public void CheckBrand(string brand)
        {
            var brandCheckbox = By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']");
            WaitAndClickElement(brandCheckbox);

            WaitForLoader();
        }
    }
}
