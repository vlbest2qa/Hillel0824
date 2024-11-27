using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class CartTests : UITestFixture
    {
        [Test]
        public async Task VerifyProductQuantityInCart()
        {
            // Arrange
            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var productPage = new ProductPage(page);
            var cartPage = new CartPage(page);
            var whichProductOpen = 2;
            var productQuantity = "4";

            // Act
            await homePage.Open();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();

            await catalogPage.OpenProductDetail(whichProductOpen);
            await Assertions.Expect(productPage.ProductDetails()).ToBeVisibleAsync();

            await productPage.SetProductQuantity(productQuantity);
            await productPage.ClickAddToCart();
            await productPage.ClickViewCartInPopup();

            // Assert
            Assert.That(await cartPage.GetFirstProductQuantity(), Is.EqualTo(productQuantity)
                , $"Quantity of product in cart does not match the set quantity: {productQuantity}");
        }

        [TearDown]
        public async Task RemoveProductFromCartAfterTest()
        {
            var cartPage = new CartPage(page);
            await cartPage.RemoveFirstProductFromCart();
        }
    }
}
