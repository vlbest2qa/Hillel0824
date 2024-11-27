using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class CartPage(IPage page) : BasePage(page)
    {
        public async Task<string> GetFirstProductQuantity()
        {
            return await _page.Locator(".cart_quantity").First.InnerTextAsync();
        }

        public async Task RemoveFirstProductFromCart()
        {
            await _page.Locator(".cart_quantity_delete").First.ClickAsync();
        }

        public ILocator SearchProductInCart(string productName)
        {
            return _page.GetByRole(AriaRole.Link, new() { Name = productName });
        }
    }
}
