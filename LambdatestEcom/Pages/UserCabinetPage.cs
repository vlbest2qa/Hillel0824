using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class UserCabinetPage
    {
        private readonly IPage _page;

        public UserCabinetPage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");
        }

        public async Task<bool> IsUserCabinetOpen()
        {
            return await _page.GetByRole(AriaRole.Heading, new() { Name = "My Account" }).IsVisibleAsync();
        }
    }
}
