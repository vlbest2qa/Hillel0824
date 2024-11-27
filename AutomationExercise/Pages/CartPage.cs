using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class CartPage(IPage page) : BasePage(page)
    {
        public async Task<string> GetQuantityOneProduct()
        {
            return await _page.Locator(".cart_quantity").InnerTextAsync();
        }
    }
}
