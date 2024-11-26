using AutomationExercise.Models;
using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]

    public class ContactUsFormTests : UITestFixture
    {
        [Test]
        public async Task ValidFillAndSubmitForm()
        {
            // Arrange
            var homePage = new HomePage(page);
            var contactUsPage = new ContactUsPage(page);
            var contactUsFormModel = new ContactUsForm
            {
                Name = "Vladyslav",
                Email = "1242134@example.com",
                Subject = "Some Subject",
                Massage = "Write some massage in field",
                FileName = "ValidFillAndSubmitForm.txt",
                FileText = "File ganarate for ValidFillAndSubmitForm test."
            };

            // Act
            await homePage.Open();
            Assert.That(await homePage.GetPageTitle(), Is.EqualTo("Automation Exercise"));
            await homePage.ClickLinkShopMenu("Contact Us");
            await Assertions.Expect(contactUsPage.PageHeader()).ToBeVisibleAsync();
            await contactUsPage.FillContactUsForm(contactUsFormModel);
            contactUsPage.RunListenDialogBrowser(true);
            await contactUsPage.ClickSubmitButton();

            // Assert
            await Assertions.Expect(contactUsPage.FormSuccessMassage()).ToBeVisibleAsync();
            await contactUsPage.ClickHomeButtonSuccessPage();
            Assert.That(await homePage.GetPageTitle(), Is.EqualTo("Automation Exercise"));            
        }
    }
}
