using OpenQA.Selenium;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    public abstract class BaseClass
    {
        public IWebDriver _driver;

        public CartPage cartPage;
        public CatalogPage catalogPage;
        public HomePage homePage;

        public ScenarioContext scenarioContext;
        public BaseClass(ScenarioContext scenarioContext)
        {
            scenarioContext = scenarioContext;
            _driver = scenarioContext["WebDriver"] as IWebDriver;
        }
    }
}