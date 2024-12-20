﻿using Microsoft.Playwright;

namespace AutomationExercise
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

            string subPath = "../../../playwright/.auth";
            string filePath = "../../../playwright/.auth/state.json";
            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "{}");

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

            await page.GotoAsync("https://automationexercise.com/login");
            if (await page.GetByRole(AriaRole.Heading, new() { Name = "Login to your account" }).IsVisibleAsync())
            {
                await page.Locator("form").Filter(new() { HasText = "Login" })
                    .GetByPlaceholder("Email Address").FillAsync(TestConstants.EmailForUserCreate);
                await page.GetByPlaceholder("Password").FillAsync(TestConstants.PasswordForUserCreate);
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
                await context.StorageStateAsync(new()
                {
                    Path = filePath
                });
            }
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
