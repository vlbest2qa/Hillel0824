using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TextBoxTest
{
    [Test]
    public async Task HasTitle()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/text-box");
        await page.GetByPlaceholder("Full Name").FillAsync("John Doe");
        await page.GetByPlaceholder("name@example.com").FillAsync("some@mail.com");
        await page.GetByPlaceholder("Current Address").FillAsync("current address");
        await page.Locator("#permanentAddress").FillAsync("permabebt adreee");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Assertions.Expect(page.Locator("#name")).ToContainTextAsync("Name:John Doe");
        await Assertions.Expect(page.Locator("#email")).ToContainTextAsync("Email:some@mail.com");
        await Assertions.Expect(page.Locator("#output")).ToContainTextAsync("Current Address :current address");
        await Assertions.Expect(page.Locator("#output")).ToContainTextAsync("Permananet Address :permabebt adreee");
    }
}