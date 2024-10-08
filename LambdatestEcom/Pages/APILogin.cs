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

        public async Task<bool> APIlogin(string email, string password)
        {
            var multipart = _page.APIRequest.CreateFormData();
            multipart.Append("email", email);
            multipart.Append("password", password);

            var response = await _page.APIRequest
                .PostAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login", 
                new() { Form = multipart });
            /*
             * Хотів перевірити респонс якщо не вийшло авторизуватись і якось обробити це, але він все одно шле 200=)
             * Тож залишив else як є, бо не знаю як там буде.
             * Можливо Task<bool> змінити на string і в ньому описувати результати і порівнювати з очікуємим.
             */
            if (response.Ok) 
            {
                return response.Ok;
            }
            else
            {
                return false;
            }
        }
    }
}
