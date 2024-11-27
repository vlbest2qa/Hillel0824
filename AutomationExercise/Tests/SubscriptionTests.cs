using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class SubscriptionTests : UITestFixture
    {
        [Test]
        public async Task CheckSubscriptionFormInCartPage()
        {
            // Arrange
            var homePage = new HomePage(page);

            // Act
            await homePage.Open();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();

            await homePage.ClickLinkShopMenu("Cart");

            await Assertions.Expect(homePage.SubscriptionHeader()).ToBeVisibleAsync();
            await homePage.FillAndSubmitSubscription(TestConstants.EmailForUserCreate);

            // Assert
            await Assertions.Expect(homePage.SubscriptionAlertSuccess()).ToBeVisibleAsync();
            await Assertions.Expect(homePage.SubscriptionAlertSuccess()).ToHaveTextAsync("You have been successfully subscribed!");
        }
    }
}
