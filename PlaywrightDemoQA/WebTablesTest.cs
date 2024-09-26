using Microsoft.Playwright;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class WebTablesTest
{
    [Test]
    public async Task DeleteRow()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByTitle("Delete").ClickAsync();
        await Assertions.Expect(page.GetByText("Alden")).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task EditRow()
    {
        static string CalculateNewSalary(string salary)
        {
            return ((int)(double.Parse(salary) * 1.1)).ToString();
        }

        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        var locatorAldenRow = page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) });
        var newLastName = "NewLastName";

        // Act
        await page.GotoAsync("https://demoqa.com/webtables");
        await locatorAldenRow.GetByTitle("Edit").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync(newLastName);
        var newSalary = CalculateNewSalary(await page.GetByPlaceholder("Salary").InputValueAsync());
        await page.GetByPlaceholder("Salary").FillAsync(newSalary);
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        // Assert
        await Assertions.Expect(locatorAldenRow).ToContainTextAsync(newSalary);
        await Assertions.Expect(locatorAldenRow).ToContainTextAsync(newLastName);
    }

    [Test]
    public async Task AddRow()
    {
        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        string firstName = "Vladyslav";
        string lastName = "Kotelevets";
        string email = "mymail@example.com";
        string age = "29";
        string salary = "100";
        string department = "Engineering";
        var locatorNewRow = page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = firstName, Exact = true }) });

        // Act
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await page.GetByPlaceholder("First Name").FillAsync(firstName);
        await page.GetByPlaceholder("Last Name").FillAsync(lastName);
        await page.GetByPlaceholder("name@example.com").FillAsync(email);
        await page.GetByPlaceholder("Age").FillAsync(age);
        await page.GetByPlaceholder("Salary").FillAsync(salary);
        await page.GetByPlaceholder("Department").FillAsync(department);
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        // Assert
        await Assertions.Expect(locatorNewRow).ToBeVisibleAsync();
        await Assertions.Expect(locatorNewRow).ToContainTextAsync(lastName);
        await Assertions.Expect(locatorNewRow).ToContainTextAsync(email);
        await Assertions.Expect(locatorNewRow).ToContainTextAsync(age);
        await Assertions.Expect(locatorNewRow).ToContainTextAsync(salary);
        await Assertions.Expect(locatorNewRow).ToContainTextAsync(department);
    }
}