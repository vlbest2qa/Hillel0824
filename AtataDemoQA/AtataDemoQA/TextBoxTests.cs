using Atata;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V125.DOM;
using System;

namespace AtataDemoQA
{
    public sealed class TextBoxTests : UITestFixture
    {
        [Test]
        public void FillAndSubmitTextBox()
        {
            string fullName = "Vladyslav";
            string email = "myemail@gmail.com";
            string currentAdress = "4B Serpova street, Kharkiv, Ukraine";
            string permanentAdress = "8 Berejnia street, Vasisheve, Ukraine";

            Go.To<TextBoxPage>()
                .FullName.Set(fullName)
                .Email.Set(email)
                .CurrentAddres.Set(currentAdress)
                .PermanentAddress.ScrollTo().ScrollDown()
                .PermanentAddress.Set(permanentAdress)
                .Submit.ScrollTo().ScrollDown()
                .Submit.Click()
                .FullNameResult.ScrollTo().ScrollDown()
                .FullNameResult.Should.Be("Name:" + fullName)
                .EmailResult.Should.Be("Email:" + email)
                .CurrentAddressResult.Should.Be("Current Address :" + currentAdress)
                .PermanentAddressResult.Should.Be("Permananet Address :" + permanentAdress);
        }
    }
}
