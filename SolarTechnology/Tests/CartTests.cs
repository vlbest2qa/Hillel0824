using SolarTechnology.Pages;

namespace SolarTechnology.Tests
{
    internal class CartTests : UITestFixture
    {
        [Test]
        public void AddDeleteProductReturnToHome()
        {
            // Arrange
            var catalogPage = new CatalogPage(_driver);
            var homePage = new HomePage(_driver);
            var cartPage = new CartPage(_driver);
            homePage.OpenHomePage();
            homePage.OpenSolarCabels();

            //Act
            catalogPage.AddToCartOneProduct(1);
            catalogPage.GoToCartInModal();
            cartPage.RemoveProductFromCartIfOne();

            // Assert
            Assert.Multiple(() =>
            {
                //в процессе появлялись новые проверки. Оставил все, хотя IsCurentUrlEqualHome думаю было бы достаточно
                Assert.That(homePage.IsCurentUrlEqualHome(), Is.EqualTo(true), "Current url NOT equal home url.");
                Assert.That(homePage.IsTitleDisplayed(), Is.EqualTo(true), "Not found title on the page.");
                Assert.That(homePage.GetTitlelHome(), Is.EqualTo("Магазин"), "Current title not equal home title.");
            });
        }
    }
}
