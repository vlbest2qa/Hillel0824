using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
        }

        public async Task LoginAndSaveState()
        {
            await Open();
            await _page.GetByPlaceholder("E-Mail Address").FillAsync("mymail@gmail.com");
            await _page.GetByPlaceholder("Password").FillAsync("test");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await _page.Context.StorageStateAsync(new()
            {
                Path = "../../../playwright/.auth/state.json"
            });
        }
    }
}
