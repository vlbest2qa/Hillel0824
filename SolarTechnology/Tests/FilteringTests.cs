using SolarTechnology.Pages;

namespace SolarTechnology.Tests
{
    internal class FilteringTests : UITestFixture
    {
        [Test]
        public void DiferentCountProductAfterFiltration()
        {
            // Arrange
            var catalogPage = new CatalogPage(_driver);
            var homePage = new HomePage(_driver);

            homePage.OpenHomePage();
            homePage.OpenHomePageMenu("/shop/solar-panels");

            // Act
            int productsBeforeFiltered = catalogPage.CountProducts();
            catalogPage.OpenFilters();
            catalogPage.CheckBrandInFilters("JA Solar");
            int productsAfterFiltered = catalogPage.CountProducts();

            // Assert
            Assert.That(productsAfterFiltered, Is.LessThan(productsBeforeFiltered), "Number of products after filtration bigest or the same before filtration!");
        }
    }
}