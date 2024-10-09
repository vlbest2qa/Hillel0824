using Microsoft.Playwright;

namespace LambdatestEcom.Pages
{
    internal class APILogin
    {
        private readonly IPage _page;

        public APILogin(IPage page)
        {
            _page = page;
        }

        public async Task APIlogin(string email, string password)
        {
            var multipart = _page.APIRequest.CreateFormData();
            multipart.Append("email", email);
            multipart.Append("password", password);

            await _page.APIRequest
                .PostAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login", 
                new() { Form = multipart });
        }
    }
}
