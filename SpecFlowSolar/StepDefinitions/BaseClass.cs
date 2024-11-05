using OpenQA.Selenium;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    public abstract class BaseClass
    {
        public IWebDriver _driver;

        public HomePage homePage;
        public CartPage cartPage;
        public CatalogPage catalogPage;

        public ScenarioContext scenarioContext;
        public BaseClass(ScenarioContext scenarioContext)
        {
            scenarioContext = scenarioContext;
            _driver = scenarioContext["WebDriver"] as IWebDriver;

            homePage = new HomePage(_driver);
            cartPage = new CartPage(_driver);
            catalogPage = new CatalogPage(_driver);
        }
    }
}