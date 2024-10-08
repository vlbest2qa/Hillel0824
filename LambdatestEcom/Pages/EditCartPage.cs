using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class EditCartPage
    {
        private readonly IPage _page;

        public EditCartPage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetProductQuantity(string productName)
        {
            //рабочий общий:
            //return await _page.Locator(".table").Filter(new() { HasText = productName }).Locator("input[type='text']").InputValueAsync();
            return await _page.Locator($"tr:has-text('{productName}') input[name^='quantity']").InputValueAsync();
        }

        public async Task<string> GetCartTotal()
        {
            return await _page.Locator("#content").GetByRole(AriaRole.Row, new() { Name = "Total:" }).Nth(1).TextContentAsync();
        }

        public async Task ClickContinueShopping()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Continue Shopping" }).ClickAsync();
        }

        public async Task ChangeProductQuantityAndConfirm(string productName, string newQuantity)
        {
            await _page.Locator($"tr:has-text('{productName}') input[name^='quantity']").FillAsync(newQuantity);
            await _page.Locator($"tr:has-text('{productName}') button[type^='submit']").ClickAsync();
        }
    }
}