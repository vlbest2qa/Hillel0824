using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class HomePage(IPage page) : BasePage(page)
    {
        public async Task Open()
        {
            await _page.GotoAsync("http://automationexercise.com");
        }

        public ILocator SliderHomePage()
        {
            return _page.Locator("#slider-carousel");
        }

        public ILocator RecommendedProductCarousel()
        {
            return _page.Locator("#recommended-item-carousel");
        }

        public ILocator RecommendedProductTitle()
        {
            return _page.Locator(".recommended_items .title");
        }

        public async Task ClickAddToCartInRecommendedProduct(string productName)
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                var searchProduct = _page.Locator($".recommended_items .productinfo:has-text('{productName}')");

                if (await searchProduct.CountAsync() > 0)
                {
                    await searchProduct.Locator(".add-to-cart").ClickAsync();
                    return;
                }

                await _page.Locator(".right recommended-item-control").ClickAsync();
            }
        }
    }
}
