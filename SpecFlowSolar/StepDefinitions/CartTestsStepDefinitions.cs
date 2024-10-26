using NUnit.Framework;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    [Binding]
    [Scope(Tag = "cartTests")]
    public class CartTestsStepDefinitions : BaseClass
    {
        public CartTestsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"open home page")]

        public void GivenOpenHomePage()
        {
            homePage.OpenHomePage();
        }

        [When(@"open solar cabels in menu")]
        public void WhenOpenSolarCabelsInMenu()
        {
            homePage.OpenSolarCabels();
        }

        [When(@"add second product to cart")]
        public void WhenAddSecondProductToCart()
        {
            catalogPage.AddToCartOneProduct(1);
        }

        [When(@"go to cart in popup window")]
        public void WhenGoToCartInPopupWindow()
        {
            catalogPage.GoToCartInModal();
        }

        [When(@"remove product from cart")]
        public void WhenRemoveProductFromCart()
        {
            cartPage.RemoveProductFromCartIfOne();
        }

        [Then(@"current url is equal to home url")]
        public void ThenCurrentUrlIsEqualToHomeUrl()
        {
            Assert.That(homePage.IsCurentUrlEqualHome(), Is.EqualTo(true), "Current url NOT equal home url.");
        }

        [Then(@"title is displayed")]
        public void ThenTitleIsDisplayed()
        {
            Assert.That(homePage.IsTitleDisplayed(), Is.EqualTo(true), "Not found title on the page.");
        }

        [Then(@"home page title name is '([^']*)'")]
        public void ThenHomePageTitleNameIs(string titleName)
        {
            Assert.That(homePage.GetTitlelHome(), Is.EqualTo(titleName), "Current title not equal home title.");
        }
    }
}