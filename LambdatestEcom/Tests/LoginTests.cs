using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTests : UITestFixture
    {
        [Test]
        public async Task StateWithAuthIsLoaded()
        {
            // Arrange
            var userCabinet = new UserCabinetPage(page);

            // Act
            await userCabinet.Open();

            // Assert
            await Assertions.Expect(userCabinet.PageHeader()).ToBeVisibleAsync();
        }
    }
}
