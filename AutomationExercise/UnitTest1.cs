using System.Reflection;
using System.Text.RegularExpressions;
using AutomationExercise.Models;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace AutomationExercise;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    private readonly string emailForUserCreate = "1242134@example.com";
    private readonly string passwordForUserCreate = "123412341";
    [Test]
    public async Task HasTitle()
    {
        var model = new UserCreateRequest
        {
            Name = "Vladyslav",
            Email = emailForUserCreate,
            Password = passwordForUserCreate,
            Title = "Mr",
            Birth_date = "31",
            Birth_month = "5",
            Birth_year = "1995",
            FirstName = "Vlad",
            LastName = "Kotelevets",
            Company = "Corp",
            Address1 = "1234 Main St",
            Address2 = "Apt 101",
            Country = "United States",
            ZipCode = "12345",
            State = "California",
            City = "Los Angeles",
            Mobile_number = "35235235231"
        };

        foreach (var property in model.GetType().GetProperties())
        {
            var propertyName = property.Name.ToLower();
            var propertyValue = property.GetValue(model);
            Console.WriteLine($"{propertyName}: {propertyValue}");
        }
    }

    [Test]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}