using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class APILoginTest : UITestFixture
    {
        [Test]
        public async Task LoginAPI()
        {
            // Arrange
            var apiLogin = new APILogin(page);
            var userCabinet = new UserCabinetPage(page);

            string email = "mymail@gmail.com";
            string password = "test";

            // Act
            await apiLogin.APIlogin(email, password); 
            await userCabinet.Open();

            // Assert
            await Assertions.Expect(userCabinet.PageHeader()).ToBeVisibleAsync();
        }
    }
}
