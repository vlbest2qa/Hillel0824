using AutomationExercise.Models;
using AutomationExercise.Pages;
using Microsoft.Playwright;

namespace AutomationExercise.Tests
{
    [Parallelizable(ParallelScope.Self)]

    public class ContactUsFormTests : UITestFixture
    {
        [Test]
        public async Task CheckValidSubmitContactUsForm()
        {
            // Arrange
            var homePage = new HomePage(page);
            var contactUsPage = new ContactUsPage(page);
            var contactUsFormValidModel = new ContactUsForm
            {
                Name = "Vladyslav",
                Email = "1242134@example.com",
                Subject = "Some Subject",
                Massage = "Write some massage in field",
                FileName = "ValidFillAndSubmitForm.txt",
            };

            // Act
            await homePage.Open();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();
            await homePage.ClickLinkShopMenu("Contact Us");
            await Assertions.Expect(contactUsPage.PageHeader()).ToBeVisibleAsync();
            await contactUsPage.FillContactUsForm(contactUsFormValidModel);
            contactUsPage.RunListenDialogBrowser(true);
            await contactUsPage.ClickSubmitButton();

            // Assert
            await Assertions.Expect(contactUsPage.FormSubmitSuccessMassage()).ToBeVisibleAsync();
            await contactUsPage.ClickHomeButtonSuccessPage();
            await Assertions.Expect(homePage.SliderHomePage()).ToBeVisibleAsync();
        }
    }
}
