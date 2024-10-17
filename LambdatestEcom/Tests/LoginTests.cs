using LambdatestEcom.Pages;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTests : UITestFixture
    {
        [Test]
        public async Task StateIsLoaded()
        {
            // Arrange
            var userCabinet = new UserCabinetPage(page);
            var loginPage = new LoginPage(page);

            // Act
            await userCabinet.Open();

            if (!await userCabinet.PageHeader().IsVisibleAsync())
            {
                await loginPage.LoginAndSaveState();
            }

            // Assert
            await Assertions.Expect(userCabinet.PageHeader()).ToBeVisibleAsync();
        }
    }
}
