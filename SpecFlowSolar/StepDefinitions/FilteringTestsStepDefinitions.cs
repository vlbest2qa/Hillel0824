using NUnit.Framework;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    [Binding]
    public class FilteringTestsStepDefinitions : BaseClass
    {
        private int productsBeforeFiltered;
        private int productsAfterFiltered;

        [Given(@"open home page in FilteringTests")]
        public void GivenOpenHomePageInFilteringTests()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenHomePage();
        }

        [When(@"open solar cabels in menu in FilteringTests")]
        public void WhenOpenSolarCabelsInMenuInFilteringTests()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenSolarPanels();
        }

        [When(@"count product before filtered")]
        public void WhenCountProductBeforeFiltered()
        {
            var catalogPage = new CatalogPage(_driver);
            productsBeforeFiltered = catalogPage.CountProducts();
        }

        [When(@"open filters")]
        public void WhenOpenFilters()
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.OpenFilters();
        }

        [When(@"choose brand '([^']*)' in filters")]
        public void WhenChooseBrandInFilters(string p0)
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.CheckBrandInFilters("JA Solar");
        }

        [When(@"count product after filtered")]
        public void WhenCountProductAfterFiltered()
        {
            var catalogPage = new CatalogPage(_driver);
            productsAfterFiltered = catalogPage.CountProducts();
        }

        [Then(@"the quantity of products is different")]
        public void ThenTheQuantityOfProductsIsDifferent()
        {
            Assert.That(productsAfterFiltered, Is.LessThan(productsBeforeFiltered), "Number of products after filtration bigest or the same before filtration!");
        }
    }
}
