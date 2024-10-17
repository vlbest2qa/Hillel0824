using Microsoft.Playwright;

namespace LambdatestEcom
{
    public class UITestFixture
    {
        public IPage page { get; private set; }
        private IBrowser browser;
        private IBrowserContext context;

        [SetUp]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = ciEnv == "true"
            });

            // File, Path to save session
            string subPath = "../../../playwright/.auth";
            string filePath = "../../../playwright/.auth/state.json";
            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);
            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "{}");

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                IgnoreHTTPSErrors = true,
                StorageStatePath = filePath
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();

            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");
            if (!await page.GetByRole(AriaRole.Heading, new() { Name = "My Account" }).IsVisibleAsync())
            {
                await page.GetByPlaceholder("E-Mail Address").FillAsync("mymail@gmail.com");
                await page.GetByPlaceholder("Password").FillAsync("test");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
                await context.StorageStateAsync(new()
                {
                    Path = filePath
                });
            }
            //page.SetDefaultTimeout(5000);
        }

        [TearDown]
        public async Task Teardown()
        {
            await context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
            });

            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
