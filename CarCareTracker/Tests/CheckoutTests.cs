using DecoratorDesignPatternTests.Models;
using CarCareTracker.Pages;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            

            var homePage = new HomePage(page);

            // Act
            await homePage.Open();
            //await homePage.OpenCategory("Laptops & Notebooks");


            // Assert
            StringAssert.EndsWith("", page.Url);
        }

    }
}
