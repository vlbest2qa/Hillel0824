using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class RecommendedProductTests : UITestFixture
    {
        [Test]
        public async Task AddToCartRecommendedProduct()
        {
            // Arrange
            var homePage = new HomePage(page);
            var cartPage = new CartPage(page);
            var productName = "Men Tshirt";

            // Act
            await homePage.Open();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();

            await Assertions.Expect(homePage.RecommendedProductTitle()).ToHaveTextAsync("recommended items");
            await Assertions.Expect(homePage.RecommendedProductCarousel()).ToBeVisibleAsync();

            await homePage.ClickAddToCartInRecommendedProduct(productName);
            await homePage.ClickViewCartInPopup();

            // Assert
            await Assertions.Expect(cartPage.SearchProductInCart(productName)).ToBeVisibleAsync();
        }
    }
}