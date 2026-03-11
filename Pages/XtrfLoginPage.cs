using Microsoft.Playwright;

namespace UnaLingua.Tests.Pages
{
    public class XtrfLoginPage
    {
        private readonly IPage _page;

        private const string Url =
            "https://unalingua.s.xtrf.eu/customers/index.html#/sign-in";

        // Selectors
        private const string EmailInput = "#username";
        private const string PasswordInput = "#password";
        private const string SignInButton = "button.btn-success";
        private const string ErrorMessage =
            ".alert-danger";

        public XtrfLoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync(Url);
        }

        public async Task LoginAsync(string email, string password)
        {
            await _page.FillAsync(EmailInput, email);
            await _page.FillAsync(PasswordInput, password);
            await _page.ClickAsync(SignInButton);
        }

        public async Task<string> GetErrorMessageAsync()
        {
            return await _page.TextContentAsync(ErrorMessage) ?? "";
        }

        public async Task<bool> IsSignInButtonDisabledAsync()
        {
            return await _page.IsDisabledAsync(SignInButton);
        }
    }
}
