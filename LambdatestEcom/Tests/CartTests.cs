using DecoratorDesignPatternTests.Models;
using LambdatestEcom.Pages;
using System.Security.Cryptography.X509Certificates;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CartTests : UITestFixture
    {
        [Test]
        public async Task ChangeLate()
        {
            // Arrange

            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var productPage = new ProductPage(page);
            var editCartPage = new EditCartPage(page);
            string searchProduct1 = "HP LP3065";
            string quantityProduct1 = "3";
            string totalWithProduct1 = " Total: $366.00 ";
            string searchProduct2 = "iPod Classic";
            string quantityProduct2 = "1";
            string totalWithProduct2 = " Total: $488.00 ";
            string totalWithProduct2UpdateQuantity = " Total: $610.00 ";

            // Act
            await homePage.Open();
            await homePage.FillHeaderSearchField(searchProduct1);
            await homePage.SelectInSearchDropdown(0);
            await productPage.SetItemQuantity(quantityProduct1);
            await productPage.AddProductToCart();
            await homePage.ClickViewCartOnPopup();

            Assert.Multiple(async () =>
            {
                Assert.That(await editCartPage.GetProductQuantity(searchProduct1), Is.EqualTo(quantityProduct1));
                Assert.That(await editCartPage.GetCartTotal(), Is.EqualTo(totalWithProduct1));
            });

            await editCartPage.ClickContinueShopping();
            await homePage.FillHeaderSearchField(searchProduct2, true);
            await catalogPage.AddProductToCart(0);
            await homePage.ClickViewCartOnPopup();

            Assert.Multiple(async () =>
            {
                Assert.That(await editCartPage.GetProductQuantity(searchProduct1), Is.EqualTo(quantityProduct1));
                Assert.That(await editCartPage.GetProductQuantity(searchProduct2), Is.EqualTo(quantityProduct2));
                Assert.That(await editCartPage.GetCartTotal(), Is.EqualTo(totalWithProduct2));
            });

            await editCartPage.ChangeProductQuantityAndConfirm(searchProduct2, "2");

            Assert.That(await editCartPage.GetCartTotal(), Is.EqualTo(totalWithProduct2UpdateQuantity));
        }
    }
}