using LambdatestEcom.Pages;

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
            Assert.That(await apiLogin.APIlogin(email, password), Is.True); 
            await userCabinet.Open();

            // Assert
            StringAssert.EndsWith("?route=account/account", page.Url);
            Assert.That(userCabinet.IsUserCabinetOpen().Result, Is.True);
        }
    }
}
