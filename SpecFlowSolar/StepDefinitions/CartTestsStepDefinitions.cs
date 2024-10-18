using NUnit.Framework;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    [Binding]
    [Scope(Tag = "cartTests")]
    public class CartTestsStepDefinitions : BaseClass
    {
        [Given(@"open home page")]

        public void GivenOpenHomePage()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenHomePage();
        }

        [When(@"open solar cabels in menu")]
        public void WhenOpenSolarCabelsInMenu()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenSolarCabels();
        }

        [When(@"add second product to cart")]
        public void WhenAddSecondProductToCart()
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.AddToCartOneProduct(1);
        }

        [When(@"go to cart in popup window")]
        public void WhenGoToCartInPopupWindow()
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.GoToCartInModal();
        }

        [When(@"remove product from cart")]
        public void WhenRemoveProductFromCart()
        {
            var cartPage = new CartPage(_driver);
            cartPage.RemoveProductFromCartIfOne();
        }

        [Then(@"current url is equal to home url")]
        public void ThenCurrentUrlIsEqualToHomeUrl()
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.IsCurentUrlEqualHome(), Is.EqualTo(true), "Current url NOT equal home url.");
        }

        [Then(@"title is displayed")]
        public void ThenTitleIsDisplayed()
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.IsTitleDisplayed(), Is.EqualTo(true), "Not found title on the page.");
        }

        [Then(@"home page title name is '([^']*)'")]
        public void ThenHomePageTitleNameIs(string titleName)
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.GetTitlelHome(), Is.EqualTo(titleName), "Current title not equal home title.");
        }
    }
}