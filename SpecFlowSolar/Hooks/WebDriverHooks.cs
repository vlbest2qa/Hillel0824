using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SpecFlowSolar.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 10)]
        public void InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200");
            var driver = new ChromeDriver(options);

            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void CloseWebDriver()
        {
            if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }

    }
}