using Microsoft.Playwright.NUnit;

namespace AutomationExercise.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CreateAndDeleteUser : UITestFixture
{
    [Test]
    public async Task CreateAndDeleteUser1()
    {
        await page.GotoAsync("https://automationexercise.com/login");
    }
}
