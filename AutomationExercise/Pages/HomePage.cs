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
    }
}
