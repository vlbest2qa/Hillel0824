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
            var email = EmailForUserCreate;

            // Act
            await homePage.Open();
            Assert.That(await homePage.GetPageTitle(), Is.EqualTo("Automation Exercise"));
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();

            await homePage.ClickLinkShopMenu("Cart");

            await Assertions.Expect(homePage.SubscriptionHeader()).ToBeVisibleAsync();
            await homePage.FillAndSubmitSubscription(email);

            // Assert
            await Assertions.Expect(homePage.SubscriptionAlertSuccess()).ToBeVisibleAsync();
            await Assertions.Expect(homePage.SubscriptionAlertSuccess()).ToHaveTextAsync("You have been successfully subscribed!");
        }
    }
}
