using AutomationExercise.Models;
using Microsoft.Playwright;

namespace AutomationExercise.Pages
{
    internal class ContactUsPage(IPage page) : BasePage(page)
    {
        public ILocator PageHeader()
        {
            return _page.GetByRole(AriaRole.Heading, new() { Name = "Get In Touch" });
        }

        public async Task FillContactUsForm(ContactUsForm ContactUsFormModel)
        {
            await _page.GetByPlaceholder("Name").FillAsync(ContactUsFormModel.Name ?? "");
            await _page.GetByPlaceholder("Email", new() { Exact = true }).FillAsync(ContactUsFormModel.Email ?? "");
            await _page.GetByPlaceholder("Subject").FillAsync(ContactUsFormModel.Subject ?? "");
            await _page.GetByPlaceholder("Your Message Here").FillAsync(ContactUsFormModel.Massage ?? "");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), ContactUsFormModel.FileName);
            File.WriteAllText(filePath, ContactUsFormModel.FileText);

            await _page.Locator("input[name=\"upload_file\"]").SetInputFilesAsync(new[] { filePath });
        }

        public async Task ClickSubmitButton()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        }

        public ILocator FormSuccessMassage()
        {
            return _page.Locator("#contact-page").GetByText("Success! Your details have");
        }

        public async Task ClickHomeButtonSuccessPage()
        {
            await _page.Locator(".contact-form").GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();
        }
    }
}
