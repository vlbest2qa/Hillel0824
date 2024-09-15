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

        //[FindByPlaceholder("Current Address")]
        [FindById("currentAddress")]
        public TextArea<_> CurrentAddres { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddress { get; set; }

        [FindById("submit")]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameResult { get; set; }

        [FindById("email")]
        public Text<_> EmailResult { get; set; }

        [FindByCss("#output #currentAddress")]
        public Text<_> CurrentAddressResult { get; set; }

        [FindByCss("#output #permanentAddress")]
        public Text<_> PermanentAddressResult { get; set; }
    }
}
