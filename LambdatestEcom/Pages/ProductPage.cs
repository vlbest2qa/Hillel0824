using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class ProductPage
    {
        private readonly IPage _page;

        public ProductPage(IPage page)
        {
            _page = page;
        }

        public async Task SetItemQuantity(string quantity)
        {
            await _page.GetByRole(AriaRole.Spinbutton, new() { Name = "Qty" }).FillAsync(quantity);
        }

        public async Task AddProductToCart()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add to Cart" }).ClickAsync();
        }
    }
}
