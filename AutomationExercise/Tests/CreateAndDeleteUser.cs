
using Microsoft.Playwright.NUnit;

namespace AutomationExercise.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CreateAndDeleteUser : UITestFixture
{
    [Test]
    public async Task CreateAndDeleteUsers()
    {
        await page.GotoAsync("https://playwright.dev");
    }
}
