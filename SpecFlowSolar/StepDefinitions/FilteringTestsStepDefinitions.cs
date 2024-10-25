using NUnit.Framework;
using SpecFlowSolar.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowSolar.StepDefinitions
{
    [Binding]
    [Scope(Tag = "filteringTests")]
    public class FilteringTestsStepDefinitions : BaseClass
    {
        public FilteringTestsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            homePage = new HomePage(_driver);
            catalogPage = new CatalogPage(_driver);
        }

        private int productsBeforeFiltered;
        private int productsAfterFiltered;

        [Given(@"open home page")]
        public void GivenOpenHomePage()
        {
            homePage.OpenHomePage();
        }

        [When(@"open solar cabels in menu")]
        public void WhenOpenSolarCabelsInMenu()
        {
            homePage.OpenSolarPanels();
        }

        [When(@"count product before filtered")]
        public void WhenCountProductBeforeFiltered()
        {
            productsBeforeFiltered = catalogPage.CountProducts();
        }

        [When(@"open filters")]
        public void WhenOpenFilters()
        {
            catalogPage.OpenFilters();
        }

        [When(@"choose brand '([^']*)' in filters")]
        public void WhenChooseBrandInFilters(string p0)
        {
            catalogPage.CheckBrandInFilters("JA Solar");
        }

        [When(@"count product after filtered")]
        public void WhenCountProductAfterFiltered()
        {
            productsAfterFiltered = catalogPage.CountProducts();
        }

        [Then(@"the quantity of products is different")]
        public void ThenTheQuantityOfProductsIsDifferent()
        {
            Assert.That(productsAfterFiltered, Is.LessThan(productsBeforeFiltered), "Number of products after filtration bigest or the same before filtration!");
        }
    }
}
