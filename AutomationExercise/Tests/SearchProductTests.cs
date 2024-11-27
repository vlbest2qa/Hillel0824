using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class SearchProductTests : UITestFixture
    {
        [Test]
        public async Task CheckSearchResult()
        {
            // Arrange
            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var searchText = "Men";

            // Act
            await homePage.Open();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();

            await homePage.ClickLinkShopMenu("Products");
            await Assertions.Expect(catalogPage.HeaderAllProducts()).ToBeVisibleAsync();

            await catalogPage.FillSearchInput(searchText);
            await catalogPage.ClickSearchButton();

            // Assert
            await Assertions.Expect(catalogPage.HeaderAfterSearch()).ToBeVisibleAsync();

            var namesOfProducts = await catalogPage.GetTextOfProductsNames();
            Assert.That(namesOfProducts, Is.Not.Empty, "Number of products after search 0");

            foreach (var text in namesOfProducts)
            {
                Assert.That(text.Contains(searchText, StringComparison.OrdinalIgnoreCase), Is.True
                    , $"The product name does not contain a search query '{searchText}'.");
            }
        }
    }
}
