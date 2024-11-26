using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class BasePage(IPage page)
    {
        protected readonly IPage _page = page;

        public async Task<string> GetPageTitle()
        {
            return await _page.TitleAsync();
        }

        public async Task ClickLinkShopMenu(string name)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = name }).ClickAsync();
        }

        public void RunListenDialogBrowser(bool isAccept)
        {
            _page.Dialog += async (_, dialog) =>
            {
                if (isAccept)
                {
                    await dialog.AcceptAsync();
                }
                else
                {
                    await dialog.DismissAsync();
                }
            };
        }
    }
}
