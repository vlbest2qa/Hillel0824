using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class SearchProductTests : UITestFixture
    {
        [Test]
        public async Task ValidFillAndSubmitForm()
        {
            // Arrange
            var homePage = new HomePage(page);
            var productsPage = new ProductsPage(page);
            var searchText = "Men";

            // Act
            await homePage.Open();
            Assert.That(await homePage.GetPageTitle(), Is.EqualTo("Automation Exercise"));
            await homePage.ClickLinkShopMenu("Products");
            Assert.That(await homePage.GetPageTitle(), Is.EqualTo("Automation Exercise - All Products"));
            await productsPage.FillSearchInput(searchText);
            await productsPage.ClickSearchButton();

            // Assert
            await Assertions.Expect(productsPage.HeaderAfterSearch()).ToBeVisibleAsync();

            var namesOfProducts = await productsPage.GetTextOfProductsNames();
            Assert.That(namesOfProducts, Is.Not.Empty, "Number of products after search 0");

            foreach (var text in namesOfProducts)
            {
                Assert.That(text.Contains(searchText, StringComparison.OrdinalIgnoreCase), Is.True
                    , $"The product name does not contain a search query '{searchText}'.");
            }
        }
    }
}
