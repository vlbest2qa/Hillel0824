using Atata;
using _ = AtataDemoQA.TextBoxPage;

namespace AtataDemoQA
{
    [Url("/text-box")]
    public sealed class TextBoxPage : Page<_>
    {
        [FindById("userName")]
        public TextInput<_> FullName { get; set; }

        [FindById("userEmail")]
        public EmailInput<_> Email { get; set; }

        [FindByXPath("//*[@placeholder='Current Address']")]
        public TextArea<_> CurrentAddres { get; set; }

        [FindByXPath("//*[@class='col-md-9 col-sm-12']//*[@id='permanentAddress']")]
        public TextArea<_> PermanentAddress { get; set; }

        [FindById("submit")]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameResult { get; set; }

        [FindById("email")]
        public Text<_> EmailResult { get; set; }

        [FindByCss("#output #currentAddress.mb-1")]
        public Text<_> CurrentAddressResult { get; set; }

        [FindByXPath("//*[@Id='output']//*[@id='permanentAddress']")]
        public Text<_> PermanentAddressResult { get; set; }
    }
}
