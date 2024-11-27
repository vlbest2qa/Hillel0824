using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class ProductPage(IPage page) : BasePage(page)
    {
        public ILocator ProductDetails()
        {
            return _page.Locator(".product-details");
        }

        public async Task SetProductQuantity(string quantity)
        {
            await _page.Locator("#quantity").FillAsync(quantity);
        }
        public async Task ClickAddToCart()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" }).ClickAsync();
        }
    }
}