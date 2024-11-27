using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class CatalogPage(IPage page) : BasePage(page)
    {
        public async Task FillSearchInput(string searchText)
        {
            await _page.GetByPlaceholder("Search Product").FillAsync(searchText);
        }

        public async Task ClickSearchButton()
        {
            await _page.Locator("#submit_search").ClickAsync();
        }

        public ILocator HeaderAfterSearch()
        {
            return _page.GetByRole(AriaRole.Heading, new() { Name = "Searched Products" });
        }

        public ILocator HeaderAllProducts()
        {
            return _page.GetByRole(AriaRole.Heading, new() { Name = "All Products" });
        }

        public async Task<List<string>> GetTextOfProductsNames()
        {
            var selectors = _page.Locator(".productinfo p");
            var texts = new List<string>();

            for (int i = 0; i < await selectors.CountAsync(); i++)
            {
                texts.Add(await selectors.Nth(i).InnerTextAsync());
            }
            return texts;
        }

        public async Task OpenProductDetail(int productIndex)
        {
            await _page.Locator(".choose").Nth(productIndex).ClickAsync();
        }
    }
}